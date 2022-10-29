using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_NoshPudding : IEntityConfig
    {
        public const string Id = "NoshPudding";
        public static string Name = UI.FormatAsLink("Nosh Custard Flan", Id.ToUpper());
        public static string Description = $"A fancy sweet dessert made with {UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id)}, {UI.FormatAsLink("Sleet Wheat Grain", "COLDWHEATSEED")}, whisked {UI.FormatAsLink("Eggs", "RAWEGG")} and quite a lot of {UI.FormatAsLink("Sucrose", "SUCROSE")}. Has a fine rimmed pastry that prevents it from breaking apart as one holds it (for a short time).";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Nosh Custard Flan", Food_NoshPudding.Id)}";

        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() =>
            DlcManager.AVAILABLE_EXPANSION1_ONLY;


        public static GameObject CreateFabricationVisualizer(GameObject result)
        {
            KBatchedAnimController component = result.GetComponent<KBatchedAnimController>();
            GameObject gameObject = new GameObject();
            gameObject.name = result.name + "Visualizer";
            gameObject.SetActive(false);
            gameObject.transform.SetLocalPosition(Vector3.zero);
            KBatchedAnimController kbatchedAnimController = gameObject.AddComponent<KBatchedAnimController>();
            kbatchedAnimController.AnimFiles = component.AnimFiles;
            kbatchedAnimController.initialAnim = "fabricating";
            kbatchedAnimController.isMovable = true;
            KBatchedAnimTracker kbatchedAnimTracker = gameObject.AddComponent<KBatchedAnimTracker>();
            kbatchedAnimTracker.symbol = new HashedString("meter_ration");
            kbatchedAnimTracker.offset = Vector3.zero;
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            return gameObject;
        }

        public GameObject CreatePrefab()
        {

            var looseEntity = EntityTemplates.CreateLooseEntity(
                id: Id,
                name: Name,
                desc: Description,
                mass: 1f,
                unitMass: false,
                anim: Assets.GetAnim("food_noshpudding_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "EXPANSION1_ID",
                caloriesPerUnit: 4000000f,
                quality: TUNING.FOOD.FOOD_QUALITY_AMAZING,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: 2400f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Nosh Milk = 1200 Kcal
             Sleet Wheat Grain = 250 Kcal/unit
             Raw Egg = 1600 Kcal
             Sucrose = 12 = 300 Kcal
             Cooking Process = 600 Kcal
             -----------------------------> 4000 Kcal
            */

            //===> MEAL BREAD RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray41 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("NoshMilk", 1f), new ComplexRecipe.RecipeElement("ColdWheatSeed", 1f), new ComplexRecipe.RecipeElement("RawEgg", 2f), new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 12f) };
            ComplexRecipe.RecipeElement[] elementArray42 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("NoshPudding".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe NoshPuddingRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", elementArray41, elementArray42), elementArray41, elementArray42);
            NoshPuddingRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            NoshPuddingRecipe.description = Food_NoshPudding.RecipeDescription;
            NoshPuddingRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list21 = new List<Tag>();
            list21.Add("GourmetCookingStation");
            NoshPuddingRecipe.fabricators = list21;
            NoshPuddingRecipe.sortOrder = 30;
            Food_NoshPudding.Recipe = NoshPuddingRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
