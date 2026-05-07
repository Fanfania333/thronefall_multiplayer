using System.Collections;
using HarmonyLib;
using UnityEngine;

namespace ThronefallMP.Patches;

public static class CameraRigPatch
{
    public static void Apply()
    {
        On.CameraRig.Update += Update;
        On.CameraRig.TransitionToTarget += TransitionToTarget;
    }

    private static void Update(On.CameraRig.orig_Update original, CameraRig self)
    {
        var cameraTarget = Traverse.Create(self).Field<Transform>("cameraTarget");
        var localData = Plugin.Instance.PlayerManager.LocalPlayer?.Data;
        if (localData != null)
        {
            cameraTarget.Value = localData.transform;
            original(self);
        }
    }

    private static IEnumerator TransitionToTarget(On.CameraRig.orig_TransitionToTarget original, CameraRig self, Transform newTarget, float targetCameraSize)
    {
        var transitionRunning = Traverse.Create(self).Field<bool>("transitionRunning");
        var transitionSpeed = Traverse.Create(self).Field<float>("transitionSpeed");
        var currentTarget = Traverse.Create(self).Field<Transform>("currentTarget");
        var cameraTarget = Traverse.Create(self).Field<Transform>("cameraTarget");
        var cameras = Traverse.Create(self).Field<Camera[]>("cameras");

        transitionRunning.Value = true;
        var startPosition = self.transform.position;
        var startRotation = self.transform.rotation;
        var startCameraSize = cameras.Value[0].orthographicSize;
        var transitionTime = 0f;

        while (transitionTime < 1f)
        {
            if (newTarget == null)
            {
                newTarget = cameraTarget.Value;
                break;
            }

            transitionTime = Mathf.Clamp(transitionTime, 0f, 1f);
            var t = 3f * Mathf.Pow(transitionTime, 2f) - 2f * Mathf.Pow(transitionTime, 3f);
            self.transform.position = Vector3.Lerp(startPosition, newTarget.position, t);
            self.transform.rotation = Quaternion.Lerp(startRotation, newTarget.rotation, t);

            var size = Mathf.Lerp(startCameraSize, targetCameraSize, t);
            foreach (var cam in cameras.Value)
                cam.orthographicSize = size;

            transitionTime += Time.deltaTime * transitionSpeed.Value;
            yield return null;
        }

        self.transform.position = newTarget.position;
        self.transform.rotation = newTarget.rotation;
        foreach (var cam in cameras.Value)
            cam.orthographicSize = targetCameraSize;
        currentTarget.Value = newTarget;
        transitionRunning.Value = false;

        yield return null;

        self.transform.position = newTarget.position;
        self.transform.rotation = newTarget.rotation;
        foreach (var cam in cameras.Value)
            cam.orthographicSize = targetCameraSize;
    }
}