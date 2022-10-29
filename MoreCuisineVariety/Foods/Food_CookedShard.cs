using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_CookedShard : IEntityConfig
    {
        public const string Id = "CookedShard";
        public static string Name = UI.FormatAsLink("Baked Chard", Id.ToUpper());
        public static string Description = $"A baked {UI.FormatAsLink("Swamp Chard Heart", "SWAMPFORAGEPLANT")}. It don't taste as bad as it looks, but it does smell as bad as it taste.";
        public static string RecipeDescription = $"Bake a {UI.FormatAsLink("Baked Chard", Food_CookedShard.Id)}";
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
                anim: Assets.GetAnim("food_cooked_shard_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "EXPANSION1_ID",
                caloriesPerUnit: 3000000f,
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
             Swamp Chard Heart = 2400 Kcal
             Cooking Process = 600 Kcal
             -----------------------------> 3000 Kcal
            */

            //===> BAKED CHARD RECIPE <=============================================================================================================================================
            ComplexRecipe.RecipeElement[] elementArray25 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("SwampForagePlant", 1f) };
            ComplexRecipe.RecipeElement[] elementArray26 = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("CookedShard".ToTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.Heated, false) };
            ComplexRecipe BakedChardRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", elementArray25, elementArray26), elementArray25, elementArray26);
            BakedChardRecipe.time = TUNING.FOOD.RECIPES.STANDARD_COOK_TIME;
            BakedChardRecipe.description = Food_CookedShard.RecipeDescription;
            BakedChardRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list13 = new List<Tag>();
            list13.Add("CookingStation");
            BakedChardRecipe.fabricators = list13;
            BakedChardRecipe.sortOrder = 22;
            Food_CookedShard.Recipe = BakedChardRecipe;

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
