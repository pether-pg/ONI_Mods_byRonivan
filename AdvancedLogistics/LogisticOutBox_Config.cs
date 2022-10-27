using System;
using TUNING;
using UnityEngine;
using STRINGS;
using PeterHan.PLib.Options;
using BUILDINGS = TUNING.BUILDINGS;

namespace AdvancedLogistics
{
    public class LogisticOutBoxConfig : IBuildingConfig
    {
        public const string ID = "LogisticOutBox";
        public const string DisplayName = "Logistic Receptacle";
        public const string Description = "When materials reach the end of a rail they enter a receptacle to be used by Duplicants.";
        public static string Effect = string.Concat(new string[]
                {
                    "Unloads large amounts of ",
                    UI.FormatAsLink("Solid Materials", "ELEMENTS_SOLID"),
                    " from a ",
                    UI.FormatAsLink("Conveyor Rail", "SOLIDCONDUIT"),
                    " into storage."
                });

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            go.AddOrGet<SolidConduitOutbox>();
            go.AddOrGet<SolidConduitConsumer>();
            Storage storage1 = BuildingTemplates.CreateDefaultStorage(go, false);
            storage1.capacityKg = (float)SingletonOptions<ModSettings>.Instance.Capacity_LogisticOutBox;
            storage1.showInUI = true;
            storage1.allowItemRemoval = true;
            go.AddOrGet<SimpleVent>();
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 1, 2, "logistic_outbox_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.ALL_METALS, 1600f, BuildLocationRule.Anywhere, BUILDINGS.DECOR.PENALTY.TIER1, nONE, 0.2f);
            def1.Floodable = false;
            def1.Overheatable = false;
            def1.ViewMode = OverlayModes.SolidConveyor.ID;
            def1.AudioCategory = "Metal";
            def1.InputConduitType = ConduitType.Solid;
            def1.UtilityInputOffset = new CellOffset(0, 0);
            def1.PermittedRotations = PermittedRotations.R360;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "LogisticOutBox");
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Prioritizable.AddRef(go);
            go.AddOrGet<Automatable>();
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
        }
    }


}
