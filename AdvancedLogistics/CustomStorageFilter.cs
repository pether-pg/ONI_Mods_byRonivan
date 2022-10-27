using System;
using System.Collections.Generic;

namespace AdvancedLogistics
{
    public class CUSTOMSTORAGEFILTERS
    {
        public static List<Tag> NOT_LIQUEFIABLE_SOLIDS = new List<Tag>
        {
            GameTags.Alloy,
            GameTags.RefinedMetal,
            GameTags.Metal,
            GameTags.BuildableRaw,
            GameTags.BuildableProcessed,
            GameTags.Farmable,
            GameTags.Organics,
            GameTags.Compostable,
            GameTags.Seed,
            GameTags.Agriculture,
            GameTags.Filter,
            GameTags.ConsumableOre,
            GameTags.IndustrialProduct,
            GameTags.IndustrialIngredient,
            GameTags.MedicalSupplies,
            GameTags.Clothes,
            GameTags.ManufacturedMaterial,
            GameTags.RareMaterials,
            GameTags.Other
        };
    }
}
