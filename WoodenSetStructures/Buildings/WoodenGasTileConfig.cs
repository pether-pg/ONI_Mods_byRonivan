using System;
using TUNING;
using UnityEngine;
using System.IO;

namespace WoodenSetStructures
{
    public class WoodenGasTileConfig : IBuildingConfig
    {
        public const string ID = "WoodenGasTile";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            SimCellOccupier local1 = go.AddOrGet<SimCellOccupier>();
            local1.setLiquidImpermeable = true;
            local1.doReplaceElement = false;
            go.AddOrGet<KAnimGridTileVisualizer>().blockTileConnectorID = MeshTileConfig.BlockTileConnectorID;
            go.AddOrGet<BuildingHP>().destroyOnDamaged = true;
            go.AddComponent<SimTemperatureTransfer>();
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
                //atlas.vertexScale = tileAtlas.vertexScale;
                atlas.items = tileAtlas.items;
            }
            return atlas;
        }

        public override BuildingDef CreateBuildingDef()
        {
            float[] singleArray1 = new float[] { 50f, 50f };
            string[] textArray1 = new string[] { "BuildableRaw", "BuildingWood" };

            EffectorValues nONE = NOISE_POLLUTION.NONE;
            BuildingDef def = BuildingTemplates.CreateBuildingDef(ID, 1, 1, "floor_Wooden_gasperm_kanim", 100, 30f, singleArray1, textArray1, 1600f, BuildLocationRule.Tile, BUILDINGS.DECOR.BONUS.TIER0, nONE, 0.2f);
            BuildingTemplates.CreateFoundationTileDef(def);
            def.Floodable = false;
            def.Entombable = false;
            def.Overheatable = false;
            def.AudioCategory = "Metal";
            def.AudioSize = "small";
            def.BaseTimeUntilRepair = -1f;
            def.SceneLayer = Grid.SceneLayer.TileMain;
            def.isKAnimTile = true;

            def.BlockTileAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_wooden_gasperm"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            def.BlockTilePlaceAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_wooden_gasperm_place"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            def.BlockTileMaterial = Assets.GetMaterial("tiles_solid");
            BlockTileDecorInfo info = UnityEngine.Object.Instantiate<BlockTileDecorInfo>(Assets.GetBlockTileDecorInfo("tiles_bunker_tops_decor_info"));
            info.atlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_wooden_tops"), base.GetType(), info.atlas);
            def.DecorBlockTileInfo = info;

            def.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;
            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddComponent<ZoneTile>();
            go.GetComponent<KPrefabID>().AddTag(GameTags.FloorTiles, false);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.AddOrGet<KAnimGridTileVisualizer>();
        }
    }
}