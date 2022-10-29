using STRINGS;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Crop_SunnyWheatGrain : IEntityConfig
    {
        public const string Id = "SunnyWheat_Grain";
        public static string Name = UI.FormatAsLink("Sunny Wheat Grain", "SunnyWheat_Grain".ToUpper());
        public static string Description = ("The edible grain of a " + UI.FormatAsLink("Sunny Wheat", "SunnyWheat") + ". This edible grain leaves a warm taste on the tongue.");

        public GameObject CreatePrefab() => 
            EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("SunnyWheat_Grain", Name, Description, 1f, false, Assets.GetAnim("edible_sunnygrain_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("SunnyWheat_Grain", "", 0f, -1, 255.15f, 277.15f, 2400f, true));

        public string[] GetDlcIds() => 
            DlcManager.AVAILABLE_ALL_VERSIONS;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}

