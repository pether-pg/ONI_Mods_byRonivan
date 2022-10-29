using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_MealBread : IEntityConfig
    {
        public const string Id = "MealBread";
        public static string Name = UI.FormatAsLink("Mealbrot", Id.ToUpper());
        public static string Description = $"A loaf of {UI.FormatAsLink("Bread", Food_MealBread.Id)} baked from a mixture of {UI.FormatAsLink("Meal Batter", Food_MealSlurryConfig.Id)}, {UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id)} and {UI.FormatAsLink("Eggs", "RAWEGG")}. Despite its hard crust, this bread is actually tasty, and has a long shelf life.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Mealbrot", Food_MealBread.Id)}";

        public static ComplexRecipe Recipe;

        public string[] GetDlcIds() =>
            DlcManager.AVAILABLE_ALL_VERSIONS;


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
                anim: Assets.GetAnim("food_mealbread_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "",
                caloriesPerUnit: 2800000f,
                quality: TUNING.FOOD.FOOD_QUALITY_GOOD,
                preserveTemperatue: 267.15f,
                rotTemperature: 315.15f,
                spoilTime: 7600f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Meal Batter = 1200 Kcal
             Nosh Milk 1/2 = 600 Kcal
             Raw Egg 1/2 = 400 Kcal
             Cooking Process = 600 Kcal
             -----------------------------> 2800 Kcal
            */

            //===> MEAL BREAD RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray37 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MealSlurry", 1f), new ComplexRecipe.RecipeElement("NoshMilk", 0.5f), new ComplexRecipe.RecipeElement("RawEgg", 0.5f) };
            ComplexRecipe.RecipeElement[] elementArray38 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MealBread".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe MealBreadRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray37, elementArray38), elementArray37, elementArray38);
            MealBreadRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            MealBreadRecipe.description = Food_MealBread.RecipeDescription;
            MealBreadRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list19 = new List<Tag>();
            list19.Add("CookingStation");
            MealBreadRecipe.fabricators = list19;
            MealBreadRecipe.sortOrder = 28;
            Food_MealBread.Recipe = MealBreadRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
