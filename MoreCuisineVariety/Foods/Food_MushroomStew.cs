using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_MushroomStew : IEntityConfig
    {
        public const string Id = "MushroomStew";
        public static string Name = UI.FormatAsLink("Mushroom Stew", "MushroomStew".ToUpper());
        public static string Description = "A thick, flavorful soup made by simmering mushroons and spices, placed within a hallowed Frost Bun and baked in a oven.";
        public static string RecipeDescription = ("Bake a " + UI.FormatAsLink("Mushroom Stew", "MushroomStew") + ".");
        public ComplexRecipe Recipe;

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("MushroomStew", Name, Description, 1f, false, Assets.GetAnim("food_mushroom_stew_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.7f, 0.5f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("MushroomStew", "", 5000000f, 6, 255.15f, 277.15f, 1200f, true));
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("ColdWheatBread", 1f), new ComplexRecipe.RecipeElement("SunnyWheat_Grain", 2f), new ComplexRecipe.RecipeElement("Grilled_Creamtop", 2f), new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("MushroomStew", 1f) };
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

