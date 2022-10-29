using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_BreadedPacu : IEntityConfig
    {
        public const string Id = "BreadedPacu";
        public static string Name = UI.FormatAsLink("Battered Pacu", Id.ToUpper());
        public static string Description = $"A crispy {UI.FormatAsLink("Battered Pacu", Food_BreadedPacu.Id)} made with {UI.FormatAsLink("Pacu Fillet", FishMeatConfig.ID)} and {UI.FormatAsLink("Meal Lice Batter", Food_MealSlurryConfig.Id)}. Gives off cruchy noises as one eats them.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Battered Pacu", Food_BreadedPacu.Id)}";

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
                anim: Assets.GetAnim("food_breaded_pacu_kanim"),
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
             Pacu Fillet = 1000 Kcal
             Cooking Process = 600 Kcal
             -----------------------------> 2800 Kcal
            */

            //===> BREADED PACU RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray27 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement(Food_MealSlurryConfig.Id, 1f), new ComplexRecipe.RecipeElement("FishMeat", 1f) };
            ComplexRecipe.RecipeElement[] elementArray28 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("BreadedPacu".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe BreadedPacuRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray27, elementArray28), elementArray27, elementArray28);
            BreadedPacuRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            BreadedPacuRecipe.description = Food_BreadedPacu.RecipeDescription;
            BreadedPacuRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list14 = new List<Tag>();
            list14.Add("CookingStation");
            BreadedPacuRecipe.fabricators = list14;
            BreadedPacuRecipe.sortOrder = 23;
            Food_BreadedPacu.Recipe = BreadedPacuRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }
    }
}
