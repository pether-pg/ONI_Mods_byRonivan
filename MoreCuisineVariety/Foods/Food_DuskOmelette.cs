using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_DuskOmelette : IEntityConfig
    {
        public const string Id = "DuskOmelette";
        public static string Name = UI.FormatAsLink("Dusk Omelette", Id.ToUpper());
        public static string Description = $"A fluffy dish made from beaten {UI.FormatAsLink("Eggs", "RAWEGG")} and folded over nice fried {UI.FormatAsLink("Dusk Cap", "MUSHROOM")} mushroons. The savory flavors of the mushroons get along well with the omelette soft texture.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Dusk Omelette", Food_SpicedOmelette.Id)}";

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
                anim: Assets.GetAnim("food_duskomelette_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "",
                caloriesPerUnit: 3400000f,
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
             Duskcap 2400 Kcal 1/4 = 600 Kcal
             -----------------------------> 3400 Kcal
            */

            //===> DUSK OMELETTE RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray29 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("RawEgg", 1f), new ComplexRecipe.RecipeElement(MushroomConfig.ID, 0.25f) };
            ComplexRecipe.RecipeElement[] elementArray30 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("DuskOmelette".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe DuskOmeletteRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray29, elementArray30), elementArray29, elementArray30);
            DuskOmeletteRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            DuskOmeletteRecipe.description = Food_DuskOmelette.RecipeDescription;
            DuskOmeletteRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list15 = new List<Tag>();
            list15.Add("CookingStation");
            DuskOmeletteRecipe.fabricators = list15;
            DuskOmeletteRecipe.sortOrder = 24;
            Food_DuskOmelette.Recipe = DuskOmeletteRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
