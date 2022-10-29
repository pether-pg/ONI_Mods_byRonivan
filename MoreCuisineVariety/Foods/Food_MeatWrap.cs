using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_MeatWrap : IEntityConfig
    {
        public const string Id = "MeatWrap";
        public static string Name = UI.FormatAsLink("Meat Wrap", "MeatWrap".ToUpper());
        public static string Description;
        public static string RecipeDescription;
        public static ComplexRecipe Recipe;

        static Food_MeatWrap()
        {
            string[] textArray1 = new string[] { "A tasty snack made by wrapping grilled ", UI.FormatAsLink("Meat", "Meat"), " with ", UI.FormatAsLink("Warm Flat Bread", "FlatBread"), ". Each bite leaves a mild warm sensation in one's mouth, even when the snack itself is served cold." };
            Description = string.Concat(textArray1);
            RecipeDescription = "Bake a " + UI.FormatAsLink("Meat Wrap", "MeatWrap");
        }

        public static GameObject CreateFabricationVisualizer(GameObject result)
        {
            GameObject target = new GameObject {
                name = result.name + "Visualizer"
            };
            target.SetActive(false);
            target.transform.SetLocalPosition(Vector3.zero);
            KBatchedAnimController controller2 = target.AddComponent<KBatchedAnimController>();
            controller2.AnimFiles = result.GetComponent<KBatchedAnimController>().AnimFiles;
            controller2.initialAnim = "fabricating";
            controller2.isMovable = true;
            KBatchedAnimTracker tracker = target.AddComponent<KBatchedAnimTracker>();
            tracker.symbol = new HashedString("meter_ration");
            tracker.offset = Vector3.zero;
            UnityEngine.Object.DontDestroyOnLoad(target);
            return target;
        }

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MeatWrap", Name, Description, 1f, false, Assets.GetAnim("food_meat_wrap_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("MeatWrap", "", 2200000f, 2, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] ingredients = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("FlatBread", 1f), new ComplexRecipe.RecipeElement("Meat", 0.75f) };
            ComplexRecipe.RecipeElement[] results = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MeatWrap", 1f) };
            ComplexRecipe recipe1 = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("CookingStation", ingredients, results), ingredients, results, 0);
            recipe1.time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME;
            recipe1.description = RecipeDescription;
            recipe1.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list1 = new List<Tag>();
            list1.Add("CookingStation");
            recipe1.fabricators = list1;
            recipe1.sortOrder = 3;
            recipe1.requiredTech = null;
            Recipe = recipe1;
            return obj3;
        }

        public string[] GetDlcIds() => 
            DlcManager.AVAILABLE_ALL_VERSIONS;

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}

