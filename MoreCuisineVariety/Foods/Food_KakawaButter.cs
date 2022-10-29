using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_KakawaButter : IEntityConfig
    {
        public const string Id = "KakawaButter";
        public static string Name = UI.FormatAsLink("Kakawa Butter", "KakawaButter".ToUpper());
        public static string Description = ("An oily butter extracted from " + Crop_KakawaAcorn.Name + ". This butter has a tasty aroma, although one must like bitterness to actually eat it in this form.");
        public static string RecipeDescription = ("Extract oil from " + Crop_KakawaAcorn.Name + ".");
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("KakawaButter", Name, Description, 1f, false, Assets.GetAnim("food_kakawa_butter_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("KakawaButter", "", 0f, -1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Kakawa_Acorn", 4f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("KakawaButter", 1f) };
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

