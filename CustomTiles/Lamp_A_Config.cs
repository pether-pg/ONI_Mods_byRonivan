namespace CustomTiles
{
    using System;
    using TUNING;
    using UnityEngine;

    class Lamp_A_Config : IBuildingConfig
    {
        public const string ID = "Lamp_A";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LightSource, false);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def = BuildingTemplates.CreateBuildingDef("Lamp_A", 1, 1, "ceilingLight_pretty_kanim", 10, 10f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER1, MATERIALS.REFINED_METALS, 800f, BuildLocationRule.OnCeiling, BUILDINGS.DECOR.BONUS.TIER1, nONE, 0.2f);
            def.RequiresPowerInput = true;
            def.EnergyConsumptionWhenActive = 10f;
            def.SelfHeatKilowattsWhenActive = 0.5f;
            def.ViewMode = OverlayModes.Light.ID;
            def.AudioCategory = "Metal";
            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<LoopingSounds>();
            Light2D light2d = go.AddOrGet<Light2D>();
            light2d.overlayColour = LIGHT2D.CEILINGLIGHT_OVERLAYCOLOR;
            light2d.Color = LIGHT2D.CEILINGLIGHT_COLOR;
            light2d.Range = 12f;
            light2d.Angle = 2.6f;
            light2d.Direction = LIGHT2D.CEILINGLIGHT_DIRECTION;
            light2d.Offset = LIGHT2D.CEILINGLIGHT_OFFSET;
            light2d.shape = global::LightShape.Cone;
            light2d.drawOverlay = true;
            light2d.Lux = 1800;
            go.AddOrGetDef<LightController.Def>();
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            LightShapePreview preview = go.AddComponent<LightShapePreview>();
            preview.lux = 1800;
            preview.radius = 8f;
            preview.shape = global::LightShape.Cone;
        }
    }
}
