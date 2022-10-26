namespace CustomTiles
{
    using System;
    using System.Collections.Generic;
    using HarmonyLib;

    //===> CEMENT RECIPE <====================================================================================
    [HarmonyPatch(typeof(CementMixerConfig), "ConfigureBuildingTemplate")]
    public static class Cement_Recipe
    {
        public static void Postfix()
        {
            Tag material = SimHashes.CrushedRock.CreateTag();
            Tag material2 = SimHashes.Sand.CreateTag();
            Tag material3 = SimHashes.Lime.CreateTag();
            Tag material4 = SimHashes.Water.CreateTag();
            Tag material5 = SimHashes.Cement.CreateTag();
            string name = ElementLoader.FindElementByHash(SimHashes.CrushedRock).name;
            string name2 = ElementLoader.FindElementByHash(SimHashes.Sand).name;
            string name3 = ElementLoader.FindElementByHash(SimHashes.Lime).name;
            string name4 = ElementLoader.FindElementByHash(SimHashes.Water).name;
            string name5 = ElementLoader.FindElementByHash(SimHashes.Cement).name;

            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material, 25f), // Igredient: Crushed Rock
                new ComplexRecipe.RecipeElement(material2, 60f), // Igredient: Sand
                new ComplexRecipe.RecipeElement(material3, 5f), // Igredient: Lime
                new ComplexRecipe.RecipeElement(material4, 10f) // Igredient: Water
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material5, 100f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("CementMixer", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 30f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {"Produce ",name5," from a mixture of ",name2,", ",name,", ",name3,", and some ",name3,"."}), name);
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("CementMixer")
            };
        }
    }

    //===> ROCK CRUSH RECIPES <========================================================================================================================================
    
    //===> GRANITE CRUSHING <=========================================================================================
    [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
    public static class GraniteCrushing
    {
        public static void Postfix()
        {
            Tag material = SimHashes.Granite.CreateTag();
            Tag material2 = SimHashes.CrushedRock.CreateTag();
            Tag material3 = SimHashes.Sand.CreateTag();
            string name = ElementLoader.FindElementByHash(SimHashes.Granite).name;
            string name2 = ElementLoader.FindElementByHash(SimHashes.CrushedRock).name;
            string name3 = ElementLoader.FindElementByHash(SimHashes.Sand).name;
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material, 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material2, 50f),
                new ComplexRecipe.RecipeElement(material3, 50f)
            };
            string id = ComplexRecipeManager.MakeRecipeID("RockCrusher", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 25f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Slowly crush down ",name,", producing ",name2," and ",name3,"."}), name);
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("RockCrusher")
            };
        }
    }

    //===> IGNEOUS ROCK CRUSHING <=========================================================================================
    [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
    public static class IgneousRockCrushing
    {
        public static void Postfix()
        {
            Tag material = SimHashes.IgneousRock.CreateTag();
            Tag material2 = SimHashes.CrushedRock.CreateTag();
            Tag material3 = SimHashes.Sand.CreateTag();
            string name = ElementLoader.FindElementByHash(SimHashes.IgneousRock).name;
            string name2 = ElementLoader.FindElementByHash(SimHashes.CrushedRock).name;
            string name3 = ElementLoader.FindElementByHash(SimHashes.Sand).name;
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material, 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material2, 50f),
                new ComplexRecipe.RecipeElement(material3, 50f)
            };
            string id = ComplexRecipeManager.MakeRecipeID("RockCrusher", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 25f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Slowly crush down ",name,", producing ",name2," and ",name3,"."}), name);
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("RockCrusher")
            };
        }
    }

    //===> SANDSTONE CRUSHING <=========================================================================================
    [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
    public static class SandstoneCrushing
    {
        public static void Postfix()
        {
            Tag material = SimHashes.SandStone.CreateTag();
            Tag material2 = SimHashes.CrushedRock.CreateTag();
            Tag material3 = SimHashes.Sand.CreateTag();
            string name = ElementLoader.FindElementByHash(SimHashes.SandStone).name;
            string name2 = ElementLoader.FindElementByHash(SimHashes.CrushedRock).name;
            string name3 = ElementLoader.FindElementByHash(SimHashes.Sand).name;
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material, 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material2, 50f),
                new ComplexRecipe.RecipeElement(material3, 50f)
            };
            string id = ComplexRecipeManager.MakeRecipeID("RockCrusher", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 25f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Slowly crush down ",name,", producing ",name2," and ",name3,"."}), name);
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("RockCrusher")
            };
        }
    }

    //===> SEDIMENTARY ROCK CRUSHING <=========================================================================================
    [HarmonyPatch(typeof(RockCrusherConfig), "ConfigureBuildingTemplate")]
    public static class SedimentaryRockCrushing
    {
        public static void Postfix()
        {
            Tag material = SimHashes.SedimentaryRock.CreateTag();
            Tag material2 = SimHashes.CrushedRock.CreateTag();
            Tag material3 = SimHashes.Sand.CreateTag();
            string name = ElementLoader.FindElementByHash(SimHashes.SedimentaryRock).name;
            string name2 = ElementLoader.FindElementByHash(SimHashes.CrushedRock).name;
            string name3 = ElementLoader.FindElementByHash(SimHashes.Sand).name;
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material, 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(material2, 50f),
                new ComplexRecipe.RecipeElement(material3, 50f)
            };
            string id = ComplexRecipeManager.MakeRecipeID("RockCrusher", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 25f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Slowly crush down ",name,", producing ",name2," and ",name3,"."}), name);
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("RockCrusher")
            };
        }
    }

}
