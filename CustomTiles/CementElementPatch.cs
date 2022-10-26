using System;
using HarmonyLib;
using UnityEngine;

namespace CustomTiles
{
    public class CementElementPatch
    {
        [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
        public static class CementRadiation_FinaliseElement
        {
            public static void Postfix()
            {
                Element element = ElementLoader.FindElementByHash(SimHashes.Cement);
                element.radiationAbsorptionFactor = 1f;
                element.disabled = false;
                element.thermalConductivity = 3.11f;
            }
        }

        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class Cement_Patch_Db_Initialize
        {
            public static void Postfix()
            {
                Substance substance = ElementLoader.FindElementByHash(SimHashes.Cement).substance;
                Material material = new Material(ElementLoader.FindElementByHash(SimHashes.CrushedRock).substance.material)
                {
                    name = "matCement",
                    mainTexture = Assets.GetAnim("new_cement_kanim").textureList[0]
                };
                substance.material = material;
                KAnimFile anim = Assets.GetAnim("solid_cement_kanim");
                bool flag = anim != null;
                if (flag)
                {
                    substance.anim = anim;
                }
                else
                {
                    Debug.LogError("KAnimFile not found");
                }
            }
        }
    }
}