using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace WoodenSetFurniture
{
    public class WoodenPedestalConfig : IBuildingConfig
    {
        public const string ID = "WoodenPedestal";

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 20f, 250f };
            string[] textArray1 = new string[] { "RefinedMetal", "BuildingWood" };
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "wooden_pedestal_kanim", 10, 30f, singleArray1, textArray1, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.BONUS.TIER1, none, 0.2f);
            def1.DefaultAnimState = "pedestal";
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.ViewMode = OverlayModes.Decor.ID;
            def1.AudioCategory = "Glass";
            def1.AudioSize = "small";
            return def1;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            Storage.StoredItemModifier[] collection = new Storage.StoredItemModifier[] { Storage.StoredItemModifier.Seal, Storage.StoredItemModifier.Preserve };
            go.AddOrGet<Storage>().SetDefaultStoredItemModifiers(new List<Storage.StoredItemModifier>(collection));
            Prioritizable.AddRef(go);
            SingleEntityReceptacle local1 = go.AddOrGet<SingleEntityReceptacle>();
            local1.AddDepositTag(GameTags.PedestalDisplayable);
            local1.occupyingObjectRelativePosition = new Vector3(0f, 1.2f, -1f);
            go.AddOrGet<DecorProvider>();
            go.AddOrGet<ItemPedestal>();
            go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration, false);

        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
    }


}

