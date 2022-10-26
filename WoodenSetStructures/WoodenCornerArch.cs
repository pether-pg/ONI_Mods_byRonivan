using System;
using TUNING;
using UnityEngine;

namespace WoodenSetStructures
{
    public class WoodenCornerArchConfig : IBuildingConfig
    {
        public const string ID = "WoodenCornerArch";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues decor = new EffectorValues
            {
                amount = 5,
                radius = 3
            };
            float[] singleArray1 = new float[] { 100f, 50f };
            string[] textArray1 = new string[] { "BuildableRaw", "BuildingWood" };

            BuildingDef def1 = BuildingTemplates.CreateBuildingDef("WoodenCornerArch", 1, 1, "wooden_corner_arch_kanim", 10, 30f, singleArray1, textArray1, 800f, BuildLocationRule.InCorner, decor, NOISE_POLLUTION.NONE, 0.2f);
            def1.DefaultAnimState = "corner";
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.ViewMode = OverlayModes.Decor.ID;
            def1.AudioCategory = "Metal";
            def1.AudioSize = "small";
            def1.PermittedRotations = PermittedRotations.FlipH;
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
    }


}
