using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_MeatTaco : IEntityConfig
    {
        public const string Id = "MeatTaco";
        public static string Name = UI.FormatAsLink("Meat Taco", "MeatTaco".ToUpper());
        public static string Description;
        public static string RecipeDescription;
        public static ComplexRecipe Recipe;

        static Food_MeatTaco()
        {
            string[] textArray1 = new string[] { "A filling meal made with slowly baked ", UI.FormatAsLink("Meat", "Meat"), " with ", UI.FormatAsLink("Omellete", "CookedEgg"), ", all served within a ", UI.FormatAsLink("Warm Flat Bread", "FlatBread"), ". It promptly leaves a warm sensation while it goes inside, as well when it leaves." };
            Description = string.Concat(textArray1);
            RecipeDescription = "Bake a " + UI.FormatAsLink("Meat Taco", "MeatTaco");
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
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MeatTaco", Name, Description, 1f, false, Assets.GetAnim("food_meat_taco_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("MeatTaco", "", 6000000f, 6, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] ingredients = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("FlatBread", 1f), new ComplexRecipe.RecipeElement("CookedMeat", 0.5f), new ComplexRecipe.RecipeElement("CookedEgg", 1f) };
            ComplexRecipe.RecipeElement[] results = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MeatTaco", 1f) };
            ComplexRecipe recipe1 = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", ingredients, results), ingredients, results, 0);
            recipe1.time = TUNING.FOOD.RECIPES.SMALL_COOK_TIME;
            recipe1.description = RecipeDescription;
            recipe1.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list1 = new List<Tag>();
            list1.Add("GourmetCookingStation");
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

