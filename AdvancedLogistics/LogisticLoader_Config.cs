using System;
using TUNING;
using UnityEngine;
using STRINGS;
using System.Collections.Generic;
using BUILDINGS = TUNING.BUILDINGS;

namespace AdvancedLogistics
{
    public class LogisticLoaderConfig : IBuildingConfig
    {
        public const string ID = "LogisticLoader";
        public const string DisplayName = "Logistic Loader";
        public const string Description = "Material filters can be used to determine what resources are sent down the rail.";
        public static string Effect = string.Concat(new string[]
                {
                    "Loads large amounts of ",
                    UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID"),
                    " onto ",
                    UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT"),
                    " for transport.\n\nOnly loads the resources of your choosing."
                });

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "logistic_loader_kanim", 100, 60f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER1, nONE, 0.2f);
            def1.RequiresPowerInput = true;
            def1.EnergyConsumptionWhenActive = 20f;
            def1.ExhaustKilowattsWhenActive = 0f;
            def1.SelfHeatKilowattsWhenActive = 0f;
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.ViewMode = OverlayModes.SolidConveyor.ID;
            def1.AudioCategory = "Metal";
            def1.OutputConduitType = ConduitType.Solid;
            def1.PowerInputOffset = new CellOffset(0, 1);
            def1.UtilityOutputOffset = new CellOffset(0, 0);
            def1.PermittedRotations = PermittedRotations.R360;
            def1.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 1));
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "LogisticLoader");
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            Prioritizable.AddRef(go);
            go.AddOrGet<EnergyConsumer>();
            go.AddOrGet<Automatable>();
            List<Tag> list = new List<Tag>();
            list.AddRange(STORAGEFILTERS.NOT_EDIBLE_SOLIDS);
            list.AddRange(STORAGEFILTERS.FOOD);
            list.AddRange(STORAGEFILTERS.LIQUIDS);
            list.AddRange(STORAGEFILTERS.GASES);
            Storage local1 = go.AddOrGet<Storage>();
            local1.capacityKg = 10000f;
            local1.showInUI = true;
            local1.showDescriptor = true;
            local1.storageFilters = list;
            local1.allowItemRemoval = false;
            local1.onlyTransferFromLowerPriority = true;
            go.AddOrGet<TreeFilterable>();
            go.AddOrGet<SolidConduitInbox>();
            go.AddOrGet<SolidConduitDispenser>();
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
        }
    }
}
