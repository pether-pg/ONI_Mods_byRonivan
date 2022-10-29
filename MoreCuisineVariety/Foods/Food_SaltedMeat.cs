using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_SaltedMeat : IEntityConfig
    {
        public const string Id = "SaltedMeat";
        public static string Name = UI.FormatAsLink("Salt-cured Meat", Id.ToUpper());
        public static string Description = $"A shunk of {UI.FormatAsLink("Meat", "MEAT")} dried with a lot of {UI.FormatAsLink("Salt", "SALT")}. The large amount of salt present in this meat made it completely resistant to microorganisms that would spoil it under normal conditions.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Salt-cured Meat", Food_SaltedMeat.Id)}";

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
                anim: Assets.GetAnim("food_saltedmeat_kanim"),
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
                spoilTime: 12800f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            /*
             Calculation -
             Meat 1/2 = 800 Kcal
             Cooking Process = 600 Kcal
             -----------------------------> 1400 Kcal
            */

            //===> SALT-CURED MEAL RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray33 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Meat", 0.5f), new ComplexRecipe.RecipeElement(SimHashes.Salt.CreateTag(), 10f) };
            ComplexRecipe.RecipeElement[] elementArray34 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("SaltedMeat".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe SaltedMeatRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray33, elementArray34), elementArray33, elementArray34);
            SaltedMeatRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            SaltedMeatRecipe.description = Food_SaltedMeat.RecipeDescription;
            SaltedMeatRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list17 = new List<Tag>();
            list17.Add("CookingStation");
            SaltedMeatRecipe.fabricators = list17;
            SaltedMeatRecipe.sortOrder = 26;
            Food_SaltedMeat.Recipe = SaltedMeatRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
