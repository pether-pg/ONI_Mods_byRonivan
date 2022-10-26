using UnityEngine;

namespace WoodenSetFurniture
{
    public class CozyChairConfig : IBuildingConfig
    {
        public const string ID = "CozyChair";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 10f, 60f, 25 };
            string[] textArray1 = new string[] { "RefinedMetal", "BuildingWood", "BuildingFiber" };

            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 2, 2, "cozy_chair_kanim", 100, 30f, singleArray1, textArray1, 800f, BuildLocationRule.OnFloor, TUNING.DECOR.BONUS.TIER1, TUNING.NOISE_POLLUTION.NONE, 0.2f);
            def1.Floodable = true;
            def1.Overheatable = false;
            def1.AudioCategory = "Plastic";
            def1.AudioSize = "small";
            def1.BaseTimeUntilRepair = -1f;
            def1.ViewMode = OverlayModes.Decor.ID;
            def1.SceneLayer = Grid.SceneLayer.Building;
            def1.DefaultAnimState = "off";
            def1.PermittedRotations = PermittedRotations.FlipH;
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
    }
}
