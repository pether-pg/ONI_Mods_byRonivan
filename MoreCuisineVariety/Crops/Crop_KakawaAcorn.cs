using STRINGS;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Crop_KakawaAcorn : IEntityConfig
    {
        public const string Id = "Kakawa_Acorn";
        public static string Name = UI.FormatAsLink("Kakawa Acorn", "Kakawa_Acorn".ToUpper());
        public static string Description = ("The fruits of a " + UI.FormatAsLink("Kakawa Tree", "KakawaTree") + ". Differently from other nuts, this one is so hard that can't be eat raw. The edible inside is also very bitter.");

        public GameObject CreatePrefab() => 
            EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Kakawa_Acorn", Name, Description, 1f, false, Assets.GetAnim("edible_kakawaacorn_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("Kakawa_Acorn", "", 0f, -1, 255.15f, 277.15f, 2400f, true));

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

