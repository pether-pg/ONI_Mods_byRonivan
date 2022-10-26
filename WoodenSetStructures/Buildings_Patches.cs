using Database;
using HarmonyLib;
using System;
using System.Collections.Generic;
using STRINGS;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace WoodenSetStructures
{
    //=== WOODEN CEILING =========================================================
    namespace Wooden_Ceiling_Patches
    {
        namespace WoodenCeiling_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenCeilingTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("WoodenCeiling");
                }
            }
        }

        namespace WoodenCeiling_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenCeilingUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENCEILING.NAME", "Wooden Ceiling" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENCEILING.DESC", "Wood work used to decorate the ceilings of rooms. Increases Decor, contributing to Morale." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENCEILING.EFFECT", "This ceiling is a beautiful masonry and wood work, but serves only as a decorative purpose." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "WoodenCeiling");
                }
            }
        }
    }

    //=== CORNER ARCH ===========================================================
    namespace Wooden_Corner_Arch_Patches
    {
        namespace WoodenCornerArch_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenCornerArchTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Luxury"] = new List<string>(Techs.TECH_GROUPING["Luxury"]) { "WoodenCornerArch" }.ToArray();

                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("WoodenCornerArch");
                }
            }
        }

        namespace WoodenCornerArch_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenCornerArchUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENCORNERARCH.NAME", "Wooden Corner Arch" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENCORNERARCH.DESC", "A wooden arch used to decorate the ceiling corners of rooms. Increases Decor, contributing to Morale." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENCORNERARCH.EFFECT", "This corner ceiling arch is beautiful masonry and wood work, but serves only as a decorative purpose." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "WoodenCornerArch");
                }
            }
        }
    }

    //=== WOODEN DOOR =============================================================
    namespace Wooden_Door_Patches
    {
        namespace WoodenDoor_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenDoorTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Luxury"] = new List<string>(Techs.TECH_GROUPING["Luxury"]) { "WoodenDoor" }.ToArray();

                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("WoodenDoor");
                }
            }
        }

        namespace WoodenDoor_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenDoorUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDOOR.NAME", "Wooden Door" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDOOR.DESC", "A pretty wooden door that encloses areas without blocking Liquid or Gas flow. Sets Duplicant Access Permissions for area restriction." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDOOR.EFFECT", "Wild Critters cannot pass through doors. Door controls can be used to prevent Duplicants from entering restricted areas." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "WoodenDoor");
                }
            }
        }
    }
    
    //=== WOODEN DRY WALL B =========================================================
    namespace Wooden_Drywall_B_Patches
    {
        namespace WoodenDryWall_B_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenDryWall_BTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["RenaissanceArt"] = new List<string>(Techs.TECH_GROUPING["RenaissanceArt"]) { "WoodenDryWall_B" }.ToArray();

                    Db.Get().Techs.Get("RenaissanceArt").unlockedItemIDs.Add("WoodenDryWall_B");
                }
            }
        }

        namespace WoodenDryWall_B_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenDryWall_BUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDRYWALL_B.NAME", "Parquet Drywall" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDRYWALL_B.DESC", "A dry wall covered with a pretty wooden panel in Parquet design." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDRYWALL_B.EFFECT", "Prevents gas and liquid loss in space. Builds an insulating backwall behind buildings." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Utilities", "WoodenDryWall_B");
                }
            }
        }
    }

    //=== WOODEN DRY WALL PATCH =============================================================
    namespace Wooden_Drywall_Patches
    {
        namespace WoodenDryWall_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenDryWallTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Luxury"] = new List<string>(Techs.TECH_GROUPING["Luxury"]) { "WoodenDryWall" }.ToArray();

                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("WoodenDryWall");
                }
            }
        }

        namespace WoodenDryWall_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenDryWallUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDRYWALL.NAME", "Wooden Panel Wall" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDRYWALL.DESC", "A dry wall covered with a pretty wooden panel." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENDRYWALL.EFFECT", "Prevents gas and liquid loss in space. Builds an insulating backwall behind buildings." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Utilities", "WoodenDryWall");
                }
            }
        }
    }

    //=== BRICK WALL =========================================================================

    namespace BrickWall_Patches
    {
        namespace BrickWall_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class BrickWallTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("RefractiveDecor").unlockedItemIDs.Add("BrickWall");
                }
            }
        }

        namespace BrickWall_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class BrickWallUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.BRICKWALL.NAME", "Brick Wall" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.BRICKWALL.DESC", "A pretty dry wall made with fine bricks." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[2];
                    textArray3[0] = "STRINGS.BUILDINGS.PREFABS.BRICKWALL.EFFECT";
                    string[] textArray4 = new string[] { "Prevents gas and liquid loss in space. Builds an insulating backwall behind buildings." };
                    textArray3[1] = string.Concat(textArray4);
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Utilities", "BrickWall");
                }
            }
        }
    }

    //=== WOODEN LADDER ======================================================================
    namespace Wooden_Ladder_Patches
    {
        namespace WoodenLadder_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenLadderTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Luxury"] = new List<string>(Techs.TECH_GROUPING["Luxury"]) { "WoodenLadder" }.ToArray();

                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("WoodenLadder");
                }
            }
        }

        namespace WoodenLadder_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenLadderUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENLADDER.NAME", "Wooden Ladder" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENLADDER.DESC", "A pretty ladder made of wood." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[2];
                    textArray3[0] = "STRINGS.BUILDINGS.PREFABS.WOODENLADDER.EFFECT";
                    string[] textArray4 = new string[] { "Increase duplicants climbing speed." };
                    textArray3[1] = string.Concat(textArray4);
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "WoodenLadder");
                }
            }
        }

    }

    //=== WOODEN GAS TILE ====================================================================
    namespace Wooden_GasTile_Patches
    {
        namespace WoodenGasTile_TechPatch
        {
            using Database;
            using HarmonyLib;
            using System;
            using System.Collections.Generic;

            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenGasTileTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["PressureManagement"] = new List<string>(Techs.TECH_GROUPING["PressureManagement"]) { "WoodenGasTile" }.ToArray();

                    Db.Get().Techs.Get("PressureManagement").unlockedItemIDs.Add("WoodenGasTile");
                }
            }
        }

        namespace WoodenGasTile_UiPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenGasTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENGASTILE.NAME", "Wooden Airflow Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENGASTILE.DESC", "An impermeable wooden tile, used to build walls and floors of rooms. \n\nBlocks Liquid flow without obstructing Gas." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENGASTILE.EFFECT", "Building with wooden airflow tile promotes better gas circulation within a colony." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "WoodenGasTile");
                }
            }
        }

        namespace WoodenGasTile
        {
            internal class WoodenGasTilePatch
            {
                private static Tag CreateMaterialCategoryTag(SimHashes element_id, Tag phaseTag, string materialCategoryField)
                {
                    Tag tag;
                    if (string.IsNullOrEmpty(materialCategoryField))
                    {
                        tag = phaseTag;
                    }
                    else
                    {
                        Tag item = TagManager.Create(materialCategoryField);
                        if (!GameTags.MaterialCategories.Contains(item) && !GameTags.IgnoredMaterialCategories.Contains(item))
                        {
                            object[] args = new object[] { element_id, materialCategoryField };
                            Debug.LogWarningFormat("Element {0} has category {1}, but that isn't in GameTags.MaterialCategores!", args);
                        }
                        tag = item;
                    }
                    return tag;
                }

                private static Texture2D getTex(string name)
                {
                    Texture2D tex = null;
                    string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), name + ".png");
                    if (!File.Exists(path))
                    {
                        Debug.LogError("Could not load texture at path " + path + ".");
                    }
                    else
                    {
                        tex = new Texture2D(1, 1);
                        tex.LoadImage(File.ReadAllBytes(path));
                    }
                    return tex;
                }
            }
        }
    }

    //=== WOODEN MESH TILE ======================================================================
    namespace Wooden_MeshTile_Patches
    {
        namespace WoodenMeshTile_TechPatch
        {
            using Database;
            using HarmonyLib;
            using System;
            using System.Collections.Generic;

            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenMeshTileTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["SanitationSciences"] = new List<string>(Techs.TECH_GROUPING["SanitationSciences"]) { "WoodenMeshTile" }.ToArray();

                    Db.Get().Techs.Get("SanitationSciences").unlockedItemIDs.Add("WoodenMeshTile");
                }
            }
        }

        namespace WoodenMeshTile_UiPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenMeshTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENMESHTILE.NAME", "Wooden Mesh Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENMESHTILE.DESC", "A wooden tile filled with minute holes, used to build walls and floors of rooms.  \n\nDoes not obstruct Liquid or Gas flow. " };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENMESHTILE.EFFECT", "Wooden mesh tile can be used to make Duplicant pathways in areas where liquid flows." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "WoodenMeshTile");
                }
            }
        }

        namespace WoodenMeshTile
        {
            internal class WoodenMeshTilePatch
            {
                private static Tag CreateMaterialCategoryTag(SimHashes element_id, Tag phaseTag, string materialCategoryField)
                {
                    Tag tag;
                    if (string.IsNullOrEmpty(materialCategoryField))
                    {
                        tag = phaseTag;
                    }
                    else
                    {
                        Tag item = TagManager.Create(materialCategoryField);
                        if (!GameTags.MaterialCategories.Contains(item) && !GameTags.IgnoredMaterialCategories.Contains(item))
                        {
                            object[] args = new object[] { element_id, materialCategoryField };
                            Debug.LogWarningFormat("Element {0} has category {1}, but that isn't in GameTags.MaterialCategores!", args);
                        }
                        tag = item;
                    }
                    return tag;
                }

                private static Texture2D getTex(string name)
                {
                    Texture2D tex = null;
                    string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), name + ".png");
                    if (!File.Exists(path))
                    {
                        Debug.LogError("Could not load texture at path " + path + ".");
                    }
                    else
                    {
                        tex = new Texture2D(1, 1);
                        tex.LoadImage(File.ReadAllBytes(path));
                    }
                    return tex;
                }
            }
        }
    }

    //=== WOODEN TILE ======================================================================================
    namespace Wooden_Tile_Patches
    {
        namespace WoodenTile_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenTileTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Luxury"] = new List<string>(Techs.TECH_GROUPING["Luxury"]) { "WoodenTile" }.ToArray();

                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("WoodenTile");
                }
            }
        }

        namespace WoodenTile_UiPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTILE.NAME", "Wooden Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTILE.DESC", "Used to build the walls and floors of rooms. Increases Decor, contributing to Morale. " };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTILE.EFFECT", "Simple wooden tiles." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "WoodenTile");
                }
            }
        }

        namespace WoodenTile
        {
            internal class WoodenTilePatch
            {
                private static Tag CreateMaterialCategoryTag(SimHashes element_id, Tag phaseTag, string materialCategoryField)
                {
                    Tag tag;
                    if (string.IsNullOrEmpty(materialCategoryField))
                    {
                        tag = phaseTag;
                    }
                    else
                    {
                        Tag item = TagManager.Create(materialCategoryField);
                        if (!GameTags.MaterialCategories.Contains(item) && !GameTags.IgnoredMaterialCategories.Contains(item))
                        {
                            object[] args = new object[] { element_id, materialCategoryField };
                            Debug.LogWarningFormat("Element {0} has category {1}, but that isn't in GameTags.MaterialCategores!", args);
                        }
                        tag = item;
                    }
                    return tag;
                }

                private static Texture2D getTex(string name)
                {
                    Texture2D tex = null;
                    string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), name + ".png");
                    if (!File.Exists(path))
                    {
                        Debug.LogError("Could not load texture at path " + path + ".");
                    }
                    else
                    {
                        tex = new Texture2D(1, 1);
                        tex.LoadImage(File.ReadAllBytes(path));
                    }
                    return tex;
                }
            }
        }
    }

    //=============================== END ====================================================================
}
