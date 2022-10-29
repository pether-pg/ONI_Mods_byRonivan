using STRINGS;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Crop_Creamcap : IEntityConfig
    {
        public const string Id = "Creamtop_Cap";
        public static string Name = UI.FormatAsLink("Creamcap", "Creamtop_Cap".ToUpper());
        public static string Description = "The fruiting body of a Creamcap Mushroom. Has a rich earthy flavor and a pungent, mildly sweet aroma";

        public GameObject CreatePrefab() => 
            EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Creamtop_Cap", Name, Description, 1f, false, Assets.GetAnim("edible_creamcap_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("Creamtop_Cap", "", 1200000f, -1, 255.15f, 277.15f, 3200f, true));

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

