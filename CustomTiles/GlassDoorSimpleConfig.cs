namespace CustomTiles
{
    using STRINGS;
    using System;
    using System.Collections.Generic;
    using TUNING;
    using UnityEngine;

    class GlassDoorSimpleConfig : IBuildingConfig
    {
        public const string ID = "GlassDoorSimple";

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 100, 25f };
            string[] textArray1 = new string[] { "RefinedMetal", "Transparent" };
            EffectorValues nONE = TUNING.NOISE_POLLUTION.NONE;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef("GlassDoorSimple", 1, 2, "glass_door_simple_kanim", 30, 10f, singleArray1, textArray1, 1600f, BuildLocationRule.Tile, TUNING.BUILDINGS.DECOR.BONUS.TIER1, nONE, 1f);
            def1.Entombable = true;
            def1.Floodable = false;
            def1.IsFoundation = false;
            def1.AudioCategory = "Metal";
            def1.PermittedRotations = PermittedRotations.R90;
            def1.ForegroundLayer = Grid.SceneLayer.InteriorWall;
            def1.LogicInputPorts = CreateSingleInputPortList(new CellOffset(0, 0));
            SoundEventVolumeCache.instance.AddVolume("door_external_kanim", "Open_DoorPressure", NOISE_POLLUTION.NOISY.TIER2);
            SoundEventVolumeCache.instance.AddVolume("door_external_kanim", "Close_DoorPressure", NOISE_POLLUTION.NOISY.TIER2);
            return def1;
        }

        public static List<LogicPorts.Port> CreateSingleInputPortList(CellOffset offset)
        {
            List<LogicPorts.Port> list1 = new List<LogicPorts.Port>();
            list1.Add(LogicPorts.Port.InputPort(Door.OPEN_CLOSE_PORT_ID, offset, (string)STRINGS.BUILDINGS.PREFABS.DOOR.LOGIC_OPEN, (string)STRINGS.BUILDINGS.PREFABS.DOOR.LOGIC_OPEN_ACTIVE, (string)STRINGS.BUILDINGS.PREFABS.DOOR.LOGIC_OPEN_INACTIVE, false, false));
            return list1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Door local1 = go.AddOrGet<Door>();
            local1.unpoweredAnimSpeed = 1f;
            local1.doorType = Door.DoorType.Internal;
            local1.doorOpeningSoundEventName = "Open_DoorInternal";
            local1.doorClosingSoundEventName = "Close_DoorInternal";
            go.AddOrGet<AccessControl>().controlEnabled = true;
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = GameTags.Door;
            go.AddOrGet<Workable>().workTime = 3f;
            go.GetComponent<KBatchedAnimController>().initialAnim = "closed";
            go.AddOrGet<ZoneTile>();
            go.AddOrGet<KBoxCollider2D>();
            Prioritizable.AddRef(go);
            UnityEngine.Object.DestroyImmediate(go.GetComponent<BuildingEnabledButton>());
        }
    }
}
