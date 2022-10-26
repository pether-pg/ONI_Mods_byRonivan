namespace CustomTiles
{
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

    //===> GLASS DOOR SIMPLE <===================================================================================================================================================
    namespace GlassDoorSimplePatches
    {
        namespace GlassDoorSimplePatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class GlassDoorSimpleTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("GlassDoorSimple");
                }
            }
        }

        namespace GlassDoorSimpleUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class GlassDoorSimpleUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.GLASSDOORSIMPLE.NAME", "Simple Glass Door" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.GLASSDOORSIMPLE.DESC", "Wild Critters cannot pass through doors. Door controls can be used to prevent Duplicants from entering restricted areas." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[2];
                    textArray3[0] = "STRINGS.BUILDINGS.PREFABS.GLASSDOORSIMPLE.EFFECT";
                    string[] textArray4 = new string[] { "A simple model door made with glass panels. Encloses areas without blocking Liquid or Gas flow. Sets Duplicant Access Permissions for area restriction." };
                    textArray3[1] = string.Concat(textArray4);
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "GlassDoorSimple");
                }
            }
        }
    }

    //===> GLASS DOOR COMPLEX <===================================================================================================================================================
    namespace GlassDoorComplexPatches
    {
        namespace GlassDoorComplexPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class GlassDoorComplexTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("GlassDoorComplex");
                }
            }
        }

        namespace GlassDoorComplexUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class GlassDoorComplexUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.GLASSDOORCOMPLEX.NAME", "Security Glass Door" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.GLASSDOORCOMPLEX.DESC", "Functions as a Manual Airlock when no Power is available." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[2];
                    textArray3[0] = "STRINGS.BUILDINGS.PREFABS.GLASSDOORCOMPLEX.EFFECT";
                    string[] textArray4 = new string[] { "A mechanized airlock door made with glass panels. Blocks Liquid and Gas flow, maintaining pressure between areas. Sets Duplicant Access Permissions for area restriction." };
                    textArray3[1] = string.Concat(textArray4);
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "GlassDoorComplex");
                }
            }
        }
    }


    //===> FACILITY DOOR YELLOW <===========================================================================================================================
    namespace FacilityDoorYellow_Patch
    {
        namespace FacilityDoorYellow_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class FacilityDoorYellowTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("InteriorDecor").unlockedItemIDs.Add("FacilityDoorYellow");
                }
            }
        }

        namespace FacilityDoorYellowUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class FacilityDoorYellowUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORYELLOW.NAME", "Yellow Facility Door" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORYELLOW.DESC", "A light-weight door with intricate designs that suggests it bellongs to a industrial facility." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORYELLOW.EFFECT", "A high-tech light door with yellow tint." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "FacilityDoorYellow");
                }
            }
        }
    }

    //===> FACILITY DOOR WHITE <===========================================================================================================================
    namespace FacilityDoorWhite_Patch
    {
        namespace FacilityDoorWhite_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class FacilityDoorWhiteTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("InteriorDecor").unlockedItemIDs.Add("FacilityDoorWhite");
                }
            }
        }

        namespace FacilityDoorWhiteUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class FacilityDoorWhiteUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORWHITE.NAME", "White Facility Door" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORWHITE.DESC", "A light-weight door with intricate designs that suggests it bellongs to a industrial facility." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORWHITE.EFFECT", "A high-tech light door with white tint." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "FacilityDoorWhite");
                }
            }
        }
    }

    //===> FACILITY DOOR RED <===========================================================================================================================
    namespace FacilityDoorRed_Patch
    {
        namespace FacilityDoorRed_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class FacilityDoorRedTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("InteriorDecor").unlockedItemIDs.Add("FacilityDoorRed");
                }
            }
        }

        namespace FacilityDoorRedUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class FacilityDoorRedUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORRED.NAME", "Red Facility Door" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORRED.DESC", "A light-weight door with intricate designs that suggests it bellongs to a industrial facility." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.FACILITYDOORRED.EFFECT", "A high-tech light door with red tint." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "FacilityDoorRed");
                }
            }
        }
    }

    //===> STRUCTURE FRAME LARGE <==============================================================================================
    namespace StructureFrameLarge_Patch
    {
        namespace StructureFrameLarge_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class StructureFrameLargeTechMod
            {

                private static void Postfix()
                {
                    Db.Get().Techs.Get("Smelting").unlockedItemIDs.Add("StructureFrameLarge");
                }
            }
        }

        namespace StructureFrameLarge_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class StructureFrameLargeUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTUREFRAMELARGE.NAME", "Large Structure Frame" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTUREFRAMELARGE.DESC", "A large sized structural frame." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTUREFRAMELARGE.EFFECT", "Provides background support for buildings, or least gives the nice appearance of doing so. Don't prevent gases or liquid from leaking in to the void." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Utilities", "StructureFrameLarge");
                }
            }
        }
    }

    

    //===> STRUCTURE FRAME SMALL <==============================================================================================
    namespace StructureFrameSmall_Patch
    {
        namespace StructureFrameSmall_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class StructureFrameSmallTechMod
            {

                private static void Postfix()
                {
                    Db.Get().Techs.Get("Smelting").unlockedItemIDs.Add("StructureFrameSmall");
                }
            }
        }

        namespace StructureFrameSmall_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class StructureFrameSmallUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTUREFRAMESMALL.NAME", "Small Structure Frame" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTUREFRAMESMALL.DESC", "A medium sized structural frame." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTUREFRAMESMALL.EFFECT", "Provides background support for buildings, or least gives the nice appearance of doing so. Don't prevent gases or liquid from leaking in to the void." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Utilities", "StructureFrameSmall");
                }
            }
        }
    }


    //===> LAMP_B <===================================================================================================================================================
    namespace Lamp_BPatches
    {
        namespace Lamp_BPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class Lamp_BTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("Lamp_B");
                }
            }
        }

        namespace Lamp_BUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class Lamp_BUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LAMP_B.NAME", "Fancy Light" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LAMP_B.DESC", "A fancy ceiling lamp made of polished metal." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[2];
                    textArray3[0] = "STRINGS.BUILDINGS.PREFABS.LAMP_B.EFFECT";
                    string[] textArray4 = new string[] { "A fancy lamp to light a small area." };
                    textArray3[1] = string.Concat(textArray4);
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "Lamp_B");
                }
            }
        }
    }

    //===> LAMP_A <==========================================================================================================================================================
    namespace Lamp_APatches
    {
        namespace Lamp_APatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class Lamp_ATechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("Lamp_A");
                }
            }
        }

        namespace Lamp_AUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class Lamp_AUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LAMP_A.NAME", "Pretty Ceiling Light" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LAMP_A.DESC", "A pretty ceiling lamp made of polished metal." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[2];
                    textArray3[0] = "STRINGS.BUILDINGS.PREFABS.LAMP_A.EFFECT";
                    string[] textArray4 = new string[] { "A pretty lamp to light a small area." };
                    textArray3[1] = string.Concat(textArray4);
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "Lamp_A");
                }
            }
        }

    }

    //===> CEMENT MIXER <=========================================================================================
    namespace CementMixer_Patch
    {

        [HarmonyPatch(typeof(Db), "Initialize")]
        internal class CementMixerTechMod
        {
            private static void Postfix()
            {
                Db.Get().Techs.Get("BasicRefinement").unlockedItemIDs.Add("CementMixer");
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class CementMixerUI
        {
            private static void Prefix()
            {
                string[] value = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.CEMENTMIXER.NAME",
                "Cement Mixer"
                };
                Strings.Add(value);
                string[] value2 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.CEMENTMIXER.DESC",
                "Cement is a quite old building material, but still pretty much useful."
                };
                Strings.Add(value2);
                string[] value3 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.CEMENTMIXER.EFFECT",
                "A device that can homogeneously combine several solid and liquid ingredients used in the production of cement."
                };
                Strings.Add(value3);
                ModUtil.AddBuildingToPlanScreen("Refining", "CementMixer");
            }
        }
    }

    //=== SANDSTONE TILE ==============================================================================================================================================
    namespace CustomSandstoneTile_Patches
    {
        namespace CustomSandstoneTile_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class CustomSandstoneTileTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("CustomSandstoneTile");
                }
            }
        }

        namespace CustomSandstoneTile_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class CustomSandstoneTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMSANDSTONETILE.NAME", "Sandstone Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMSANDSTONETILE.DESC", "A notable tile made exclusively with Sandstone." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMSANDSTONETILE.EFFECT", "Sandstone tile enhance not only the environmental beauty, but also increases duplicants walking speed. Has some small insulation properties as well." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "CustomSandstoneTile");
                }
            }
        }
    }

    //=== IGNEOUS TILE ==============================================================================================================================================
    namespace CustomIgneousTile_Patches
    {
        namespace CustomIgneousTile_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class CustomIgneousTileTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("CustomIgneousTile");
                }
            }
        }

        namespace CustomIgneousTile_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class CustomIgneousTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMIGNEOUSTILE.NAME", "Igneous Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMIGNEOUSTILE.DESC", "A notable tile made exclusively with Igneous Rock." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMIGNEOUSTILE.EFFECT", "Igneous tile enhance not only the environmental beauty, but also increases duplicants walking speed. Has very poor insulating properties." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "CustomIgneousTile");
                }
            }
        }
    }

    //=== OBSIDIAN TILE ==============================================================================================================================================
    namespace CustomObsidianTile_Patches
    {
        namespace CustomObsidianTile_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class CustomObsidianTileTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("CustomObsidianTile");
                }
            }
        }

        namespace CustomObsidianTile_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class CustomObsidianTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMOBSIDIANTILE.NAME", "Obsidian Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMOBSIDIANTILE.DESC", "A notable tile made exclusively with Obsidian, a form of volcanic glass." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMOBSIDIANTILE.EFFECT", "Obsidian tile enhance not only the environmental beauty, but also increases duplicants walking speed. Has almost no insulating property, and its also thermically reactive." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "CustomObsidianTile");
                }
            }
        }
    }

    //=== GRANITE TILE ==============================================================================================================================================
    namespace CustomGraniteTile_Patches
    {
        namespace CustomGraniteTile_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class CustomGraniteTileTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("CustomGraniteTile");
                }
            }
        }

        namespace CustomGraniteTile_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class CustomGraniteTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMGRANITETILE.NAME", "Granite Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMGRANITETILE.DESC", "Granite tiles are aesthetically pleasing while remaining a good insulator." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.CUSTOMGRANITETILE.EFFECT", "A smooth tile made with several granite stones carefully placed together." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "CustomGraniteTile");
                }
            }
        }
    }

    //===> INSULATING TILE <=============================================================================================================================================
    namespace InsulatingTilePatches
    {
        namespace InsulatingTilePatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class InsulatingTileTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("TemperatureModulation").unlockedItemIDs.Add("InsulatingTile");
                }
            }
        }

        namespace InsulatingTileUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class InsulatingTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.INSULATINGTILE.NAME", "Insulating Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.INSULATINGTILE.DESC", "The lowered thermal conductivity of insulated tiles slows any heat passing through them." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[2];
                    textArray3[0] = "STRINGS.BUILDINGS.PREFABS.INSULATINGTILE.EFFECT";
                    string[] textArray4 = new string[] { "Used to build the walls and floors of rooms. Reduces heat transfer between walls, retaining ambient heat in an area. " };
                    textArray3[1] = string.Concat(textArray4);
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "InsulatingTile");
                }
            }
        }
    }

    //===> STRUCTURE TILE <==============================================================================================
    namespace StructureTile_Patch
    {
        namespace StructureTile_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class StructureTileTechMod
            {

                private static void Postfix()
                {
                    Db.Get().Techs.Get("SanitationSciences").unlockedItemIDs.Add("StructureTile");
                }
            }
        }

        namespace StructureTile_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class StructureTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTURETILE.NAME", "Structure Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTURETILE.DESC", "A solid structural tile wrought from refined metal. Use to build the walls and floors of rooms." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.STRUCTURETILE.EFFECT", "This steel structure is commonly used as a simple, yet strong tile for buildings. The frame structure will not hold any gas or liquid." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "StructureTile");
                }
            }
        }
    }

    //=== CONCRETE TILE ==============================================================================================================================================
    namespace ConcreteTile_Patches
    {
        namespace ConcreteTile_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class ConcreteTileTechMod
            {
                private static void Postfix()
                {
                    Db.Get().Techs.Get("HighTempForging").unlockedItemIDs.Add("ConcreteTile");
                }
            }
        }

        namespace ConcreteTile_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class ConcreteTileUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.CONCRETETILE.NAME", "Concrete Tile" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.CONCRETETILE.DESC", "A rock hard composite tile made with coarse aggregate bonded together with a fluid cement. The concrete's relatively low tensile strength and ductility are compensated for by the inclusion of a internal rebar reinforcement having higher tensile strength or ductility." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.CONCRETETILE.EFFECT", "Concrete tiles are not aesthetically pleasing, but they make up for strength and thermal resistance." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Base", "ConcreteTile");
                }
            }
        }
    }

    //===> ALERT LIGHT RED <=========================================================================================
    namespace AlertLightRed_Patch
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        internal class AlertLightRedTechMod
        {
            private static void Postfix()
            {
                Db.Get().Techs.Get("LogicControl").unlockedItemIDs.Add("AlertLightRed");
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class AlertLightRedUI
        {
            private static void Prefix()
            {
                string[] array = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTRED.NAME",
                "Red Alert Light"
                };
                Strings.Add(array);
                string[] array2 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTRED.DESC",
                "Red colored alert light."
                };
                Strings.Add(array2);
                string[] array3 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTRED.EFFECT",
                "A led light that servers as alert. Produces no significant luminosity."
                };
                Strings.Add(array3);
                ModUtil.AddBuildingToPlanScreen("Automation", "AlertLightRed");
            }
        }
    }

    //===> ALERT LIGHT YELLOW <=========================================================================================
    namespace AlertLightYellow_Patch
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        internal class AlertLightYellowTechMod
        {
            private static void Postfix()
            {
                Db.Get().Techs.Get("LogicControl").unlockedItemIDs.Add("AlertLightYellow");
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class AlertLightYellowUI
        {
            private static void Prefix()
            {
                string[] array = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTYELLOW.NAME",
                "Yellow Alert Light"
                };
                Strings.Add(array);
                string[] array2 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTYELLOW.DESC",
                "Yellow colored alert light."
                };
                Strings.Add(array2);
                string[] array3 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTYELLOW.EFFECT",
                "A led light that servers as alert. Produces no significant luminosity."
                };
                Strings.Add(array3);
                ModUtil.AddBuildingToPlanScreen("Automation", "AlertLightYellow");
            }
        }
    }

    //===> ALERT LIGHT GREEN <=========================================================================================
    namespace AlertLightGreen_Patch
    {
        [HarmonyPatch(typeof(Db), "Initialize")]
        internal class AlertLightGreenTechMod
        {
            private static void Postfix()
            {
                Db.Get().Techs.Get("LogicControl").unlockedItemIDs.Add("AlertLightGreen");
            }
        }

        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class AlertLightGreenUI
        {
            private static void Prefix()
            {
                string[] array = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTGREEN.NAME",
                "Green Alert Led"
                };
                Strings.Add(array);
                string[] array2 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTGREEN.DESC",
                "Greem colored alert light."
                };
                Strings.Add(array2);
                string[] array3 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ALERTLIGHTGREEN.EFFECT",
                "A led light that servers as alert. Produces no significant luminosity."
                };
                Strings.Add(array3);
                ModUtil.AddBuildingToPlanScreen("Automation", "AlertLightGreen");
            }
        }
    }


    //===> CUSTOM TILES MANAGEMENT <======================================================================================================================================
    namespace CustomTile
    {
        internal class CustomTilePatch
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

