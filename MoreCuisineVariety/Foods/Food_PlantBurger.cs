using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_PlantBurger : IEntityConfig
    {
        public const string Id = "PlantBurger";
        public static string Name = UI.FormatAsLink("Plant Burger", Id.ToUpper());
        public static string Description = $"Tasty {UI.FormatAsLink("Grilled Plant Meat", Food_GrilledPlantMeat.Id)} and {UI.FormatAsLink("Lettuce", "LETTUCE")} pressed together inside a split {UI.FormatAsLink("Mealbrot", Food_MealBread.Id)}. Can cause shivers and shakes after consumption.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Plant Burger", Food_PlantBurger.Id)}";

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
                anim: Assets.GetAnim("food_plantburger_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "EXPANSION1_ID",
                caloriesPerUnit: 6000000f,
                quality: TUNING.FOOD.FOOD_QUALITY_MORE_WONDERFUL,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: 2400f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Grilled Plant Meat = 2400 Kcal
             Mealbrot = 2800 Kcal
             Lettuce = 400 Kcal
             Cooking Process = 400 Kcal
             -----------------------------> 6000 Kcal
            */

            //===> PLANT BURGER RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray47 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("GrilledPlantMeat", 1f), new ComplexRecipe.RecipeElement("Lettuce", 1f), new ComplexRecipe.RecipeElement("MealBread", 1f) };
            ComplexRecipe.RecipeElement[] elementArray48 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("PlantBurger".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe PlantBurgerRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", elementArray47, elementArray48), elementArray47, elementArray48);
            PlantBurgerRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            PlantBurgerRecipe.description = Food_PlantBurger.RecipeDescription;
            PlantBurgerRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list24 = new List<Tag>();
            list24.Add("GourmetCookingStation");
            PlantBurgerRecipe.fabricators = list24;
            PlantBurgerRecipe.sortOrder = 33;
            Food_PlantBurger.Recipe = PlantBurgerRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }
    }
}
