using HarmonyLib;

namespace WoodenSetFurniture
{
    //===> WOODEN BED <=================================================================================================================
    namespace WoodenBed_Patch
    {
        namespace WoodenBed_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenBedTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Artistry"] = new List<string>(Techs.TECH_GROUPING["Artistry"]) { "WoodenBed" }.ToArray();

                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("WoodenBed");
                }
            }
        }

        namespace WoodenBed_UIPatch
        {
            using HarmonyLib;

            using System;

            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenBedUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENBED.NAME", "Wooden BedType" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENBED.DESC", "Duplicants prefer wooden beds to cots and gain more stamina from sleeping in them." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENBED.EFFECT", "Provides a sleeping area for one Duplicant and restores additional Stamina." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "WoodenBed");
                }
            }
        }
    }

    //===> WOODEN PEDESTAL <==============================================================================================================
    namespace WoodenPedestal_Patch
    {
        namespace WoodenPedestal_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenPedestalTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Artistry"] = new List<string>(Techs.TECH_GROUPING["Artistry"]) { "WoodenPedestal" }.ToArray();

                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("WoodenPedestal");
                }
            }
        }

        namespace WoodenPedestal_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenPedestalUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENPEDESTAL.NAME", "Wooden Pedestal" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENPEDESTAL.DESC", "The wooden pedestal provides a sophisticated way of thoughtful presentation." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENPEDESTAL.EFFECT", "Displays a single object, doubling its Decor value. Objects with negative decor will gain some positive decor when displayed." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "WoodenPedestal");
                }
            }
        }
    }

    //===> COZY BED <======================================================================================================================
    namespace CozyBed_Patch
    {
        namespace CozyBed_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class CozyBedTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Luxury"] = new List<string>(Techs.TECH_GROUPING["Luxury"]) { "CozyBed" }.ToArray();

                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("CozyBed");
                }
            }
        }

        namespace CozyBed_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class CozyBedUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.COZYBED.NAME", "Sofa BedType" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.COZYBED.DESC", "Duplicants prefer wooden beds to cots and gain more stamina from sleeping in them." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.COZYBED.EFFECT", "A cozy bed that somewhat resembles a sofa. This bed grants extra stamina restoration." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "CozyBed");
                }
            }
        }
    }

    //===> BEAN BAG <=====================================================================================================================================
    namespace BeanBag_Patch
    {
        namespace BeanBag_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class BeanBagTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Clothing"] = new List<string>(Techs.TECH_GROUPING["Clothing"]) { "BeanBag" }.ToArray();

                    Db.Get().Techs.Get("Clothing").unlockedItemIDs.Add("BeanBag");
                }
            }
        }

        namespace BeanBag_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class BeanBagUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.BEANBAG.NAME", "Bean Bag" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.BEANBAG.DESC", "Unique furniture pieces grants extra decoration bonus to the environment." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.BEANBAG.EFFECT", "A cozy and confotable bag filled with tiny fluffy polymer balls." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "BeanBag");
                }
            }
        }
    }

    //===> COZY CHAIR <====================================================================================================================================
    namespace CozyChair_Patch
    {
        namespace CozyChair_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class CozyChairTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Clothing"] = new List<string>(Techs.TECH_GROUPING["Clothing"]) { "CozyChair" }.ToArray();

                    Db.Get().Techs.Get("Clothing").unlockedItemIDs.Add("CozyChair");
                }
            }
        }

        namespace CozyChair_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class CozyChairUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.COZYCHAIR.NAME", "Cozy Chair" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.COZYCHAIR.DESC", "Unique furniture pieces grants extra decoration bonus to the environment." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.COZYCHAIR.EFFECT", "An ergonomic chair that makes a hard day's work bearable." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "CozyChair");
                }
            }
        }
    }

    //===> WOODEN TABLE EMPTY <============================================================================================================================
    namespace WoodenTableA_Patch
    {
        namespace WoodenTableA_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenTableATechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["InteriorDecor"] = new List<string>(Techs.TECH_GROUPING["InteriorDecor"]) { "WoodenTableA" }.ToArray();

                    Db.Get().Techs.Get("InteriorDecor").unlockedItemIDs.Add("WoodenTableA");
                }
            }
        }

        namespace WoodenTableA_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenTableAUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEA.NAME", "Wooden Table" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEA.DESC", "Unique furniture pieces grants extra decoration bonus to the environment." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEA.EFFECT", "An empty wooden table. Gives a rustic, yet beautiful sensation to the room." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "WoodenTableA");
                }
            }
        }
    }

    //===> WOODEN TABLE TEA<=============================================================================================================================
    namespace WoodenTableB_Patch
    {
        namespace WoodenTableB_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenTableBTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Artistry"] = new List<string>(Techs.TECH_GROUPING["Artistry"]) { "WoodenTableB" }.ToArray();

                    Db.Get().Techs.Get("Artistry").unlockedItemIDs.Add("WoodenTableB");
                }
            }
        }

        namespace WoodenTableB_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenTableBUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEB.NAME", "Wooden Table & Teapot" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEB.DESC", "Unique furniture pieces grants extra decoration bonus to the environment." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEB.EFFECT", "A wooden table decorated with a teapot. Gives a rustic, yet beautiful sensation to the room." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "WoodenTableB");
                }
            }
        }
    }

    //===> WOODEN TABLE CHAIR <=========================================================================================================================
    namespace WoodenTableC_Patch
    {
        namespace WoodenTableC_TechPatch
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class WoodenTableCTechMod
            {
                private static void Postfix()
                {
                    //Techs.TECH_GROUPING["Luxury"] = new List<string>(Techs.TECH_GROUPING["Luxury"]) { "WoodenTableC" }.ToArray();

                    Db.Get().Techs.Get("Luxury").unlockedItemIDs.Add("WoodenTableC");
                }
            }
        }

        namespace WoodenTableC_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class WoodenTableCUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEC.NAME", "Wooden Table & Chair" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEC.DESC", "Unique furniture pieces grants extra decoration bonus to the environment." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.WOODENTABLEC.EFFECT", "A wooden table and chair, decorated with a teapot. Gives a rustic, yet beautiful sensation to the room." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Furniture", "WoodenTableC");
                }
            }
        }
    }

    //===> SIMPLE FIREPLACE <==========================================================================================================================
    namespace SimpleFireplace_Patch
    {
        namespace SimpleFireplace_UIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class SimpleFireplaceUI
            {
                private static void Prefix()
                {
                    string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.SIMPLEFIREPLACE.NAME", "Simple Fireplace" };
                    Strings.Add(textArray1);
                    string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.SIMPLEFIREPLACE.DESC", "A house with no fireplace is a house without a heart." };
                    Strings.Add(textArray2);
                    string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.SIMPLEFIREPLACE.EFFECT", "A simple stone fireplace. Uses wood lumber to produce heat." };
                    Strings.Add(textArray3);
                    ModUtil.AddBuildingToPlanScreen("Utilities", "SimpleFireplace");
                }
            }
        }
    }


}


