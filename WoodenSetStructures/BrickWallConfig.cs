using System;
using TUNING;
using UnityEngine;

namespace WoodenSetStructures
{
    public class BrickWallConfig : IBuildingConfig
    {
        public const string ID = "BrickWall";
        private static readonly CellOffset[] overrideOffsets = new CellOffset[]
        {
            new CellOffset(-1, -1),
            new CellOffset(1, -1),
            new CellOffset(-1, 1),
            new CellOffset(1, 1)
        };

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            go.AddOrGet<AnimTileable>().objectLayer = ObjectLayer.Backwall;
            go.AddComponent<ZoneTile>();
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 100f, 50f };
            string[] textArray1 = new string[] { "BuildableRaw", "Metal" };
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef("BrickWall", 1, 1, "brick_wall_kanim", 100, 15f, singleArray1, textArray1, 1600f, BuildLocationRule.Tile, BUILDINGS.DECOR.BONUS.TIER0, nONE, 0.2f);
            def1.Entombable = false;
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.AudioCategory = "Metal";
            def1.AudioSize = "small";
            def1.BaseTimeUntilRepair = -1f;
            def1.DefaultAnimState = "off";
            def1.ThermalConductivity = 0.05f; // THERMAL CONDUCTIVITY
            def1.ObjectLayer = ObjectLayer.Canvases;
            def1.SceneLayer = Grid.SceneLayer.LogicGatesFront;
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            GeneratedBuildings.RemoveLoopingSounds(go);
        }
    }
}