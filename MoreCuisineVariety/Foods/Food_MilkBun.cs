using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_MilkBun : IEntityConfig
    {
        public const string Id = "MilkBun";
        public static string Name = UI.FormatAsLink("Milk Bun", Id.ToUpper());
        public static string Description = $"A soft bun baked from {UI.FormatAsLink("Meal Batter", Food_MealSlurryConfig.Id)}, {UI.FormatAsLink("Nosh Milk", Food_NoshMilkConfig.Id)} and {UI.FormatAsLink("Sucrose", "SUCROSE")}. It gives the duplicants who eats it a happy face, and a quite unhappy face to others who will have to endure the farts.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Milk Bun", Food_MealBread.Id)}";

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
                anim: Assets.GetAnim("food_milkbun_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "EXPANSION1_ID",
                caloriesPerUnit: 2200000f,
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
             Meal Batter = 1200 Kcal
             Nosh Milk 1/4 = 300 Kcal
             Sucrose = 100 Kcal
             Cooking Process = 600 Kcal
             -----------------------------> 2200 Kcal
            */

            //===> MILK BUN RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray39 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MealSlurry", 1f), new ComplexRecipe.RecipeElement("NoshMilk", 0.25f), new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 4f) };
            ComplexRecipe.RecipeElement[] elementArray40 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MilkBun".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe MilkBunRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray39, elementArray40), elementArray39, elementArray40);
            MilkBunRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            MilkBunRecipe.description = Food_MilkBun.RecipeDescription;
            MilkBunRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list20 = new List<Tag>();
            list20.Add("CookingStation");
            MilkBunRecipe.fabricators = list20;
            MilkBunRecipe.sortOrder = 29;
            Food_BreadedPacu.Recipe = MilkBunRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
