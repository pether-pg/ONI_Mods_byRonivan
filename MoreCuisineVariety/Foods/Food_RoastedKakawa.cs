using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_RoastedKakawa : IEntityConfig
    {
        public const string Id = "Roasted_Kakawa";
        public static string Name = UI.FormatAsLink("Roasted Kakawa", "Roasted_Kakawa".ToUpper());
        public static string Description = ("A fully roasted " + Crop_KakawaAcorn.Name + ". The roasting crack open its hard shell reaveling a edible nut, although the eating may be a bitter experience.");
        public static string RecipeDescription = ("Roast a " + Crop_KakawaAcorn.Name + ".");
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Roasted_Kakawa", Name, Description, 1f, false, Assets.GetAnim("food_roasted_kakawa_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("Roasted_Kakawa", "", 300000f, 1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Kakawa_Acorn", 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Roasted_Kakawa", 1f) };
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

