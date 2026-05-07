using System.Collections.Generic;
using HarmonyLib;
using ThronefallMP.Utils;

namespace ThronefallMP;

public enum Equipment
{
    Invalid,
    PerkPoint,
        
    LongBow,
    LightSpear,
    HeavySword,
    LightningWand,
    ShadowCodex,
    BattleAx,
    BloodWand,
    Falchion,
    PotionVials,
        
    RoyalMint,
    ArcaneTowers,
    HeavyArmor,
    ResilientResidences,
    CastleFortifications,
    RingOfResurrection,
    WarriorTraining,
    ArchitectsCouncil,
    CastleBlueprints,
    GladiatorSchool,
    WarHorse,
    GlassCannon,
    BigHarbours,
    EliteWarriors,
    CommanderMode,
    ArcherySkills,
    FasterResearch,
    FortifiedHouses,
    PumpkinFields,
    HealingSpirits,
    IceMagic,
    MeleeResistance,
    PowerTower,
    RangedResistance,
    TreasureHunter,
    SustainableMining,
    GodsLotion,
    MeleeDamage,
    AntiAirTelescope,
    HealthPotions,
    RangedDamage,
    StrongerHeroes,
    Loan,
    EliteTowers,
    AncientShrines,
    LighterMaterials,
    SpellScroll,
    Daredevil,
    EmergencyRepairs,
    Interest,
    RelentlessResearch,
    ExplosiveWalls,
    TimberScaffolding,
    ExperienceGain,
    DoubleHealing,
    PristineArchers,
    Outpost,
    HealingGold,
    ExplosiveRevival,
    PristineWarriors,
    Cobbler,
    AgileHorse,
    RoyalProtection,
    LastStand,
    
        
    AssassinsTraining,
    MagicArmor,
    GodlyCurse,
    CastleUp,
        
    MillScarecrow,
    MillWindSpirits,
        
    TowerHotOil,
        
    MeleeFlails,
    RangedHunters,
    MeleeBerserkers,
    RangedFireArchers,
        
    WarGods,
    Turtle,
    Tiger,
    Rat,
    Falcon,
    Destruction,
    Wasp,
    Death,
    Phoenix,
    
    NoWallsPact,
    NoTowersPact,
    NoUnitsPact
}

public static class Equip
{
    public static readonly HashSet<Equipment> Weapons = new()
    {
        Equipment.LongBow,
        Equipment.LightSpear,
        Equipment.HeavySword,
        Equipment.LightningWand,
        Equipment.ShadowCodex,
        Equipment.Falchion,
        Equipment.BloodWand,
        Equipment.BattleAx,
        Equipment.PotionVials
    };
    
    private static readonly Dictionary<string, Equipment> NameToEquip = new()
    {
        { "", Equipment.Invalid },
        { "Perk Point", Equipment.PerkPoint },
        
        // Weapons
        { "Long Bow", Equipment.LongBow },
        { "Light Spear", Equipment.LightSpear },
        { "Heavy Sword", Equipment.HeavySword },
        { "Lightning Wand", Equipment.LightningWand },
        { "Shadow Codex", Equipment.ShadowCodex },
        { "Falchion & Traps", Equipment.Falchion },
        { "Blood Wand", Equipment.BloodWand },
        { "Battle Ax", Equipment.BattleAx },
        { "Potion Vials", Equipment.PotionVials },
        
        // Perks
        { "Royal Mint", Equipment.RoyalMint },
        { "Arcane Towers", Equipment.ArcaneTowers },
        { "Heavy Armor", Equipment.HeavyArmor },
        { "Castle Fortifications", Equipment.CastleFortifications },
        { "Ring of Resurrection", Equipment.RingOfResurrection },
        { "Pumpkin Fields", Equipment.PumpkinFields },
        { "Architect's Council", Equipment.ArchitectsCouncil },
        { "Gods' Lotion", Equipment.GodsLotion },
        { "Castle Blueprints", Equipment.CastleBlueprints },
        { "Gladiator School", Equipment.GladiatorSchool },
        { "War Horse", Equipment.WarHorse },
        { "Glass Cannon", Equipment.GlassCannon },
        { "Big Harbours", Equipment.BigHarbours },
        { "Elite Warriors", Equipment.EliteWarriors },
        { "Archery Skills", Equipment.ArcherySkills },
        { "Faster Research", Equipment.FasterResearch },
        { "Resilient Residences", Equipment.ResilientResidences },
        { "Fortified Houses", Equipment.FortifiedHouses },
        { "Commander Mode", Equipment.CommanderMode },
        { "Healing Spirits", Equipment.HealingSpirits },
        { "Ice Magic", Equipment.IceMagic },
        { "Melee Resistance", Equipment.MeleeResistance },
        { "Power Tower", Equipment.PowerTower },
        { "Ranged Resistance", Equipment.RangedResistance },
        { "Treasure Hunter", Equipment.TreasureHunter },
        { "Sustainable Mining", Equipment.SustainableMining },
        { "Warrior Training", Equipment.WarriorTraining },
        { "Melee Damage", Equipment.MeleeDamage },
        { "Health Potions", Equipment.HealthPotions },
        { "Anti Air Telescope", Equipment.AntiAirTelescope },
        { "Ranged Damage", Equipment.RangedDamage },
        { "Stronger Heroes", Equipment.StrongerHeroes },
        { "Loan", Equipment.Loan },
        { "Elite Towers", Equipment.EliteTowers },
        { "Ancient Shrines", Equipment.AncientShrines },
        { "Lighter Materials", Equipment.LighterMaterials },
        { "Spell Scroll", Equipment.SpellScroll },
        { "Daredevil", Equipment.Daredevil },
        { "Emergency Repairs", Equipment.EmergencyRepairs },
        { "Interest", Equipment.Interest },
        { "Relentless Research", Equipment.RelentlessResearch },
        { "Explosive Walls", Equipment.ExplosiveWalls },
        { "Timer Scaffolding", Equipment.TimberScaffolding },
        { "Experience Gain", Equipment.ExperienceGain },
        { "Double Healing", Equipment.DoubleHealing },
        { "Pristine Archers", Equipment.PristineArchers },
        { "Outpost", Equipment.Outpost },
        { "Healing Gold", Equipment.HealingGold },
        { "Explosive Revival", Equipment.ExplosiveRevival },
        { "Pristine Warriors", Equipment.PristineWarriors },
        { "Cobbler", Equipment.Cobbler },
        { "Agile Horse", Equipment.AgileHorse },
        { "Royal Protection", Equipment.RoyalProtection },
        { "Last Stand", Equipment.LastStand },
        
        // Castle Upgrades
        { "CCAssassinsTraining", Equipment.AssassinsTraining },
        { "CCMagicArmor", Equipment.MagicArmor },
        { "CCGodlyCurse", Equipment.GodlyCurse },
        { "CCCastleUp", Equipment.CastleUp },
        
        // Mill Upgrades
        { "MillScarecrow", Equipment.MillScarecrow },
        { "MillWindSpirits", Equipment.MillWindSpirits },
        
        // Tower Upgrades
        { "TowerHotOil", Equipment.TowerHotOil },
        
        // Units
        { "MeleeFlails", Equipment.MeleeFlails },
        { "RangedHunters", Equipment.RangedHunters },
        { "MeleeBerserks", Equipment.MeleeBerserkers },
        { "RangedFireArchers", Equipment.RangedFireArchers },
        
        // Mutators
        { "Pray to The God of Strength", Equipment.WarGods },
        { "Taunt The Turtle God", Equipment.Turtle },
        { "Taunt The Tiger God", Equipment.Tiger },
        { "Taunt The Rat God", Equipment.Rat },
        { "Taunt The Falcon God", Equipment.Falcon },
        { "Taunt God of Destruction", Equipment.Destruction },
        { "Taunt The Cheese God", Equipment.Wasp },
        { "Taunt The Disease God", Equipment.Death },
        { "Taunt The Phoenix God", Equipment.Phoenix },
        { "No Walls Pact", Equipment.NoWallsPact },
        { "No Towers Pact", Equipment.NoTowersPact },
        { "No Units Pact", Equipment.NoUnitsPact },
    };
    
    private static readonly Dictionary<Equipment, Equippable> EquipmentToEquippable = new();
    private static readonly Dictionary<Equippable, Equipment> EquippableToEquipment = new();
    private static bool _initialized;

    private static void InitializeDictionaries()
    {
        _initialized = true;
        var metaLevels = Traverse.Create(PerkManager.instance).Field<List<MetaLevel>>("metaLevels");
        Plugin.Log.LogInfoFiltered("Equipment", "Initializing converter dictionary");
        Plugin.Log.LogInfoFiltered("Equipment", "Meta levels");
        foreach (var meta in metaLevels.Value)
        {
            var equipment = Convert(meta.reward.name);
            Plugin.Log.LogInfoFiltered("Equipment", $"- {equipment} = {meta.reward.name}");
            EquipmentToEquippable[equipment] = meta.reward;
            EquippableToEquipment[meta.reward] = equipment;
        }
        
        Plugin.Log.LogInfoFiltered("Equipment", "Currently Unlocked");
        foreach (var unlocked in PerkManager.instance.allEquippables)
        {
            if (PerkManager.instance.metaLevelByPerk[unlocked] > PerkManager.instance.level) continue;
            
            var equipment = Convert(unlocked.name);
            Plugin.Log.LogInfoFiltered("Equipment", $"- {equipment} = {unlocked.name}");
            EquipmentToEquippable[equipment] = unlocked;
            EquippableToEquipment[unlocked] = equipment;
        }
    }

    public static void ClearEquipments()
    {
        Plugin.Log.LogInfoFiltered("Equipment", "Clearing equipment");
        PerkManager.instance.CurrentlyEquipped.Clear();
    }

    public static void EquipEquipment(Equipment equipment)
    {
        if (!_initialized)
        {
            InitializeDictionaries();
        }
        
        Plugin.Log.LogInfoFiltered("Equipment", $"Equipping {equipment} -> {EquipmentToEquippable[equipment].displayName}");
        PerkManager.instance.CurrentlyEquipped.Add(EquipmentToEquippable[equipment]);
    }
    
    public static Equipment Convert(Equippable equip)
    {
        if (!_initialized)
        {
            InitializeDictionaries();
        }

        return EquippableToEquipment.GetValueSafe(equip);
    }
    
    public static Equippable Convert(Equipment equip)
    {
        if (!_initialized)
        {
            InitializeDictionaries();
        }

        return EquipmentToEquippable.GetValueSafe(equip);
    }
    
    public static Equipment Convert(string name)
    {
        return NameToEquip.GetValueSafe(name);
    }
}