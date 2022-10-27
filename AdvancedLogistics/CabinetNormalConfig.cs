using STRINGS;
using System;
using System.Collections.Generic;
using PeterHan.PLib.Options;
using TUNING;
using UnityEngine;
using BUILDINGS = TUNING.BUILDINGS;

namespace AdvancedLogistics
{
    public class CabinetNormalConfig : IBuildingConfig
    {
        public const string ID = "CabinetNormal";
        public const string DisplayName = "Storage Cabinet";
        public const string Description = "Store solids and other industrial materials.";
        public static string Effect = string.Concat(new string[]
        { "Store the ",
          UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID"),
          " of your choosing. The cabinet prevents temperature exchange with the environment, as well gas leakage."});

        private static readonly List<Storage.StoredItemModifier> Cabinet_Normal_ItemModifiers;
        static CabinetNormalConfig()
        {
            List<Storage.StoredItemModifier> list1 = new List<Storage.StoredItemModifier>();
            list1.Add(Storage.StoredItemModifier.Hide);
            list1.Add(Storage.StoredItemModifier.Preserve);
            list1.Add(Storage.StoredItemModifier.Insulate);
            list1.Add(Storage.StoredItemModifier.Seal);
            Cabinet_Normal_ItemModifiers = list1;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            SoundEventVolumeCache.instance.AddVolume("storagelocker_kanim", "StorageLocker_Hit_metallic_low", NOISE_POLLUTION.NOISY.TIER1);
            Prioritizable.AddRef(go);
            go.AddOrGet<Automatable>();
            Storage storage = go.AddOrGet<Storage>();
            storage.SetDefaultStoredItemModifiers(Cabinet_Normal_ItemModifiers);
            storage.showInUI = true;
            storage.allowItemRemoval = true;
            storage.showDescriptor = true;
            storage.storageFilters = STORAGEFILTERS.NOT_EDIBLE_SOLIDS;
            storage.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
            storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
            storage.showCapacityStatusItem = true;
            storage.showCapacityAsMainStatus = true;
            storage.capacityKg = (float)SingletonOptions<ModSettings>.Instance.Capacity_CabinetNormal;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.StorageLocker;
            go.AddOrGet<StorageLocker>();
            go.AddOrGet<UserNameable>();
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "cabinet_normal_kanim", 30, 10f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER1, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.OnFloor, TUNING.BUILDINGS.DECOR.PENALTY.TIER1, nONE, 0.2f);
            def1.Floodable = false;
            def1.AudioCategory = "Metal";
            def1.Overheatable = false;
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<StorageController.Def>();
        }
    }
}
