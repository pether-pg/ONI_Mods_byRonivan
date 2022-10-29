using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_Nutpie : IEntityConfig
    {
        public const string Id = "Nutpie";
        public static string Name = UI.FormatAsLink("Grubner Nusstorte", Id.ToUpper());
        public static string Description = $"A gourmet pie with a nut filling of caramelised {UI.FormatAsLink("Roast Grubfruit Nuts", "WORMBASICFOOD")}, {UI.FormatAsLink("Sleet Wheat Grain", "COLDWHEATSEED")} and {UI.FormatAsLink("Eggs", "RAWEGG")} dough, and {UI.FormatAsLink("Sucrose", "SUCROSE")}. The buttery crust remains fresh for a long time.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Grubner Nusstorte", Food_Nutpie.Id)}";

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
                anim: Assets.GetAnim("food_nutpie_kanim"),
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
                spoilTime: 6000f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Spindly Grubfruit 3x= 3200 Kcal
             Sleet Wheat Grain = 250 Kcal/unit 4x = 1000 Kcal
             Raw Egg = 800 Kcal
             Sucrose = 12 = 300 Kcal
             Cooking Process = 700 Kcal
             -----------------------------> 6000 Kcal
            */

            //===> GRUBNER NUSSTORTE RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray43 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("WormBasicFood", 3f), new ComplexRecipe.RecipeElement("ColdWheatSeed", 4f), new ComplexRecipe.RecipeElement("RawEgg", 1f), new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 12f) };
            ComplexRecipe.RecipeElement[] elementArray44 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Nutpie".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe NutpieRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", elementArray43, elementArray44), elementArray43, elementArray44);
            NutpieRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            NutpieRecipe.description = Food_Nutpie.RecipeDescription;
            NutpieRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list22 = new List<Tag>();
            list22.Add("GourmetCookingStation");
            NutpieRecipe.fabricators = list22;
            NutpieRecipe.sortOrder = 31;
            Food_Nutpie.Recipe = NutpieRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
