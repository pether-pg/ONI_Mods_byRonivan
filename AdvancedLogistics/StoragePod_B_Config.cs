using STRINGS;
using System;
using System.Collections.Generic;
using PeterHan.PLib.Options;
using TUNING;
using UnityEngine;

namespace AdvancedLogistics
{
    public class StoragePod_B_Config : IBuildingConfig
    {
        public const string ID = "StoragePod_B";
        public const string DisplayName = "Brown Storage Pod";
        public const string Description = "Store solids and other industrial materials.";
        public static string Effect = string.Concat(new string[]
        { "A versatile and convenient storage pod that can be built on walls. Store the ",
          UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID"),
          " of your choosing. The pod prevents temperature exchange with the environment, as well gas leakage."});

        private static readonly List<Storage.StoredItemModifier> StoragePodItemModifiers;
        static StoragePod_B_Config()
        {
            List<Storage.StoredItemModifier> list1 = new List<Storage.StoredItemModifier>();
            list1.Add(Storage.StoredItemModifier.Hide);
            list1.Add(Storage.StoredItemModifier.Preserve);
            list1.Add(Storage.StoredItemModifier.Insulate);
            list1.Add(Storage.StoredItemModifier.Seal);
            StoragePodItemModifiers = list1;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            go.AddOrGet<Automatable>();
            Storage storage = go.AddOrGet<Storage>();
            storage.SetDefaultStoredItemModifiers(StoragePodItemModifiers);
            storage.showInUI = true;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.NOT_EDIBLE_SOLIDS;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            storage.showCapacityStatusItem = true;
            storage.showCapacityAsMainStatus = true;
            storage.capacityKg = (float)SingletonOptions<ModSettings>.Instance.Capacity_StoragePod_B;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
            go.AddOrGet<StorageLocker>();
            go.AddOrGet<UserNameable>();
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def = BuildingTemplates.CreateBuildingDef("StoragePod_B", 1, 1, "storage_pod_b_kanim", 30, 10f, TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, TUNING.BUILDINGS.DECOR.PENALTY.TIER1, nONE, 0.2f);
            def.Floodable = false;
            def.AudioCategory = "Metal";
            def.Overheatable = false;
            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }
    }
}
