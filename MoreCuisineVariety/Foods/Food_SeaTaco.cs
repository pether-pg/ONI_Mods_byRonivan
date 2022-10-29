using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_SeaTaco : IEntityConfig
    {
        public const string Id = "SeaTaco";
        public static string Name = UI.FormatAsLink("Sea Taco", "SeaTaco".ToUpper());
        public static string Description;
        public static string RecipeDescription;
        public static ComplexRecipe Recipe;

        static Food_SeaTaco()
        {
            string[] textArray1 = new string[9];
            textArray1[0] = "A filling meal made with slowly baked ";
            textArray1[1] = UI.FormatAsLink("Pacu Fillet", "FishMeat");
            textArray1[2] = " with ";
            textArray1[3] = UI.FormatAsLink("Lettuce", "Lettuce");
            textArray1[4] = ", and a pinch of ";
            textArray1[5] = UI.FormatAsLink("Pepper Nut", SpiceNutConfig.ID);
            textArray1[6] = ", all served with a ";
            textArray1[7] = UI.FormatAsLink("Warm Flat Bread", "FlatBread");
            textArray1[8] = ". It promptly leaves a warm sensation while it goes inside, as well when it leaves.";
            Description = string.Concat(textArray1);
            RecipeDescription = "Bake a " + UI.FormatAsLink("Sea Taco", "SeaTaco");
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
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("SeaTaco", Name, Description, 1f, false, Assets.GetAnim("food_sea_taco_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("SeaTaco", "", 6000f, 6, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] ingredients = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("FlatBread", 1f), new ComplexRecipe.RecipeElement("CookedFish", 2f), new ComplexRecipe.RecipeElement(SpiceNutConfig.ID, 1f), new ComplexRecipe.RecipeElement("Lettuce", 2f) };
            ComplexRecipe.RecipeElement[] results = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("SeaTaco", 1f) };
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

