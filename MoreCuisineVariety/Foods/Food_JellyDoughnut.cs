using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_JellyDoughnut : IEntityConfig
    {
        public const string Id = "JellyDoughnut";
        public static string Name = UI.FormatAsLink("Jelly Doughnut", Id.ToUpper());
        public static string Description = $"A leavened fried dough prepared from {UI.FormatAsLink("Meal Lice Batter", "MealSlurry")} and {UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id)}. The interior is filled a hearty portion of {UI.FormatAsLink("Bog Jelly", "SWAMPFRUIT")}.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Jelly Doughnut", "JellyDoughnut")}";

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
                anim: Assets.GetAnim("food_jellydoughnut_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "EXPANSION1_ID",
                caloriesPerUnit: 2800000f,
                quality: TUNING.FOOD.FOOD_QUALITY_GOOD,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: 2400f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Bog Jelly = 1840 Kcal
             Meal Batter = 1200 * 0.3 = 360 Kcal
             Nosh Milk = 1200 +   0.25 = 300
             -----------------------------> 2800 Kcal
            */

            //===> JELLY DOUGHNUT RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray45 = new ComplexRecipe.RecipeElement[] {new ComplexRecipe.RecipeElement("MealSlurry", 0.3f), new ComplexRecipe.RecipeElement("NoshMilk", 0.25f), new ComplexRecipe.RecipeElement(SwampFruitConfig.ID, 1f)};
            ComplexRecipe.RecipeElement[] elementArray46 = new ComplexRecipe.RecipeElement[] {new ComplexRecipe.RecipeElement("JellyDoughnut".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false)};
            ComplexRecipe JellyDoughRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray45, elementArray46), elementArray45, elementArray46);
            JellyDoughRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            JellyDoughRecipe.description = Food_JellyDoughnut.RecipeDescription;
            JellyDoughRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list23 = new List<Tag>();
            list23.Add("CookingStation");
            JellyDoughRecipe.fabricators = list23;
            JellyDoughRecipe.sortOrder = 32;
            Food_JellyDoughnut.Recipe = JellyDoughRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
