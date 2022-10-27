using STRINGS;
using System;
using System.Collections.Generic;
using PeterHan.PLib.Options;
using TUNING;
using UnityEngine;
using BUILDINGS = TUNING.BUILDINGS;

namespace AdvancedLogistics
{
    public class CabinetFrozenConfig : IBuildingConfig
    {
        public const string ID = "CabinetFrozen";
        public const string DisplayName = "Refrigerated Storage Cabinet";
        public const string Description = "Store solids and other industrial materials at a constant temperature moderation.";
        public static string Effect = string.Concat(new string[] 
        { "Store the ",
          UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID"),
          " of your choosing.\n\nConsumes ",
          UI.FormatAsLink("Power", "POWER"),
          " to refrigrate the contents down to 24°C.\n\nCannot store",
          " any liquefiable solids." });

        private static readonly List<Storage.StoredItemModifier> CabinetFrozen_ItemModifiers;
        static CabinetFrozenConfig()
        {
            List<Storage.StoredItemModifier> list1 = new List<Storage.StoredItemModifier>();
            list1.Add(Storage.StoredItemModifier.Hide);
            list1.Add(Storage.StoredItemModifier.Preserve);
            list1.Add(Storage.StoredItemModifier.Seal);
            CabinetFrozen_ItemModifiers = list1;
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = TUNING.NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "cabinet_frozen_kanim", 30, 60f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER1, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.OnFloor, TUNING.BUILDINGS.DECOR.PENALTY.TIER1, nONE, 0.2f);
            def1.Floodable = false;
            def1.AudioCategory = "Metal";
            def1.Overheatable = false;
            def1.ViewMode = OverlayModes.Logic.ID;
            def1.RequiresPowerInput = true;
            def1.AddLogicPowerPort = false;
            def1.EnergyConsumptionWhenActive = 240f;
            def1.ExhaustKilowattsWhenActive = 0.125f;
            List<LogicPorts.Port> list1 = new List<LogicPorts.Port>();
            list1.Add(LogicPorts.Port.OutputPort(FilteredStorage.FULL_PORT_ID, new CellOffset(0, 1), (string)STRINGS.BUILDINGS.PREFABS.STORAGELOCKERSMART.LOGIC_PORT, (string)STRINGS.BUILDINGS.PREFABS.STORAGELOCKERSMART.LOGIC_PORT_ACTIVE, (string)STRINGS.BUILDINGS.PREFABS.STORAGELOCKERSMART.LOGIC_PORT_INACTIVE, true, false));
            def1.LogicOutputPorts = list1;
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", TUNING.NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            go.AddOrGet<Automatable>();
            Storage storage = go.AddOrGet<Storage>();
            storage.SetDefaultStoredItemModifiers(CabinetFrozen_ItemModifiers);
            storage.showInUI = true;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.storageFilters = CUSTOMSTORAGEFILTERS.NOT_LIQUEFIABLE_SOLIDS;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            storage.showCapacityStatusItem = true;
            storage.showCapacityAsMainStatus = true;
            storage.capacityKg = (float)SingletonOptions<ModSettings>.Instance.Capacity_CabinetFrozen;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
            go.AddOrGet<StorageLocker>();
            go.AddOrGet<UserNameable>();
            go.AddOrGet<Refrigerator>();
            go.AddOrGet<FoodStorage>();
            RefrigeratorController.Def local2 = go.AddOrGetDef<RefrigeratorController.Def>();
            local2.powerSaverEnergyUsage = 20f;
            local2.coolingHeatKW = 0.375f;
            local2.steadyHeatKW = 0f;
            local2.simulatedInternalTemperature = 297.15f;
            local2.simulatedThermalConductivity = 10000f;
        }
    }
}
