using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Plant_CreamcapMushroomConfig : IEntityConfig
    {
        public const string Id = "Creamcap";
        public const string Name = "Creamcap Mushroom";
        public static string Description = "A soft white mushroom with a creamie texture on its cap. Despite growing in filthy dark spots, it is edible.";
        public static string DomesticatedDescription = (Description + "This domesticated Creamcap requires " + UI.FormatAsLink("Polluted Dirty", "TOXICSAND") + " as fertilizer.");
        public const string SeedId = "CreamcapSeed";
        public const string SeedName = "Creamcap Mushroom Spore";
        public static string SeedDescription = ("A small spore from the " + UI.FormatAsLink("Creamcap Mushroom", "Creamcap") + ". Plant it in a dark place and its surely to flourish.");
        public const float DefaultTemperature = 298.15f;
        public const float TemperatureLethalLow = 277.15f;
        public const float TemperatureWarningLow = 283.15f;
        public const float TemperatureWarningHigh = 309.15f;
        public const float TemperatureLethalHigh = 313.15f;
        public const float IrrigationRate = 0.03333334f;
        public static CuisinePlantsTuning.CropsTuning tuning = CuisinePlantsTuning.CreamcapTuning;
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            EffectorValues noise = new EffectorValues();
            GameObject template = EntityTemplates.CreatePlacedEntity("Creamcap", "Creamcap Mushroom", Description, 1f, Assets.GetAnim("creamcap_kanim"), "idle_empty", Grid.SceneLayer.BuildingFront, 1, 2, TUNING.DECOR.BONUS.TIER1, noise, SimHashes.Creature, null, 298.15f);
            SimHashes[] hashesArray1 = new SimHashes[] { SimHashes.Oxygen, SimHashes.CarbonDioxide };
            EntityTemplates.ExtendEntityToBasicPlant(template, 277.15f, 283.15f, 309.15f, 313.15f, hashesArray1, true, 0f, 0.15f, "Creamtop_Cap", true, true, true, true, 2400f, 0f, 220f, "CreamcapOriginal", "Creamcap Mushroom");
            PlantElementAbsorber.ConsumeInfo info = new PlantElementAbsorber.ConsumeInfo {
                tag = SimHashes.DirtyWater.CreateTag(),
                massConsumptionRate = 0.03333334f
            };
            EntityTemplates.ExtendPlantToIrrigated(template, info);
            template.AddOrGet<IlluminationVulnerable>().SetPrefersDarkness(true);
            template.AddOrGet<StandardCropPlant>();
            List<Tag> additionalTags = new List<Tag>();
            additionalTags.Add(GameTags.CropSeed);
            Tag replantGroundTag = new Tag();
            EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(template, SeedProducer.ProductionType.Harvest, "CreamcapSeed", "Creamcap Mushroom Spore", SeedDescription, Assets.GetAnim("seed_creamcap_kanim"), "object", 1, additionalTags, SingleEntityReceptacle.ReceptacleDirection.Top, replantGroundTag, 2, DomesticatedDescription, EntityTemplates.CollisionShape.CIRCLE, 0.2f, 0.2f, null, "", false), "Creamcap_preview", Assets.GetAnim("creamcap_kanim"), "place", 1, 1);
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MushroomSeed", 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("CreamcapSeed", 1f) };
            string id = ComplexRecipeManager.MakeRecipeID("Kiln", inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0);
            recipe1.time = FOOD.RECIPES.SMALL_COOK_TIME;
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

