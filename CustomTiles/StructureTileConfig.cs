namespace CustomTiles
{
    using System;
    using TUNING;
    using UnityEngine;
    using System.IO;

    public class StructureTileConfig : IBuildingConfig
    {
        public const string ID = "StructureTile";
        public static readonly int BlockTileConnectorID = Hash.SDBMLower("tiles_metal_tops");

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<SimCellOccupier>().doReplaceElement = false;
            go.AddOrGet<TileTemperature>();
            go.AddOrGet<KAnimGridTileVisualizer>().blockTileConnectorID = BlockTileConnectorID;
            go.AddOrGet<BuildingHP>().destroyOnDamaged = true;
        }


        public static TextureAtlas GetCustomAtlas(string name, System.Type type, TextureAtlas tileAtlas)
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(type.Assembly.Location), name + ".png");
            TextureAtlas atlas = null;
            if (!File.Exists(path))
            {
                Debug.LogError("WOODEN: Could not load atlas image at path " + path + ".");
            }
            else
            {
                Texture2D tex = new Texture2D(2, 2);
                tex.LoadImage(File.ReadAllBytes(path));
                atlas = ScriptableObject.CreateInstance<TextureAtlas>();
                atlas.texture = tex;
                atlas.items = tileAtlas.items;
            }
            return atlas;
        }


        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def = BuildingTemplates.CreateBuildingDef("StructureTile", 1, 1, "floor_structure_kanim", 100, 5f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER2, MATERIALS.REFINED_METALS, 800f, BuildLocationRule.Tile, BUILDINGS.DECOR.BONUS.TIER2, nONE, 0.2f);
            BuildingTemplates.CreateFoundationTileDef(def);
            def.Floodable = false;
            def.Entombable = false;
            def.Overheatable = false;
            def.UseStructureTemperature = false;
            def.AudioCategory = "Metal";
            def.AudioSize = "small";
            def.BaseTimeUntilRepair = -1f;
            def.SceneLayer = Grid.SceneLayer.TileMain;
            def.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;
            def.isKAnimTile = true;

            def.BlockTileMaterial = Assets.GetMaterial("tiles_solid");
            def.BlockTileAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_structure"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            def.BlockTilePlaceAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_structure_place"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            BlockTileDecorInfo info = UnityEngine.Object.Instantiate<BlockTileDecorInfo>(Assets.GetBlockTileDecorInfo("tiles_metal_tops_decor_info"));
            info.atlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_structure_tops"), base.GetType(), info.atlas);
            def.DecorBlockTileInfo = info;
            def.DecorPlaceBlockTileInfo = Assets.GetBlockTileDecorInfo("tiles_metal_tops_decor_place_info");

            def.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;

            def.DragBuild = true;
            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            GeneratedBuildings.RemoveLoopingSounds(go);
            go.GetComponent<KPrefabID>().AddTag(GameTags.FloorTiles, false);
            go.AddComponent<SimTemperatureTransfer>();
            go.AddComponent<ZoneTile>();
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.AddOrGet<KAnimGridTileVisualizer>();
        }

    }
}
