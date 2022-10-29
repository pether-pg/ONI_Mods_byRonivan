using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class ManualJuicerConfig : IBuildingConfig
    {
        public const string ID = "ManualJuicer";
        private Tag FUEL_TAG = SimHashes.Water.CreateTag();

        private static readonly List<Storage.StoredItemModifier> GrinderStoredItemModifiers = new List<Storage.StoredItemModifier>
        {
            Storage.StoredItemModifier.Hide,
            Storage.StoredItemModifier.Preserve,
            Storage.StoredItemModifier.Insulate,
            Storage.StoredItemModifier.Seal
        };


        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<DropAllWorkable>();
            go.AddOrGet<BuildingComplete>().isManuallyOperated = false;
            ManualJuicerStation manualJuicerStation = go.AddOrGet<ManualJuicerStation>();
            manualJuicerStation.heatedTemperature = 298.15f;
            manualJuicerStation.duplicantOperated = false;
            manualJuicerStation.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();
            go.AddOrGet<ComplexFabricatorWorkable>();
            BuildingTemplates.CreateComplexFabricatorStorage(go, manualJuicerStation);
            manualJuicerStation.fuelTag = this.FUEL_TAG;
            manualJuicerStation.inStorage.SetDefaultStoredItemModifiers(ManualJuicerConfig.GrinderStoredItemModifiers);
            manualJuicerStation.buildStorage.SetDefaultStoredItemModifiers(ManualJuicerConfig.GrinderStoredItemModifiers);
            manualJuicerStation.outStorage.SetDefaultStoredItemModifiers(ManualJuicerConfig.GrinderStoredItemModifiers);
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.capacityTag = this.FUEL_TAG;
            conduitConsumer.capacityKG = 10f;
            conduitConsumer.alwaysConsume = true;
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            conduitConsumer.storage = manualJuicerStation.inStorage;
            conduitConsumer.forceAlwaysSatisfied = true;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(this.FUEL_TAG, 2f)
            };
            this.ConfigureRecipes();
            Prioritizable.AddRef(go);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues none = NOISE_POLLUTION.NONE;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("ManualJuicer", 2, 3, "manual_juicer_kanim", 100, 10f, TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.RAW_MINERALS, 1600f, BuildLocationRule.OnFloor, TUNING.BUILDINGS.DECOR.NONE, none, 0.2f);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.Floodable = false;
            buildingDef.Entombable = true;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 90f;
            buildingDef.ExhaustKilowattsWhenActive = 0.5f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(0, 0);
            buildingDef.ShowInBuildMenu = true;
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }

        private void ConfigureRecipes()
        {
            string str = UI.FormatAsLink("Nosh Beans", "BEAN");
            ComplexRecipe.RecipeElement[] ingredients = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("BeanPlantSeed", 2f) };
            ComplexRecipe.RecipeElement[] results = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("NoshMilk".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false) };
            ComplexRecipe recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("ManualJuicer", ingredients, results), ingredients, results, 0)
            {
                time = 25f
            };
            string[] textArray1 = new string[] { "Grind down ", str, " to a pulp, and produce fresh Nosh Milk." };
            recipe.description = string.Format(string.Concat(textArray1), str);
            recipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list = new List<Tag> { "ManualJuicer" };
            recipe.fabricators = list;
            recipe.sortOrder = 1;
            Food_NoshMilkConfig.recipe = recipe;
            string str2 = UI.FormatAsLink("Meal Lice", "BASICPLANTFOOD");
            ComplexRecipe.RecipeElement[] elementArray3 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("BasicPlantFood", 2f) };
            ComplexRecipe.RecipeElement[] elementArray4 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MealSlurry".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false) };
            ComplexRecipe recipe2 = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("ManualJuicer", elementArray3, elementArray4), elementArray3, elementArray4, 0)
            {
                time = 25f
            };
            string[] textArray2 = new string[] { "Grind down ", str2, " to a pulp, and produce sticky Meal Batter." };
            recipe2.description = string.Format(string.Concat(textArray2), str2);
            recipe2.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list2 = new List<Tag> { "ManualJuicer" };
            recipe2.fabricators = list2;
            recipe2.sortOrder = 2;
            Food_NoshMilkConfig.recipe = recipe2;
        }

    }
}
