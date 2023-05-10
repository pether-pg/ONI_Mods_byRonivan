using HarmonyLib;

namespace WoodenSetFurniture
{
    class WoodenSetFurniture_Patches_Buldings
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        public static class Db_Initialize_Patch
        {
            public static void Postfix()
            {
                Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add(WoodenBedConfig.ID);
                Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add(WoodenPedestalConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(CozyBedConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(SimpleFireplaceConfig.ID);
                Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add(CozyChairConfig.ID);
                Db.Get().Techs.Get("InteriorDecor").unlockedItemIDs.Add(WoodenTableConfig.ID);
                Db.Get().Techs.Get("InteriorDecor").unlockedItemIDs.Add(WoodenShelfConfig.ID);
                Db.Get().Techs.Get("FineDining").unlockedItemIDs.Add(KitchenHoodConfig.ID);
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            public static void Prefix()
            {
                BasicModUtils.RegisterBuildingStrings(WoodenBedConfig.ID, STRINGS.BUILDINGS.WOODENBED.NAME, STRINGS.BUILDINGS.WOODENBED.DESC, STRINGS.BUILDINGS.WOODENBED.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenPedestalConfig.ID, STRINGS.BUILDINGS.WOODENPEDESTAL.NAME, STRINGS.BUILDINGS.WOODENPEDESTAL.DESC, STRINGS.BUILDINGS.WOODENPEDESTAL.EFFECT);
                BasicModUtils.RegisterBuildingStrings(CozyBedConfig.ID, STRINGS.BUILDINGS.COZYBED.NAME, STRINGS.BUILDINGS.COZYBED.DESC, STRINGS.BUILDINGS.COZYBED.EFFECT);
                BasicModUtils.RegisterBuildingStrings(CozyChairConfig.ID, STRINGS.BUILDINGS.COZYCHAIR.NAME, STRINGS.BUILDINGS.COZYCHAIR.DESC, STRINGS.BUILDINGS.COZYCHAIR.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenTableConfig.ID, STRINGS.BUILDINGS.WOODENTABLE.NAME, STRINGS.BUILDINGS.WOODENTABLE.DESC, STRINGS.BUILDINGS.WOODENTABLE.EFFECT);
                BasicModUtils.RegisterBuildingStrings(SimpleFireplaceConfig.ID, STRINGS.BUILDINGS.SIMPLEFIREPLACE.NAME, STRINGS.BUILDINGS.SIMPLEFIREPLACE.DESC, STRINGS.BUILDINGS.SIMPLEFIREPLACE.EFFECT);
                BasicModUtils.RegisterBuildingStrings(KitchenHoodConfig.ID, STRINGS.BUILDINGS.KITCHENHOOD.NAME, STRINGS.BUILDINGS.KITCHENHOOD.DESC, STRINGS.BUILDINGS.KITCHENHOOD.EFFECT);
                BasicModUtils.RegisterBuildingStrings(WoodenShelfConfig.ID, STRINGS.BUILDINGS.WOODENSHELF.NAME, STRINGS.BUILDINGS.WOODENSHELF.DESC, STRINGS.BUILDINGS.WOODENSHELF.EFFECT);

                BasicModUtils.MakeSideScreenStrings(SignSideScreen.SCREEN_TITLE_KEY, STRINGS.SIDESCREEN.TITLE);

                ModUtil.AddBuildingToPlanScreen("Furniture", WoodenBedConfig.ID); 
                ModUtil.AddBuildingToPlanScreen("Furniture", WoodenPedestalConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Furniture", CozyBedConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Furniture", CozyChairConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Furniture", WoodenTableConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Furniture", SimpleFireplaceConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Furniture", KitchenHoodConfig.ID);
                ModUtil.AddBuildingToPlanScreen("Furniture", WoodenShelfConfig.ID);
            }
        }
    }
}


