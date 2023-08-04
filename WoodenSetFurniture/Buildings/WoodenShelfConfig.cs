using System.Collections.Generic;
using UnityEngine;
using TUNING;

namespace WoodenSetFurniture
{
    class WoodenShelfConfig : IBuildingConfig
    {
        public const string ID = "WoodenSetFurnitureReuploaded_WoodenShelf";

        public override BuildingDef CreateBuildingDef()
        {
            float[] materialMass = new float[] { 10, 100f };
            string[] materials = new string[] { "BuildableRaw", "BuildingWood" };

            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 3, 1, "shelf_w_prop_kanim", 100, 30f, materialMass, materials, 800f, BuildLocationRule.Anywhere, TUNING.DECOR.BONUS.TIER1, TUNING.NOISE_POLLUTION.NONE, 0.2f);
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.AudioCategory = "HollowMetal";
            def1.AudioSize = "small";
            def1.ViewMode = OverlayModes.Decor.ID;
            def1.SceneLayer = Grid.SceneLayer.Building;
            def1.DefaultAnimState = "off";
            def1.PermittedRotations = PermittedRotations.FlipH;
            return def1;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            SelectableSign selectable = go.AddOrGet<SelectableSign>();
            selectable.AnimationNames = new List<string>()
            {
                "off", "art_a", "art_b", "art_c", "art_d", "art_e", "art_f"
            };
            selectable.IconPrefix = ID;
        }
    }
}
