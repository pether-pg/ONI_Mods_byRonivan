using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_CookedMuckroot : IEntityConfig
    {
        public const string Id = "CookedMuckroot";
        public static string Name = UI.FormatAsLink("Baked Muckroot", Id.ToUpper());
        public static string Description = $"The highlight point of a {UI.FormatAsLink("Muckroot", "BASICFORAGEPLANT")}, or at least as far as it can get through cooking. The baking process renders it aftertaste less bland.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Muckroot", Food_CookedMuckroot.Id)}";

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
                anim: Assets.GetAnim("food_cooked_muckroot_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "",
                caloriesPerUnit: 1400000f,
                quality: TUNING.FOOD.FOOD_QUALITY_MEDIOCRE,
                preserveTemperatue: 267.15f,
                rotTemperature: 315.15f,
                spoilTime: 4800f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Muckroot = 800 Kcal
             Cooking Process = 600 Kcal
             -----------------------------> 1400 Kcal
            */

            //===> BAKED MUCKROOT RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray23 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("BasicForagePlant", 1f) };
            ComplexRecipe.RecipeElement[] elementArray24 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("CookedMuckroot".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe BakedMuckrootRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray23, elementArray24), elementArray23, elementArray24);
            BakedMuckrootRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            BakedMuckrootRecipe.description = Food_CookedMuckroot.RecipeDescription;
            BakedMuckrootRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list12 = new List<Tag>();
            list12.Add("CookingStation");
            BakedMuckrootRecipe.fabricators = list12;
            BakedMuckrootRecipe.sortOrder = 21;
            Food_CookedMuckroot.Recipe = BakedMuckrootRecipe;

            return foodEntity;
        }


        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
