using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    internal class Plant_KakawaTreeConfig : IEntityConfig
    {
        public const string Id = "KakawaTree";
        public const string Name = "Kakawa Tree";
        public static string Description = ("A lush, golden leafed tree that grows in temperate forest biomes. It produces a rock hard edible " + UI.FormatAsLink("Kakawa Acorn", "Kakawa_Acorn") + ".");
        public static string DomesticatedDescription;
        public const string SeedId = "KakawaTreeSeed";
        public const string SeedName = "Kakawa Tree Sprout";
        public static string SeedDescription;
        public const float DefaultTemperature = 305.15f;
        public const float TemperatureLethalLow = 273.15f;
        public const float TemperatureWarningLow = 283.15f;
        public const float TemperatureWarningHigh = 313.15f;
        public const float TemperatureLethalHigh = 321.15f;
        public const float IrrigationRate_A = 0.04f;
        public const float IrrigationRate_B = 0.02f;
        public static CuisinePlantsTuning.CropsTuning tuning;
        public ComplexRecipe Recipe;

        static Plant_KakawaTreeConfig()
        {
            string[] textArray1 = new string[] { Description, "/n/n This domesticated tree requires copious amounts of ", UI.FormatAsLink("Water", "WATER"), ", and ", UI.FormatAsLink("Dirt", "DIRT"), " as fertilizer." };
            DomesticatedDescription = string.Concat(textArray1);
            SeedDescription = "The Sprout of a " + UI.FormatAsLink("Kakawa Tree", "KakawaTree") + ".";
            tuning = CuisinePlantsTuning.OakTreeTuning;
        }

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject template = EntityTemplates.CreatePlacedEntity("KakawaTree", "Kakawa Tree", Description, 1f, Assets.GetAnim("kakawatree_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 3, 3, TUNING.DECOR.BONUS.TIER1, noise, SimHashes.Creature, null, 305.15f);
            SimHashes[] hashesArray1 = new SimHashes[] { SimHashes.Oxygen, SimHashes.CarbonDioxide, SimHashes.ContaminatedOxygen };
            EntityTemplates.ExtendEntityToBasicPlant(template, 273.15f, 283.15f, 313.15f, 321.15f, hashesArray1, true, 0f, 0.15f, "Kakawa_Acorn", true, true, true, true, 2400f, 0f, 220f, "KakawaTreeOriginal", "Kakawa Tree");
            PlantElementAbsorber.ConsumeInfo info2 = new PlantElementAbsorber.ConsumeInfo {
                tag = GameTags.Water,
                massConsumptionRate = 0.04f
            };
            EntityTemplates.ExtendPlantToIrrigated(template, info2);
            info2 = new PlantElementAbsorber.ConsumeInfo {
                tag = SimHashes.Dirt.CreateTag(),
                massConsumptionRate = 0.02f
            };
            PlantElementAbsorber.ConsumeInfo info = info2;
            PlantElementAbsorber.ConsumeInfo[] fertilizers = new PlantElementAbsorber.ConsumeInfo[] { info };
            EntityTemplates.ExtendPlantToFertilizable(template, fertilizers);
            template.AddOrGet<StandardCropPlant>();
            List<Tag> additionalTags = new List<Tag>();
            additionalTags.Add(GameTags.CropSeed);
            Tag replantGroundTag = new Tag();
            EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(template, SeedProducer.ProductionType.Harvest, "KakawaTreeSeed", "Kakawa Tree Sprout", SeedDescription, Assets.GetAnim("seed_kakawatree_kanim"), "object", 1, additionalTags, SingleEntityReceptacle.ReceptacleDirection.Top, replantGroundTag, 2, DomesticatedDescription, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, null, "", false), "KakawaTree_preview", Assets.GetAnim("kakawatree_kanim"), "place", 3, 3);
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("ForestTreeSeed", 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("KakawaTreeSeed", 1f) };
            string id = ComplexRecipeManager.MakeRecipeID("Kiln", inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0);
            recipe1.time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME;
            recipe1.description = "Chemistry works in mysterious ways.";
            recipe1.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list2 = new List<Tag>();
            list2.Add("Kiln");
            recipe1.fabricators = list2;
            recipe1.sortOrder = 2;
            recipe1.requiredTech = null;
            this.Recipe = recipe1;
            SoundEventVolumeCache.instance.AddVolume("bristleblossom_kanim", "PrickleFlower_harvest", NOISE_POLLUTION.CREATURES.TIER1);
            return template;
        }

        public string[] GetDlcIds() => 
            DlcManager.AVAILABLE_ALL_VERSIONS;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}

