using TUNING;
using UnityEngine;

namespace WoodenSetFurniture
{
    public class SimpleFireplaceConfig : IBuildingConfig
    {
        public const string ID = "SimpleFireplace";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.AddOrGet<MassiveHeatSink>();
            go.AddOrGet<MinimumOperatingTemperature>().minimumTemperature = 100f;

            PrimaryElement component = go.GetComponent<PrimaryElement>();
            component.SetElement(SimHashes.Gold);
            component.Temperature = 294.15f;

            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 1000f;
            storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
            storage.showInUI = true;

            ManualDeliveryKG local1 = go.AddOrGet<ManualDeliveryKG>();
            local1.SetStorage(storage);
            local1.RequestedItemTag = WoodLogConfig.TAG;
            local1.capacity = 300f;
            local1.refillMass = 30f;
            local1.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;

            ElementConverter converter = go.AddOrGet<ElementConverter>();
            converter.consumedElements = new ElementConverter.ConsumedElement[] { new ElementConverter.ConsumedElement(WoodLogConfig.TAG, 0.1f) };
            converter.outputElements = new ElementConverter.OutputElement[] { new ElementConverter.OutputElement(0.015f, SimHashes.CarbonDioxide, 312.5f, false, false, 0f, 0.5f, 1f, 0xff, 0) };

            ElementConsumer local3 = go.AddOrGet<ElementConsumer>();
            local3.elementToConsume = SimHashes.Oxygen;
            local3.consumptionRate = 0.002f;
            local3.consumptionRadius = 3;
            local3.showInStatusPanel = true;
            local3.sampleCellOffset = new Vector3(0f, 1f, 0f);
            local3.isRequired = true;

            Prioritizable.AddRef(go);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues noise = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 2, 3, "simple_fireplace_kanim", 30, 90f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER5, MATERIALS.RAW_MINERALS, 1600f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.BONUS.TIER0, noise, 0.6f);
            def1.ThermalConductivity = 9.4f;
            def1.ExhaustKilowattsWhenActive = 18f;
            def1.SelfHeatKilowattsWhenActive = 6f;
            def1.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            def1.ViewMode = OverlayModes.Power.ID;
            def1.AudioCategory = "HollowMetal";
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LogicOperationalController>();
            go.AddOrGetDef<PoweredActiveController.Def>();
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
        }
    }

}

/*

*/
