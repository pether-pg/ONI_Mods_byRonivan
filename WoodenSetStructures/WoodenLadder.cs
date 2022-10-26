using System;
using TUNING;
using UnityEngine;

namespace WoodenSetStructures
{
    internal class WoodenLadderConfig : IBuildingConfig
    {
        public const string ID = "WoodenLadder";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            Ladder local1 = go.AddOrGet<Ladder>();
            local1.upwardsMovementSpeedMultiplier = 1f;
            local1.downwardsMovementSpeedMultiplier = 1f;
            go.AddOrGet<AnimTileable>();
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 25, 25f };
            string[] textArray1 = new string[] { "BuildableRaw", "BuildingWood" };
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def = BuildingTemplates.CreateBuildingDef("WoodenLadder", 1, 1, "ladder_wooden_kanim", 10, 5f, singleArray1, textArray1, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.BONUS.TIER1, nONE, 0.2f);
            BuildingTemplates.CreateLadderDef(def);
            def.Floodable = false;
            def.Overheatable = false;
            def.Entombable = false;
            def.AudioCategory = "Metal";
            def.AudioSize = "small";
            def.BaseTimeUntilRepair = -1f;
            def.DragBuild = true;
            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
    }
}
