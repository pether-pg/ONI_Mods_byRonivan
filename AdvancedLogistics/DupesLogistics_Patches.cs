using HarmonyLib;
using System;
using UnityEngine;

namespace AdvancedLogistics
{
    //=== TRANSFER ARM ================================================================================================
    namespace TransferArm_Patch
    {
        namespace LogisticTransferArm_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticTransferArmTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_LogisticAutoSweeper == true)
                    {
                        Db.Get().Techs.Get("SmartStorage").unlockedItemIDs.Add(LogisticTransferArmConfig.ID);
                    }
                        
                }
            }
        }

        namespace LogisticTransferArmUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticTransferArmUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_LogisticAutoSweeper == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICTRANSFERARM.NAME", LogisticTransferArmConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICTRANSFERARM.DESC", LogisticTransferArmConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICTRANSFERARM.EFFECT", LogisticTransferArmConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", LogisticTransferArmConfig.ID);
                    }
                }
            }
        }
    }

    //=== LOGISTIC RAIL ===============================================================================================
    namespace LogisticRail_Patch
    {
        namespace LogisticRail_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticRailTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_LogisticRail == true)
                    {
                        Db.Get().Techs.Get("SmartStorage").unlockedItemIDs.Add(LogisticRailConfig.ID);
                    }                       
                }
            }
        }

        namespace LogisticRailUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticRailUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_LogisticRail == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICRAIL.NAME", LogisticRailConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICRAIL.DESC", LogisticRailConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICRAIL.EFFECT", LogisticRailConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", LogisticRailConfig.ID);
                    }
                }
            }
        }
    }

    //=== RAIL BRIDGE =================================================================================================
    namespace LogisticBridge_Patch
    {
        namespace LogisticBridge_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticBridgeTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_LogisticBridge == true)
                    {
                        Db.Get().Techs.Get("SmartStorage").unlockedItemIDs.Add(LogisticBridgeConfig.ID);
                    }
                }
            }
        }

        namespace LogisticBridgeUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticBridgeUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_LogisticBridge == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICBRIDGE.NAME", LogisticBridgeConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICBRIDGE.DESC", LogisticBridgeConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICBRIDGE.EFFECT", LogisticBridgeConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", LogisticBridgeConfig.ID);
                    }
                }
            }
        }
    }

    //=== LOADER ======================================================================================================
    namespace LogisticLoader_Patch
    {
        namespace LogisticLoader_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticLoaderTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_LogisticLoader == true)
                    {
                        Db.Get().Techs.Get("SmartStorage").unlockedItemIDs.Add(LogisticLoaderConfig.ID);
                    }                        
                }
            }
        }

        namespace LogisticLoaderUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticLoaderUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_LogisticLoader == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICLOADER.NAME", LogisticLoaderConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICLOADER.DESC", LogisticLoaderConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICLOADER.EFFECT", LogisticLoaderConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", LogisticLoaderConfig.ID);
                    }
                }
            }
        }
    }

    //=== OUTBOX ======================================================================================================
    namespace LogisticReceptacle_Patch
    {
        namespace LogisticOutBox_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticOutBoxTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_LogisticOutBox == true)
                    {
                        Db.Get().Techs.Get("SmartStorage").unlockedItemIDs.Add(LogisticOutBoxConfig.ID);
                    }                       
                }
            }
        }

        namespace LogisticOutBoxUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticOutBoxUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_LogisticOutBox == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICOUTBOX.NAME", LogisticOutBoxConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICOUTBOX.DESC", LogisticOutBoxConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICOUTBOX.EFFECT", LogisticOutBoxConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", LogisticOutBoxConfig.ID);
                    }
                }
            }
        }
    }

    //=== FILTER ======================================================================================================
    namespace LogisticFilter_Patch
    {
        namespace LogisticFilter_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticFilterTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_LogisticFilter == true)
                    {
                        Db.Get().Techs.Get("SolidManagement").unlockedItemIDs.Add(LogisticFilterConfig.ID);
                    }                       
                }
            }
        }

        namespace LogisticFilterUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticFilterUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_LogisticFilter == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICFILTER.NAME", LogisticFilterConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICFILTER.DESC", LogisticFilterConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICFILTER.EFFECT", LogisticFilterConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", LogisticFilterConfig.ID);
                    }
                }
            }
        }
    }

    //=== CHUTE =======================================================================================================
    namespace LogisticVent_Patch
    {
        namespace LogisticVent_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticVentTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_LogisticVent == true)
                    {
                        Db.Get().Techs.Get("SmartStorage").unlockedItemIDs.Add(LogisticVentConfig.ID);
                    }
                }
            }
        }

        namespace LogisticVentUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticVentUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_LogisticVent == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICVENT.NAME", LogisticVentConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICVENT.DESC", LogisticVentConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.LOGISTICVENT.EFFECT", LogisticVentConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", LogisticVentConfig.ID);
                    }
                }
            }
        }
    }

    //=== STORAGE POD C ===============================================================================================
    namespace StoragePod_C_Patch
    {
        namespace LogisticStoragePod_C_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticStoragePod_CTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_StoragePod_C == true)
                    {
                        Db.Get().Techs.Get("BasicRefinement").unlockedItemIDs.Add(StoragePod_C_Config.ID);
                    }                       
                }
            }
        }

        namespace LogisticStoragePod_CUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticStoragePod_CUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_StoragePod_C == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_C.NAME", StoragePod_C_Config.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_C.DESC", StoragePod_C_Config.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_C.EFFECT", StoragePod_C_Config.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", StoragePod_C_Config.ID);
                    }
                }
            }
        }
    }

    //=== STORAGE POD B ===============================================================================================
    namespace StoragePod_B_Patch
    {
        namespace LogisticStoragePod_B_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticStoragePod_BTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_StoragePod_B == true)
                    {
                        Db.Get().Techs.Get("BasicRefinement").unlockedItemIDs.Add(StoragePod_B_Config.ID);
                    }                       
                }
            }
        }

        namespace LogisticStoragePod_BUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticStoragePod_BUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_StoragePod_B == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_B.NAME", StoragePod_B_Config.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_B.DESC", StoragePod_B_Config.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_B.EFFECT", StoragePod_B_Config.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", StoragePod_B_Config.ID);
                    }
                }
            }
        }
    }

    //=== STORAGE POD A ===============================================================================================
    namespace StoragePod_A_Patch
    {
        namespace LogisticStoragePod_A_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticStoragePod_ATechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_StoragePod_A == true)
                    {
                        Db.Get().Techs.Get("BasicRefinement").unlockedItemIDs.Add(StoragePod_A_Config.ID);
                    }                        
                }
            }
        }

        namespace LogisticStoragePod_AUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticStoragePod_AUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_StoragePod_A == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_A.NAME", StoragePod_A_Config.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_A.DESC", StoragePod_A_Config.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.STORAGEPOD_A.EFFECT", StoragePod_A_Config.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", StoragePod_A_Config.ID);
                    }
                }
            }
        }
    }

    //=== REFRIGERATED STORAGE CABINET ================================================================================
    namespace CabinetFrozen_Patch
    {
        namespace LogisticCabinetFrozen_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticCabinetFrozenTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_CabinetFrozen == true)
                    {
                        Db.Get().Techs.Get("SmartStorage").unlockedItemIDs.Add(CabinetFrozenConfig.ID);
                    }                        
                }
            }
        }

        namespace LogisticCabinetFrozenUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticCabinetFrozenUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_CabinetFrozen == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.CABINETFROZEN.NAME", CabinetFrozenConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.CABINETFROZEN.DESC", CabinetFrozenConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.CABINETFROZEN.EFFECT", CabinetFrozenConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", CabinetFrozenConfig.ID);
                    }
                }
            }
        }
    }

    //=== STORAGE CABINET =============================================================================================
    namespace CabinetNormal_Patch
    {
        namespace LogisticCabinetNormal_Tech
        {
            [HarmonyPatch(typeof(Db), "Initialize")]
            internal class LogisticCabinetNormalTechMod
            {
                private static void Postfix()
                {
                    if (ModSettings.Instance.Enable_CabinetNormal == true)
                    {
                        Db.Get().Techs.Get("BasicRefinement").unlockedItemIDs.Add(CabinetNormalConfig.ID);
                    }                       
                }
            }
        }

        namespace LogisticCabinetNormalUIPatch
        {
            [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
            internal class LogisticCabinetNormalUI
            {
                private static void Prefix()
                {
                    if (ModSettings.Instance.Enable_CabinetNormal == true)
                    {
                        string[] textArray1 = new string[] { "STRINGS.BUILDINGS.PREFABS.CABINETNORMAL.NAME", CabinetNormalConfig.DisplayName };
                        Strings.Add(textArray1);
                        string[] textArray2 = new string[] { "STRINGS.BUILDINGS.PREFABS.CABINETNORMAL.DESC", CabinetNormalConfig.Description };
                        Strings.Add(textArray2);
                        string[] textArray3 = new string[] { "STRINGS.BUILDINGS.PREFABS.CABINETNORMAL.EFFECT", CabinetNormalConfig.Effect };
                        Strings.Add(textArray3);
                        ModUtil.AddBuildingToPlanScreen("Conveyance", CabinetNormalConfig.ID);
                    }
                }
            }
        }
    }
}
