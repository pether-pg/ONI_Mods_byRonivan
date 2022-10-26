using UnityEngine;
using TUNING;

namespace WoodenSetFurniture
{
    public class CozyBedConfig : IBuildingConfig
    {
        public static string ID = "CozyBed";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.BedType, false);
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LuxuryBedType, false);
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 120f, 200f, 40 };
            string[] textArray1 = new string[] { "RefinedMetal", "BuildingWood", "BuildingFiber" };

            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef(ID, 4, 2, "cozy_bed_kanim", 10, 10f, singleArray1, textArray1, 1600f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.BONUS.TIER2, nONE, 0.3f);
            def1.Overheatable = false;
            def1.AudioCategory = "Metal";
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.GetComponent<KAnimControllerBase>().initialAnim = "off";
            Bed bed = go.AddOrGet<Bed>();
            bed.effects = new string[] { "LuxuryBedStamina", "BedHealth" };
            bed.workLayer = Grid.SceneLayer.BuildingFront;
            Sleepable sleepable = go.AddOrGet<Sleepable>();
            sleepable.overrideAnims = new KAnimFile[] { Assets.GetAnim("anim_sleep_bed_kanim") };
            sleepable.workLayer = Grid.SceneLayer.BuildingFront;
            go.AddOrGet<Ownable>().slotID = Db.Get().AssignableSlots.Bed.Id;
        }
    }
}
