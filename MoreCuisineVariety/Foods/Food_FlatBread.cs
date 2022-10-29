using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_FlatBread : IEntityConfig
    {
        public const string Id = "FlatBread";
        public static string Name = UI.FormatAsLink("Warm Flat Bread", "FlatBread".ToUpper());
        public static string Description = ("A simple flat bread baked from " + UI.FormatAsLink("Sunny Wheat Grain", "SunnyWheat_Grain") + ". Each bite leaves a mild warmth sensation in one's mouth, even when the bread itself is cold.");
        public static string RecipeDescription = ("Bake a " + UI.FormatAsLink("Warm Flat Bread", "FlatBread") + ".");
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("FlatBread", Name, Description, 1f, false, Assets.GetAnim("food_flat_bread_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("FlatBread", "", 900000f, 0, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("SunnyWheat_Grain", 3f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("FlatBread", 1f) };
            string id = ComplexRecipeManager.MakeRecipeID("CookingStation", inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0);
            recipe1.time = FOOD.RECIPES.SMALL_COOK_TIME;
            recipe1.description = RecipeDescription;
            recipe1.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list1 = new List<Tag>();
            list1.Add("CookingStation");
            recipe1.fabricators = list1;
            recipe1.sortOrder = 3;
            recipe1.requiredTech = null;
            this.Recipe = recipe1;
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

