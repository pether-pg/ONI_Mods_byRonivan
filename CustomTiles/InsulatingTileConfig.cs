namespace CustomTiles
{
    using System;
    using TUNING;
    using UnityEngine;
    using System.IO;

    public class InsulatingTileConfig : IBuildingConfig
    {
        public const string ID = "InsulatingTile";

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            SimCellOccupier occupier = go.AddOrGet<SimCellOccupier>();
            occupier.doReplaceElement = true;
            occupier.notifyOnMelt = true;
            go.AddOrGet<Insulator>();
            go.AddOrGet<TileTemperature>();
            go.AddOrGet<KAnimGridTileVisualizer>().blockTileConnectorID = TileConfig.BlockTileConnectorID;
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
            BuildingDef def = BuildingTemplates.CreateBuildingDef("InsulatingTile", 1, 1, "floor_insulating_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.RAW_MINERALS, 1600f, BuildLocationRule.Tile, BUILDINGS.DECOR.PENALTY.TIER0, nONE, 0.2f);
            BuildingTemplates.CreateFoundationTileDef(def);
            def.ThermalConductivity = 0.01f;
            def.Floodable = false;
            def.Overheatable = false;
            def.Entombable = false;
            def.UseStructureTemperature = false;
            def.AudioCategory = "Metal";
            def.AudioSize = "small";
            def.BaseTimeUntilRepair = -1f;
            def.SceneLayer = Grid.SceneLayer.TileMain;
            def.isKAnimTile = true;

            def.BlockTileMaterial = Assets.GetMaterial("tiles_solid");
            def.BlockTileAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_insulating"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            def.BlockTilePlaceAtlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_insulating_place"), base.GetType(), Assets.GetTextureAtlas("tiles_solid"));
            BlockTileDecorInfo info = UnityEngine.Object.Instantiate<BlockTileDecorInfo>(Assets.GetBlockTileDecorInfo("tiles_bunker_tops_decor_info"));
            info.atlas = GetCustomAtlas(System.IO.Path.Combine(System.IO.Path.Combine("anim", "assets"), "tiles_insulating_tops"), base.GetType(), info.atlas);
            def.DecorBlockTileInfo = info;
            def.DecorPlaceBlockTileInfo = Assets.GetBlockTileDecorInfo("tiles_bunker_tops_decor_place_info");
            def.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;
            def.DragBuild = true;

            return def;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.GetComponent<KPrefabID>().AddTag(GameTags.FloorTiles, false);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.AddOrGet<KAnimGridTileVisualizer>();
        }
    }
}
