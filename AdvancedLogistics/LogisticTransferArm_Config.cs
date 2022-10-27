using System;
using TUNING;
using UnityEngine;
using STRINGS;
using PeterHan.PLib.Options;
using BUILDINGS = TUNING.BUILDINGS;

namespace AdvancedLogistics
{
    public class LogisticTransferArmConfig : IBuildingConfig
    {
        public const string ID = "LogisticTransferArm";
        public const string DisplayName = "Logistic Auto-Sweeper";
        public const string Description = "An auto-sweeper's range can be viewed at any time by clicking on the building.";
        public static string Effect = string.Concat(new string[]
                {
                    "Automates ",
                    UI.FormatAsLink("Sweeping", "CHORES"),
                    " and ",
                    UI.FormatAsLink("Supplying", "CHORES"),
                    " errands by sucking up all nearby ",
                    UI.FormatAsLink("Debris", "DECOR"),
                    ".\n\nMaterials are automatically delivered to any ",
                    UI.FormatAsLink("Conveyor Loader", "SOLIDCONDUITINBOX"),
                    ", ",
                    UI.FormatAsLink("Conveyor Receptacle", "SOLIDCONDUITOUTBOX"),
                    ", storage, or buildings within range."
                });

        private static void AddVisualizer(GameObject prefab, bool movable)
        {
            StationaryChoreRangeVisualizer local1 = prefab.AddOrGet<StationaryChoreRangeVisualizer>();
            local1.x = -(int)SingletonOptions<ModSettings>.Instance.Range_AutoSweeper;
            local1.y = -(int)SingletonOptions<ModSettings>.Instance.Range_AutoSweeper;
            local1.width = ((int)SingletonOptions<ModSettings>.Instance.Range_AutoSweeper * 2)+1;
            local1.height = ((int)SingletonOptions<ModSettings>.Instance.Range_AutoSweeper * 2) + 1;
            local1.movable = movable;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<Operational>();
            go.AddOrGet<LoopingSounds>();
        }

        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 3, 1, "logistic_transferArm_kanim", 10, 10f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER2, NOISE_POLLUTION.NOISY.TIER0, 0.2f);
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.AudioCategory = "Metal";
            def1.RequiresPowerInput = true;
            def1.EnergyConsumptionWhenActive = 20f;
            def1.ExhaustKilowattsWhenActive = 0f;
            def1.SelfHeatKilowattsWhenActive = 2f;
            def1.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            def1.PermittedRotations = PermittedRotations.R360;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "LogisticTransferArm");
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGet<SolidTransferArm>().pickupRange = (int)SingletonOptions<ModSettings>.Instance.Range_AutoSweeper;
            AddVisualizer(go, false);
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            AddVisualizer(go, true);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            AddVisualizer(go, false);
        }
    }

}
