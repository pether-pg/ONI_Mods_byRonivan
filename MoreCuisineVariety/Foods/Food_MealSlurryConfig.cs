using STRINGS;
using UnityEngine;

namespace MoreCuisineVariety
{
    public class Food_MealSlurryConfig : IEntityConfig
    {
        public const string Id = "MealSlurry";
        public static string Name = UI.FormatAsLink("Meal Batter", Id.ToUpper());
        public static string Description = $"A fearsome sticky slurry made from {UI.FormatAsLink("Meal Lice", "BasicPlantFood")} and Water. Used as a basic ingredient in many recipes.";

        public static ComplexRecipe recipe;

        public string[] GetDlcIds() =>
            DlcManager.AVAILABLE_ALL_VERSIONS;


        public GameObject CreatePrefab()
        {

            var looseEntity = EntityTemplates.CreateLooseEntity(
                id: Id,
                name: Name,
                desc: Description,
                mass: 1f,
                unitMass: false,
                anim: Assets.GetAnim("meal_slurry_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: Id,
                dlcId: "",
                caloriesPerUnit: 0f,
                quality: -1,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: 2400f,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            return foodEntity;
        }

        public void OnPrefabInit(GameObject inst) { }

        public void OnSpawn(GameObject inst) { }

    }
}
