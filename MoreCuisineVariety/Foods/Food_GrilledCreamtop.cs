using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_GrilledCreamtop : IEntityConfig
    {
        public const string Id = "Grilled_Creamtop";
        public static string Name = UI.FormatAsLink("Grilled Creamcap", "Grilled_Creamtop".ToUpper());
        public static string Description = ("The grilled fruiting of a " + UI.FormatAsLink("Creamcap", "Creamtop_Cap") + ". It has a crispy texture and a soft, mildly sweet, earthy flavor.");
        public static string RecipeDescription = ("Grills a " + UI.FormatAsLink("Creamtop Cap", "Creamtop_Cap") + ".");
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Grilled_Creamtop", Name, Description, 1f, false, Assets.GetAnim("food_grilled_creamtop_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("Grilled_Creamtop", "", 1800000f, 1, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Creamtop_Cap", 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Grilled_Creamtop", 1f) };
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

