using Database;
using HarmonyLib;
using System;
using System.Collections.Generic;
using STRINGS;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace WoodenSetStructures
{
    public class WoodenSetStructures_Patches_Buildings
    {

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public class WoodenCeilingUI
        {
            public static void Prefix()
            {
                BasicModUtils.RegisterBuildingStrings(WoodenCeilingConfig.ID, STRINGS.BUILDINGS.WOODENCEILING.NAME, STRINGS.BUILDINGS.WOODENCEILING.DESC, STRINGS.BUILDINGS.WOODENCEILING.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenCornerArchConfig.ID, STRINGS.BUILDINGS.WOODENCORNERARCH.NAME, STRINGS.BUILDINGS.WOODENCORNERARCH.DESC, STRINGS.BUILDINGS.WOODENCORNERARCH.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenDoorConfig.ID, STRINGS.BUILDINGS.WOODENDOOR.NAME, STRINGS.BUILDINGS.WOODENDOOR.DESC, STRINGS.BUILDINGS.WOODENDOOR.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenDryWall_BConfig.ID, STRINGS.BUILDINGS.WOODENDRYWALL_B.NAME, STRINGS.BUILDINGS.WOODENDRYWALL_B.DESC, STRINGS.BUILDINGS.WOODENDRYWALL_B.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenDryWallConfig.ID, STRINGS.BUILDINGS.WOODENDRYWALL.NAME, STRINGS.BUILDINGS.WOODENDRYWALL.DESC, STRINGS.BUILDINGS.WOODENDRYWALL.EFFECT);
                BasicModUtils.RegisterBuildingStrings(BrickWallConfig.ID, STRINGS.BUILDINGS.BRICKWALL.NAME, STRINGS.BUILDINGS.BRICKWALL.DESC, STRINGS.BUILDINGS.BRICKWALL.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenLadderConfig.ID, STRINGS.BUILDINGS.WOODENLADDER.NAME, STRINGS.BUILDINGS.WOODENLADDER.DESC, STRINGS.BUILDINGS.WOODENLADDER.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenGasTileConfig.ID, STRINGS.BUILDINGS.WOODENGASTILE.NAME, STRINGS.BUILDINGS.WOODENGASTILE.DESC, STRINGS.BUILDINGS.WOODENGASTILE.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenMeshTileConfig.ID, STRINGS.BUILDINGS.WOODENMESHTILE.NAME, STRINGS.BUILDINGS.WOODENMESHTILE.DESC, STRINGS.BUILDINGS.WOODENMESHTILE.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenTileConfig.ID, STRINGS.BUILDINGS.WOODENTILE.NAME, STRINGS.BUILDINGS.WOODENTILE.DESC, STRINGS.BUILDINGS.WOODENTILE.EFFECT);

                ModUtil.AddBuildingToPlanScreen("Furniture", WoodenCeilingConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Furniture", WoodenCornerArchConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Base", WoodenDoorConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Utilities", WoodenDryWall_BConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Utilities", WoodenDryWallConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Utilities", BrickWallConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Base", WoodenLadderConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Base", WoodenGasTileConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Base", WoodenMeshTileConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Base", WoodenTileConfig.ID);
            }
        }

        [HarmonyPatch(typeof(Db), "Initialize")]
        public class WoodenCeilingTechMod
        {
            public static void Postfix()
            {
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(WoodenCeilingConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(WoodenCornerArchConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(WoodenDoorConfig.ID);
                Db.Get().Techs.Get("RenaissanceArt").unlockedItemIDs.Add(WoodenDryWall_BConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(WoodenDryWallConfig.ID);
                Db.Get().Techs.Get("RefractiveDecor").unlockedItemIDs.Add(BrickWallConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(WoodenLadderConfig.ID);
                Db.Get().Techs.Get("PressureManagement").unlockedItemIDs.Add(WoodenGasTileConfig.ID);
                Db.Get().Techs.Get("SanitationSciences").unlockedItemIDs.Add(WoodenMeshTileConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(WoodenTileConfig.ID);
            }
        }
    }
}
