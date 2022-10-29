using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_KakawaBar : IEntityConfig
    {
        public const string Id = "KakawaBar";
        public static string Name = UI.FormatAsLink("Kakawa Bar", "KakawaBar".ToUpper());
        public static string Description = (UI.FormatAsLink("Roasted Kakawa", "Roasted_Kakawa") + " compressed to a dense, buttery mass. Further cooking remove most of Kakawa bitterness, rendering this bar incredible tasty.");
        public static string RecipeDescription = ("Compress a " + UI.FormatAsLink("kakawa Bar", "KakawaBar"));
        public ComplexRecipe Recipe;

        public static GameObject CreateFabricationVisualizer(GameObject result)
        {
            GameObject obj1 = new GameObject();
            obj1.name = result.name + "Visualizer";
            GameObject target = obj1;
            target.SetActive(false);
            target.transform.SetLocalPosition(Vector3.zero);
            KBatchedAnimController controller = target.AddComponent<KBatchedAnimController>();
            controller.AnimFiles = result.GetComponent<KBatchedAnimController>().AnimFiles;
            controller.initialAnim = "fabricating";
            controller.isMovable = true;
            KBatchedAnimTracker tracker = target.AddComponent<KBatchedAnimTracker>();
            tracker.symbol = new HashedString("meter_ration");
            tracker.offset = Vector3.zero;
            UnityEngine.Object.DontDestroyOnLoad(target);
            return target;
        }

        public GameObject CreatePrefab()
        {
            GameObject obj3 = EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("KakawaBar", Name, Description, 1f, false, Assets.GetAnim("food_kakawa_bar_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true, 0, SimHashes.Creature, null), new EdiblesManager.FoodInfo("KakawaBar", "", 2000000f, 2, 255.15f, 277.15f, 2400f, true));
            ComplexRecipe.RecipeElement[] inputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("Roasted_Kakawa", 3f), new ComplexRecipe.RecipeElement("KakawaButter", 1f) };
            ComplexRecipe.RecipeElement[] outputs = new ComplexRecipe.RecipeElement[] { new ComplexRecipe.RecipeElement("KakawaBar", 1f) };
            string id = ComplexRecipeManager.MakeRecipeID("MicrobeMusher", inputs, outputs);
            ComplexRecipe recipe1 = new ComplexRecipe(id, inputs, outputs, 0);
            recipe1.time = FOOD.RECIPES.SMALL_COOK_TIME;
            recipe1.description = RecipeDescription;
            recipe1.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            List<Tag> list1 = new List<Tag>();
            list1.Add("MicrobeMusher");
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

