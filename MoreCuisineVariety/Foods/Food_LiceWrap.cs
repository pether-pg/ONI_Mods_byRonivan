using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_LiceWrap : IEntityConfig
    {
        public const string Id = "LiceWrap";
        public static string Name = UI.FormatAsLink("Lice Wrap", "LiceWrap".ToUpper());
        public static string Description;
        public static string RecipeDescription;
        public static ComplexRecipe Recipe;

        static Food_LiceWrap()
        {
            string[] textArray1 = new string[] { "A dubious snack made by wrapping fresh ", UI.FormatAsLink("Meal Lice", "BasicPlantFood"), " with ", UI.FormatAsLink("Warm Flat Bread", "FlatBread"), ". The warm flavor from the bread mitigates regretable texture of filling." };
            Description = string.Concat(textArray1);
            RecipeDescription = "Bake a " + UI.FormatAsLink("Lice Wrap", "LiceWrap");
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
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("LiceWrap", Name, Description, 1f, false, Assets.GetAnim("food_lice_wrap_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("LiceWrap", "", 2400000f, 1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] ingredients = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("FlatBread", 1f), new ComplexRecipe.RecipeElement("BasicPlantFood", 2f) };
            ComplexRecipe.RecipeElement[] results = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("LiceWrap", 1f) };
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

