using HarmonyLib;

namespace WoodenSetFurniture
{
    class WoodenSetFurniture_Patches_DetailScreen
    {
        [HarmonyPatch(typeof(DetailsScreen), "OnPrefabInit")]
        public static class DetailsScreen_OnPrefabInit_Patch
        {
            public static void Postfix()
            {
                FUI_SideScreen.AddClonedSideScreen<SignSideScreen>(
                    "Sign Side Screen",
                    "MonumentSideScreen",
                    typeof(MonumentSideScreen));
            }
        }
    }
}
