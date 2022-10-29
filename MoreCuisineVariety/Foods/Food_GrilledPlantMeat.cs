using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_GrilledPlantMeat : IEntityConfig
    {
        public const string Id = "GrilledPlantMeat";
        public static string Name = UI.FormatAsLink("Grilled Plant Meat", Id.ToUpper());
        public static string Description = $"A delightful grilled {UI.FormatAsLink("Plant Meat", "PLANTMEAT")}. It don't taste like meat, nor it taste like plant, but it really does taste good.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Grilled Plant Meat", Food_GrilledPlantMeat.Id)}";

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
                anim: Assets.GetAnim("food_grilled_plantmeat_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "EXPANSION1_ID",
                caloriesPerUnit: 2400000f,
                quality: TUNING.FOOD.FOOD_QUALITY_GREAT,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: 2400f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Plant Meat = 1200 Kcal
             Cooking Process = 1200 Kcal
             -----------------------------> 2400 Kcal
            */

            ////===> BAKED MUCKROOT RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray35 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("PlantMeat", 1f) };
            ComplexRecipe.RecipeElement[] elementArray36 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("GrilledPlantMeat".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe GrilledPlantMeatRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray35, elementArray36), elementArray35, elementArray36);
            GrilledPlantMeatRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            GrilledPlantMeatRecipe.description = Food_GrilledPlantMeat.RecipeDescription;
            GrilledPlantMeatRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list18 = new List<Tag>();
            list18.Add("CookingStation");
            GrilledPlantMeatRecipe.fabricators = list18;
            GrilledPlantMeatRecipe.sortOrder = 27;
            Food_GrilledPlantMeat.Recipe = GrilledPlantMeatRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
