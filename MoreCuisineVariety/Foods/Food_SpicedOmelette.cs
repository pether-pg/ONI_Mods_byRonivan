using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_SpicedOmelette : IEntityConfig
    {
        public const string Id = "SpicedOmelette";
        public static string Name = UI.FormatAsLink("Spiced Omelette", Id.ToUpper());
        public static string Description = $"A fluffy dish made from beaten {UI.FormatAsLink("Eggs", "RAWEGG")} and served with generous pinch of {UI.FormatAsLink("Pincha Peppernut", "SPICENUT")}. Has a deep spiced flavour that sticks to the mouth.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Spiced Omelette", Food_SpicedOmelette.Id)}";
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
                anim: Assets.GetAnim("food_spiced_omelette_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "",
                caloriesPerUnit: 3200000f,
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
             Standard Omelette = 2800 Kcal
             Pincha Peppernut = 400 Kcal
             -----------------------------> 3200 Kcal
            */

            //===> SPICED OMELETTE RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray31 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("RawEgg", 1f), new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 1f) };
            ComplexRecipe.RecipeElement[] elementArray32 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("SpicedOmelette".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe SpicedOmeletteRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray31, elementArray32), elementArray31, elementArray32);
            SpicedOmeletteRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            SpicedOmeletteRecipe.description = Food_SpicedOmelette.RecipeDescription;
            SpicedOmeletteRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list16 = new List<Tag>();
            list16.Add("CookingStation");
            SpicedOmeletteRecipe.fabricators = list16;
            SpicedOmeletteRecipe.sortOrder = 25;
            Food_SpicedOmelette.Recipe = SpicedOmeletteRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
