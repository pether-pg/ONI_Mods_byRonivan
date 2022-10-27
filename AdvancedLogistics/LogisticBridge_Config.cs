using System;
using TUNING;
using UnityEngine;
using STRINGS;
using System.Collections.Generic;
using BUILDINGS = TUNING.BUILDINGS;

namespace AdvancedLogistics
{
    public class LogisticBridgeConfig : IBuildingConfig
    {
        public const string ID = "LogisticBridge";
        public const string DisplayName = "Logistic Solid Bridge";
        public const string Description = "Separating rail systems helps ensure materials go to the intended destinations.";
        public static string Effect = "Runs one " + UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT") + " section over another without joining them.\n\nCan be run through wall and floor tile.";

        private const ConduitType CONDUIT_TYPE = ConduitType.Solid;
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 3, 1, "logistic_bridge_kanim", 10, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER2, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Conduit, BUILDINGS.DECOR.NONE, nONE, 0.2f);
            def1.ObjectLayer = ObjectLayer.SolidConduitConnection;
            def1.SceneLayer = Grid.SceneLayer.SolidConduitBridges;
            def1.InputConduitType = ConduitType.Solid;
            def1.OutputConduitType = ConduitType.Solid;
            def1.Floodable = false;
            def1.Entombable = false;
            def1.Overheatable = false;
            def1.ViewMode = OverlayModes.SolidConveyor.ID;
            def1.AudioCategory = "Metal";
            def1.AudioSize = "small";
            def1.BaseTimeUntilRepair = -1f;
            def1.PermittedRotations = PermittedRotations.R360;
            def1.UtilityInputOffset = new CellOffset(-1, 0);
            def1.UtilityOutputOffset = new CellOffset(1, 0);
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "LogisticBridge");
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<SolidConduitBridge>();
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
        }
    }


}
