using System;
using TUNING;
using UnityEngine;

namespace WoodenSetStructures
{
    public class WoodenDryWall_BConfig : IBuildingConfig
    {
        public const string ID = "WoodenDryWall_B";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            go.AddOrGet<AnimTileable>().objectLayer = ObjectLayer.Backwall;
            go.AddComponent<ZoneTile>();
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 100f, 150f };
            string[] textArray1 = new string[] { "BuildableRaw", "BuildingWood" };
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 1, 1, "wooden_B_walls_kanim", 100, 15f, singleArray1, textArray1, 1600f, BuildLocationRule.Tile, BUILDINGS.DECOR.BONUS.TIER0, nONE, 0.2f);
            def1.Entombable = false;
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.AudioCategory = "Metal";
            def1.AudioSize = "small";
            def1.BaseTimeUntilRepair = -1f;
            def1.DefaultAnimState = "off";
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
