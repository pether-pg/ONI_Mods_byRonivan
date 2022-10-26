namespace CustomTiles
{
    using System;
    using TUNING;
    using UnityEngine;

    public class StructureFrameSmallConfig : IBuildingConfig
    {
        public const string ID = "StructureFrameSmall";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            go.AddOrGet<AnimTileable>().objectLayer = ObjectLayer.Backwall;
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef("StructureFrameSmall", 1, 1, "structure_frame_small_kanim", 100, 10f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER0, MATERIALS.REFINED_METALS, 1600f, BuildLocationRule.Tile, BUILDINGS.DECOR.BONUS.TIER0, nONE, 0.2f);
            def1.Entombable = false;
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.AudioCategory = "Metal";
            def1.AudioSize = "small";
            def1.BaseTimeUntilRepair = -1f;
            def1.DefaultAnimState = "off";
            def1.ObjectLayer = ObjectLayer.Backwall;
            def1.SceneLayer = Grid.SceneLayer.LogicGatesFront;
            def1.PermittedRotations = PermittedRotations.R360;
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            GeneratedBuildings.RemoveLoopingSounds(go);
        }
    }
}
