using UnityEngine;
using System.Collections.Generic;

namespace WoodenSetFurniture
{
    public class WoodenTableConfig : IBuildingConfig
    {
        public const string ID = "WoodenTable";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 10, 100f };
            string[] textArray1 = new string[] { "BuildableRaw", "BuildingWood" };

            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 3, 1, "table_w_prop_kanim", 30, 10f, singleArray1, textArray1, 1600f, BuildLocationRule.OnFloor, TUNING.DECOR.BONUS.TIER1, TUNING.NOISE_POLLUTION.NONE, 0.5f);
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
            SelectableSign selectable = go.AddOrGet<SelectableSign>();
            selectable.AnimationNames = new List<string>()
            {
                "off", "art_a", "art_b", "art_c", "art_d", "art_e", "art_f", "art_g", "art_h"
            };
            selectable.IconPrefix = ID;
        }
    }
}
