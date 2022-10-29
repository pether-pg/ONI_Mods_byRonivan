using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_Cookie : IEntityConfig
    {
        public const string Id = "KakawaCookie";
        public static string Name = UI.FormatAsLink("Frost Cookie", "KakawaCookie".ToUpper());
        public static string Description = "A buttery cookie with a subtle bittersweet, cold flavor.";
        public static string RecipeDescription = ("Bake a " + UI.FormatAsLink("Frost Cookie", "KakawaCookie") + ".");
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("KakawaCookie", Name, Description, 1f, false, Assets.GetAnim("food_cookie_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.7f, 0.5f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("KakawaCookie", "", 4000000f, 4, 255.15f, 277.15f, 3200f, true));
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("ColdWheatSeed", 3f), new ComplexRecipe.RecipeElement("Roasted_Kakawa", 4f), new ComplexRecipe.RecipeElement("KakawaButter", 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("KakawaCookie", 1f) };
            string id = ComplexRecipeManager.MakeRecipeID("GourmetCookingStation", inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0);
            recipe1.time = FOOD.RECIPES.SMALL_COOK_TIME;
            recipe1.description = RecipeDescription;
            recipe1.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list1 = new List<Tag>();
            list1.Add("GourmetCookingStation");
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

