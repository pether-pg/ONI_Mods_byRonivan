namespace CustomTiles
{
    using System;
    using TUNING;
    using UnityEngine;

    public class CementMixerConfig : IBuildingConfig
    {

        public const string ID = "CementMixer";
        private void ConfgiureRecipes() { }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            go.AddOrGet<DropAllWorkable>();
            go.AddOrGet<BuildingComplete>().isManuallyOperated = true;

            ComplexFabricatorWorkable workable = go.AddOrGet<ComplexFabricatorWorkable>();
            workable.overrideAnims = new KAnimFile[] { Assets.GetAnim("anim_interacts_metalrefinery_kanim") };
            go.AddOrGet<LoopingSounds>();

            ComplexFabricator complexFabricator = go.AddOrGet<ComplexFabricator>();
            complexFabricator.heatedTemperature = 298.15f;
            complexFabricator.duplicantOperated = true;
            complexFabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();
            BuildingTemplates.CreateComplexFabricatorStorage(go, complexFabricator);
            this.ConfgiureRecipes();
            Prioritizable.AddRef(go);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER5;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("CementMixer", 2, 2, "cement_mixer_kanim", 100, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, tier, 0.2f);
            buildingDef.Overheatable = false;
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 120f;
            buildingDef.ExhaustKilowattsWhenActive = 16f;
            buildingDef.SelfHeatKilowattsWhenActive = 4f;
            buildingDef.AudioCategory = "HollowMetal";
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<PoweredActiveController.Def>().showWorkingStatus = true;
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            base.DoPostConfigurePreview(def, go);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
        }
    }
}
