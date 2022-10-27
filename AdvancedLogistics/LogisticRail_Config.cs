using System;
using TUNING;
using UnityEngine;
using STRINGS;
using System.Collections.Generic;
using BUILDINGS = TUNING.BUILDINGS;

namespace AdvancedLogistics
{
    public class LogisticRailConfig : IBuildingConfig
    {
        public const string ID = "LogisticRail";
        public const string DisplayName = "Logistic Rail";
        public const string Description = "Rails move materials where they'll be needed most, saving Duplicants the walk.";
        public static string Effect = string.Concat(new string[]
                {
                    "Transports ",
                    UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID"),
                    " on a track between ",
                    UI.FormatAsLink("Conveyor Loader", "SOLIDCONDUITINBOX"),
                    " and ",
                    UI.FormatAsLink("Conveyor Receptacle", "SOLIDCONDUITOUTBOX"),
                    ".\n\nCan be run through wall and floor tile."
                });

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<SolidConduit>();
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 1, 1, "logistic_rail_kanim", 10, 3f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER0, MATERIALS.RAW_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.NONE, nONE, 0.2f);
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.Entombable = false;
            def1.ViewMode = OverlayModes.SolidConveyor.ID;
            def1.ObjectLayer = ObjectLayer.SolidConduit;
            def1.TileLayer = ObjectLayer.SolidConduitTile;
            def1.ReplacementLayer = ObjectLayer.ReplacementSolidConduit;
            def1.AudioCategory = "Metal";
            def1.AudioSize = "small";
            def1.BaseTimeUntilRepair = 0f;
            def1.UtilityInputOffset = new CellOffset(0, 0);
            def1.UtilityOutputOffset = new CellOffset(0, 0);
            def1.SceneLayer = Grid.SceneLayer.SolidConduits;
            def1.isKAnimTile = true;
            def1.isUtility = true;
            def1.DragBuild = true;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "LogisticRail");
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.GetComponent<Building>().Def.BuildingUnderConstruction.GetComponent<Constructable>().isDiggingRequired = false;
            KAnimGraphTileVisualizer local1 = go.AddComponent<KAnimGraphTileVisualizer>();
            local1.connectionSource = KAnimGraphTileVisualizer.ConnectionSource.Solid;
            local1.isPhysicalBuilding = true;
            LiquidConduitConfig.CommonConduitPostConfigureComplete(go);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            KAnimGraphTileVisualizer local1 = go.AddComponent<KAnimGraphTileVisualizer>();
            local1.connectionSource = KAnimGraphTileVisualizer.ConnectionSource.Solid;
            local1.isPhysicalBuilding = false;
        }
    }
}
