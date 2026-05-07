#!/usr/bin/env bash
set -euo pipefail

DEFAULT_PATH="$HOME/.local/share/Steam/steamapps/common/Thronefall"
MOD_NAME="ThronefallMP"

read -r -p "Input the path to your Thronefall installation (default: $DEFAULT_PATH): " GAME_PATH
GAME_PATH="${GAME_PATH:-$DEFAULT_PATH}"

DLLS=(
    "Assembly-CSharp"
    "AstarPathfindingProject"
    "MoreMountains.Feedbacks"
    "MPUIKit"
    "Rewired_Core"
    "PackageTools"
    "Drawing"
    "ShapesRuntime"
    "Unity.TextMeshPro"
    "UnityEngine.UI"
    "UnityEngine.CoreModule"
    "UnityEngine"
    "com.rlabrecque.steamworks.net"
)

echo "Setting up lib directory"

if [[ ! -f "$GAME_PATH/Thronefall.exe" ]]; then
    echo "Thronefall.exe not found at '$GAME_PATH', terminating."
    exit 1
fi

LIBRARY_PATH="$GAME_PATH/Thronefall_Data/Managed"
mkdir -p ./lib

for dll in "${DLLS[@]}"; do
    src="$LIBRARY_PATH/$dll.dll"
    if [[ ! -f "$src" ]]; then
        echo "  warning: $dll.dll not found at $src"
        continue
    fi
    cp "$src" "./lib/$dll.dll"
done

INSTALL_PATH="$GAME_PATH/BepInEx/plugins/$MOD_NAME"
ESCAPED_PATH=$(printf '%s' "$INSTALL_PATH" | sed -E 's/[][(){}.+*?^$|\\]/\\&/g')
echo "InstallPath = $ESCAPED_PATH" > ./install.cfg

echo "Done. lib/ populated and install.cfg written."
