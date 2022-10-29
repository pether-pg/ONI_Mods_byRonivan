using HarmonyLib;

namespace MoreCuisineVariety
{
    //===> BEAN PRESS <=========================================================================================
    namespace MoreCuisineVariety_Patches_Buildings
    {

        [HarmonyPatch(typeof(Db), "Initialize")]
        internal class ManualJuicerTechMod
        {
            private static void Postfix()
            {
                Db.Get().Techs.Get("FoodRepurposing").unlockedItemIDs.Add("ManualJuicer");
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class ManualJuicerUI
        {
            private static void Prefix()
            {
                string[] value = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.MANUALJUICER.NAME",
                "Electric Grinder"
                };
                Strings.Add(value);
                string[] value2 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.MANUALJUICER.DESC",
                "Grind food in to juices."
                };
                Strings.Add(value2);
                string[] value3 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.MANUALJUICER.EFFECT",
                "A cooking appliance used to grind down food in to liquids."
                };
                Strings.Add(value3);
                ModUtil.AddBuildingToPlanScreen("Food", "ManualJuicer");
            }
        }
    }

}
