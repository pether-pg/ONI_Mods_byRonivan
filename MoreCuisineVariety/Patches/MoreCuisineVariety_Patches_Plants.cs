using HarmonyLib;
using Klei;
using KMod;
using ProcGen;
using System.Collections.Generic;
using System.Linq;
using TUNING;

namespace MoreCuisineVariety
{
    public class MoreCuisineVariety_Patches_Plants
    {
        public static Dictionary<string, CuisinePlantsTuning.CropsTuning> CropsDictionary;
        public const float CyclesForGrowth = 4f;

        [HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        public static class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                string[] textArray1 = new string[] { "STRINGS.ITEMS.FOOD." + "Kakawa_Acorn".ToUpperInvariant() + ".NAME", Crop_KakawaAcorn.Name };
                Strings.Add(textArray1);
                string[] textArray2 = new string[] { "STRINGS.ITEMS.FOOD." + "Kakawa_Acorn".ToUpperInvariant() + ".DESC", Crop_KakawaAcorn.Description };
                Strings.Add(textArray2);
                string[] textArray3 = new string[] { "STRINGS.CREATURES.SPECIES.SEEDS." + "KakawaTreeSeed".ToUpperInvariant() + ".NAME", "Kakawa Tree Sprout" };
                Strings.Add(textArray3);
                string[] textArray4 = new string[] { "STRINGS.CREATURES.SPECIES.SEEDS." + "KakawaTreeSeed".ToUpperInvariant() + ".DESC", Plant_KakawaTreeConfig.SeedDescription };
                Strings.Add(textArray4);
                string[] textArray5 = new string[] { "STRINGS.CREATURES.SPECIES." + "KakawaTree".ToUpperInvariant() + ".NAME", "Kakawa Tree" };
                Strings.Add(textArray5);
                string[] textArray6 = new string[] { "STRINGS.CREATURES.SPECIES." + "KakawaTree".ToUpperInvariant() + ".DESC", Plant_KakawaTreeConfig.Description };
                Strings.Add(textArray6);
                string[] textArray7 = new string[] { "STRINGS.CREATURES.SPECIES." + "KakawaTree".ToUpperInvariant() + ".DOMESTICATEDDESC", Plant_KakawaTreeConfig.DomesticatedDescription };
                Strings.Add(textArray7);
                CROPS.CROP_TYPES.Add(new Crop.CropVal("Kakawa_Acorn", 12600f, 0x18, true));
                string[] textArray8 = new string[] { "STRINGS.ITEMS.FOOD." + "Creamtop_Cap".ToUpperInvariant() + ".NAME", Crop_Creamcap.Name };
                Strings.Add(textArray8);
                string[] textArray9 = new string[] { "STRINGS.ITEMS.FOOD." + "Creamtop_Cap".ToUpperInvariant() + ".DESC", Crop_Creamcap.Description };
                Strings.Add(textArray9);
                string[] textArray10 = new string[] { "STRINGS.CREATURES.SPECIES.SEEDS." + "CreamcapSeed".ToUpperInvariant() + ".NAME", "Creamcap Mushroom Spore" };
                Strings.Add(textArray10);
                string[] textArray11 = new string[] { "STRINGS.CREATURES.SPECIES.SEEDS." + "CreamcapSeed".ToUpperInvariant() + ".DESC", Plant_CreamcapMushroomConfig.SeedDescription };
                Strings.Add(textArray11);
                string[] textArray12 = new string[] { "STRINGS.CREATURES.SPECIES." + "Creamcap".ToUpperInvariant() + ".NAME", "Creamcap Mushroom" };
                Strings.Add(textArray12);
                string[] textArray13 = new string[] { "STRINGS.CREATURES.SPECIES." + "Creamcap".ToUpperInvariant() + ".DESC", Plant_CreamcapMushroomConfig.Description };
                Strings.Add(textArray13);
                string[] textArray14 = new string[] { "STRINGS.CREATURES.SPECIES." + "Creamcap".ToUpperInvariant() + ".DOMESTICATEDDESC", Plant_CreamcapMushroomConfig.DomesticatedDescription };
                Strings.Add(textArray14);
                CROPS.CROP_TYPES.Add(new Crop.CropVal("Creamtop_Cap", 3440f, 1, true));
                string[] textArray15 = new string[] { "STRINGS.ITEMS.FOOD." + "SunnyWheat_Grain".ToUpperInvariant() + ".NAME", Crop_SunnyWheatGrain.Name };
                Strings.Add(textArray15);
                string[] textArray16 = new string[] { "STRINGS.ITEMS.FOOD." + "SunnyWheat_Grain".ToUpperInvariant() + ".DESC", Crop_SunnyWheatGrain.Description };
                Strings.Add(textArray16);
                string[] textArray17 = new string[] { "STRINGS.CREATURES.SPECIES.SEEDS." + "SunnyWheatSeed".ToUpperInvariant() + ".NAME", "Sunny Wheat Bulb" };
                Strings.Add(textArray17);
                string[] textArray18 = new string[] { "STRINGS.CREATURES.SPECIES.SEEDS." + "SunnyWheatSeed".ToUpperInvariant() + ".DESC", Plant_SunnyWheatConfig.SeedDescription };
                Strings.Add(textArray18);
                string[] textArray19 = new string[] { "STRINGS.CREATURES.SPECIES." + "SunnyWheat".ToUpperInvariant() + ".NAME", "Sunny Wheat" };
                Strings.Add(textArray19);
                string[] textArray20 = new string[] { "STRINGS.CREATURES.SPECIES." + "SunnyWheat".ToUpperInvariant() + ".DESC", Plant_SunnyWheatConfig.Description };
                Strings.Add(textArray20);
                string[] textArray21 = new string[] { "STRINGS.CREATURES.SPECIES." + "SunnyWheat".ToUpperInvariant() + ".DOMESTICATEDDESC", Plant_SunnyWheatConfig.DomesticatedDescription };
                Strings.Add(textArray21);
                CROPS.CROP_TYPES.Add(new Crop.CropVal("SunnyWheat_Grain", 10800f, 0x12, true));
                string[] textArray22 = new string[] { "STRINGS.ITEMS.FOOD." + "Roasted_Kakawa".ToUpperInvariant() + ".NAME", Food_RoastedKakawa.Name };
                Strings.Add(textArray22);
                string[] textArray23 = new string[] { "STRINGS.ITEMS.FOOD." + "Roasted_Kakawa".ToUpperInvariant() + ".DESC", Food_RoastedKakawa.Description };
                Strings.Add(textArray23);
                string[] textArray24 = new string[] { "STRINGS.ITEMS.FOOD." + "FlatBread".ToUpperInvariant() + ".NAME", Food_FlatBread.Name };
                Strings.Add(textArray24);
                string[] textArray25 = new string[] { "STRINGS.ITEMS.FOOD." + "FlatBread".ToUpperInvariant() + ".DESC", Food_FlatBread.Description };
                Strings.Add(textArray25);
                string[] textArray26 = new string[] { "STRINGS.ITEMS.FOOD." + "Grilled_Creamtop".ToUpperInvariant() + ".NAME", Food_GrilledCreamtop.Name };
                Strings.Add(textArray26);
                string[] textArray27 = new string[] { "STRINGS.ITEMS.FOOD." + "Grilled_Creamtop".ToUpperInvariant() + ".DESC", Food_GrilledCreamtop.Description };
                Strings.Add(textArray27);
                string[] textArray28 = new string[] { "STRINGS.ITEMS.FOOD." + "KakawaButter".ToUpperInvariant() + ".NAME", Food_KakawaButter.Name };
                Strings.Add(textArray28);
                string[] textArray29 = new string[] { "STRINGS.ITEMS.FOOD." + "KakawaButter".ToUpperInvariant() + ".DESC", Food_KakawaButter.Description };
                Strings.Add(textArray29);
                string[] textArray30 = new string[] { "STRINGS.ITEMS.FOOD." + "KakawaBar".ToUpperInvariant() + ".NAME", Food_KakawaBar.Name };
                Strings.Add(textArray30);
                string[] textArray31 = new string[] { "STRINGS.ITEMS.FOOD." + "KakawaBar".ToUpperInvariant() + ".DESC", Food_KakawaBar.Description };
                Strings.Add(textArray31);
                string[] textArray32 = new string[] { "STRINGS.ITEMS.FOOD." + "LiceWrap".ToUpperInvariant() + ".NAME", Food_LiceWrap.Name };
                Strings.Add(textArray32);
                string[] textArray33 = new string[] { "STRINGS.ITEMS.FOOD." + "LiceWrap".ToUpperInvariant() + ".DESC", Food_LiceWrap.Description };
                Strings.Add(textArray33);
                string[] textArray34 = new string[] { "STRINGS.ITEMS.FOOD." + "FishWrap".ToUpperInvariant() + ".NAME", Food_FishWrap.Name };
                Strings.Add(textArray34);
                string[] textArray35 = new string[] { "STRINGS.ITEMS.FOOD." + "FishWrap".ToUpperInvariant() + ".DESC", Food_FishWrap.Description };
                Strings.Add(textArray35);
                string[] textArray36 = new string[] { "STRINGS.ITEMS.FOOD." + "MeatWrap".ToUpperInvariant() + ".NAME", Food_MeatWrap.Name };
                Strings.Add(textArray36);
                string[] textArray37 = new string[] { "STRINGS.ITEMS.FOOD." + "MeatWrap".ToUpperInvariant() + ".DESC", Food_MeatWrap.Description };
                Strings.Add(textArray37);
                string[] textArray38 = new string[] { "STRINGS.ITEMS.FOOD." + "KakawaCookie".ToUpperInvariant() + ".NAME", Food_Cookie.Name };
                Strings.Add(textArray38);
                string[] textArray39 = new string[] { "STRINGS.ITEMS.FOOD." + "KakawaCookie".ToUpperInvariant() + ".DESC", Food_Cookie.Description };
                Strings.Add(textArray39);
                string[] textArray40 = new string[] { "STRINGS.ITEMS.FOOD." + "Nut_cake".ToUpperInvariant() + ".NAME", Food_Nutcake.Name };
                Strings.Add(textArray40);
                string[] textArray41 = new string[] { "STRINGS.ITEMS.FOOD." + "Nut_cake".ToUpperInvariant() + ".DESC", Food_Nutcake.Description };
                Strings.Add(textArray41);
                string[] textArray42 = new string[] { "STRINGS.ITEMS.FOOD." + "SeaTaco".ToUpperInvariant() + ".NAME", Food_SeaTaco.Name };
                Strings.Add(textArray42);
                string[] textArray43 = new string[] { "STRINGS.ITEMS.FOOD." + "SeaTaco".ToUpperInvariant() + ".DESC", Food_SeaTaco.Description };
                Strings.Add(textArray43);
                string[] textArray44 = new string[] { "STRINGS.ITEMS.FOOD." + "MeatTaco".ToUpperInvariant() + ".NAME", Food_MeatTaco.Name };
                Strings.Add(textArray44);
                string[] textArray45 = new string[] { "STRINGS.ITEMS.FOOD." + "MeatTaco".ToUpperInvariant() + ".DESC", Food_MeatTaco.Description };
                Strings.Add(textArray45);
                string[] textArray46 = new string[] { "STRINGS.ITEMS.FOOD." + "MushroomStew".ToUpperInvariant() + ".NAME", Food_MushroomStew.Name };
                Strings.Add(textArray46);
                string[] textArray47 = new string[] { "STRINGS.ITEMS.FOOD." + "MushroomStew".ToUpperInvariant() + ".DESC", Food_MushroomStew.Description };
                Strings.Add(textArray47);
            }
        }

        [HarmonyPatch(typeof(Immigration), "ConfigureCarePackages")]
        public static class Immigration_ConfigureCarePackages_Patch
        {
            public static void Postfix(ref Immigration __instance)
            {
                Traverse traverse = Traverse.Create(__instance).Field("carePackages");
                List<CarePackageInfo> list = traverse.GetValue<CarePackageInfo[]>().ToList<CarePackageInfo>();
                list.Add(new CarePackageInfo("KakawaTreeSeed", 3f, null));
                list.Add(new CarePackageInfo("CreamcapSeed", 3f, null));
                list.Add(new CarePackageInfo("SunnyWheatSeed", 3f, null));
                traverse.SetValue(list.ToArray());
                list.Add(new CarePackageInfo("KakawaBar", 5f, null));
                list.Add(new CarePackageInfo("FishWrap", 8f, null));
                list.Add(new CarePackageInfo("MeatWrap", 8f, null));
                list.Add(new CarePackageInfo("KakawaCookie", 8f, null));
                list.Add(new CarePackageInfo("Nut_cake", 6f, null));
            }
        }

        [HarmonyPatch(typeof(SettingsCache), "LoadFiles", new System.Type[] { typeof(string), typeof(string), typeof(List<YamlIO.Error>) })]
        public static class SettingsCache_LoadFiles_Patch
        {
            public static void Postfix()
            {
                ComposableDictionary<string, Mob> mobLookupTable = SettingsCache.mobs.MobLookupTable;
                foreach (string str in MoreCuisineVariety_Patches_Plants.CropsDictionary.Keys)
                {
                    if (!mobLookupTable.ContainsKey(str))
                    {
                        CuisinePlantsTuning.CropsTuning tuning = MoreCuisineVariety_Patches_Plants.CropsDictionary[str];
                        Mob mob1 = new Mob(tuning.spawnLocation);
                        mob1.name = str;
                        Mob root = mob1;
                        Traverse traverse = Traverse.Create(root);
                        traverse.Property("width", null).SetValue(1);
                        traverse.Property("height", null).SetValue(1);
                        traverse.Property("density", null).SetValue(tuning.density);
                        mobLookupTable.Add(str, root);
                    }
                }
            }
        }

        [HarmonyPatch(typeof(SettingsCache), "LoadSubworlds")]
        public static class SettingsCache_LoadSubworlds_Patch
        {
            public static void Postfix()
            {
                foreach (SubWorld world in SettingsCache.subworlds.Values)
                {
                    foreach (WeightedBiome biome in world.biomes)
                    {
                        foreach (string str in MoreCuisineVariety_Patches_Plants.CropsDictionary.Keys)
                        {
                            CuisinePlantsTuning.CropsTuning tuning = MoreCuisineVariety_Patches_Plants.CropsDictionary[str];
                            if (tuning.ValidBiome(world, biome.name))
                            {
                                if (ReferenceEquals(biome.tags, null))
                                {
                                    Traverse.Create(biome).Property("tags", null).SetValue(new List<string>());
                                }
                                biome.tags.Add(str);
                            }
                        }
                    }
                }
            }
        }
    }
}

