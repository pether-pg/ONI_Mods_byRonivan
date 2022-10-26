using System;
using TUNING;
using UnityEngine;

namespace WoodenSetStructures
{
    public class WoodenCeilingConfig : IBuildingConfig
    {
        public const string ID = "WoodenCeiling";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
            go.AddOrGet<AnimTileable>();
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 50f, 50f };
            string[] textArray1 = new string[] { "BuildableRaw", "BuildingWood" };

            EffectorValues decor = new EffectorValues
            {
                amount = 5,
                radius = 3
            };
            BuildingDef def = BuildingTemplates.CreateBuildingDef("WoodenCeiling", 1, 1, "wooden_ceiling_kanim", 10, 30f, singleArray1, textArray1, 800f, BuildLocationRule.OnCeiling, decor, NOISE_POLLUTION.NONE, 0.2f);
            def.DefaultAnimState = "S_U";
            def.Floodable = false;
            def.Overheatable = false;
            def.ViewMode = OverlayModes.Decor.ID;
            def.AudioCategory = "Metal";
            def.AudioSize = "small";
            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
    }
}


