using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Plant_SunnyWheatConfig : IEntityConfig
    {
        public const string Id = "SunnyWheat";
        public const string Name = "Sunny Wheat";
        public static string Description = ("A vibrant wheat that grows in temperate and hot biomes. It produces " + UI.FormatAsLink("Sunny Wheat Grain", "SunnyWheat_Grain") + ", a warm grain that can be processed in to food.");
        public static string DomesticatedDescription;
        public const string SeedId = "SunnyWheatSeed";
        public const string SeedName = "Sunny Wheat Bulb";
        public static string SeedDescription;
        public const float DefaultTemperature = 321.15f;
        public const float TemperatureLethalLow = 273.15f;
        public const float TemperatureWarningLow = 313.15f;
        public const float TemperatureWarningHigh = 343.15f;
        public const float TemperatureLethalHigh = 348.15f;
        public const float IrrigationRate_A = 0.015f;
        public const float IrrigationRate_B = 0.04f;
        public static CuisinePlantsTuning.CropsTuning tuning;
        public ComplexRecipe Recipe;

        static Plant_SunnyWheatConfig()
        {
            string[] textArray1 = new string[] { Description, "/n/n This domesticated wheat require little ", UI.FormatAsLink("Water", "WATER"), ". Also require ", UI.FormatAsLink("Sand", "SAND"), " as fertilizer." };
            DomesticatedDescription = string.Concat(textArray1);
            SeedDescription = "The bulb of a " + UI.FormatAsLink("Sunny Wheat", "SunnyWheat") + ".";
            tuning = CuisinePlantsTuning.SunnyWheatTuning;
        }

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject template = EntityTemplates.CreatePlacedEntity("SunnyWheat", "Sunny Wheat", Description, 1f, Assets.GetAnim("sunnywheat_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 1, 1, TUNING.DECOR.BONUS.TIER1, noise, SimHashes.Creature, null, 321.15f);
            SimHashes[] hashesArray1 = new SimHashes[] { SimHashes.Oxygen, SimHashes.CarbonDioxide, SimHashes.ContaminatedOxygen, SimHashes.ChlorineGas };
            EntityTemplates.ExtendEntityToBasicPlant(template, 273.15f, 313.15f, 343.15f, 348.15f, hashesArray1, true, 0f, 0.15f, "SunnyWheat_Grain", true, true, true, true, 2400f, 0f, 220f, "SunnyWheatOriginal", "Sunny Wheat");
            PlantElementAbsorber.ConsumeInfo info2 = new PlantElementAbsorber.ConsumeInfo {
                tag = GameTags.Water,
                massConsumptionRate = 0.015f
            };
            EntityTemplates.ExtendPlantToIrrigated(template, info2);
            info2 = new PlantElementAbsorber.ConsumeInfo {
                tag = SimHashes.Sand.CreateTag(),
                massConsumptionRate = 0.04f
            };
            PlantElementAbsorber.ConsumeInfo info = info2;
            PlantElementAbsorber.ConsumeInfo[] fertilizers = new PlantElementAbsorber.ConsumeInfo[] { info };
            EntityTemplates.ExtendPlantToFertilizable(template, fertilizers);
            template.AddOrGet<StandardCropPlant>();
            List<Tag> additionalTags = new List<Tag>();
            additionalTags.Add(GameTags.CropSeed);
            Tag replantGroundTag = new Tag();
            EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(template, SeedProducer.ProductionType.Harvest, "SunnyWheatSeed", "Sunny Wheat Bulb", SeedDescription, Assets.GetAnim("seed_sunnywheat_kanim"), "object", 1, additionalTags, SingleEntityReceptacle.ReceptacleDirection.Top, replantGroundTag, 2, DomesticatedDescription, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, null, "", false), "SunnyWheat_preview", Assets.GetAnim("sunnywheat_kanim"), "place", 1, 1);
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("ColdWheatSeed", 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("SunnyWheatSeed", 1f) };
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
            CuisinePlantsTuning.SupportedVersions;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}

