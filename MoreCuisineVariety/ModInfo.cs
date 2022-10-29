using HarmonyLib;
using System.Collections.Generic;

namespace MoreCuisineVariety
{
    class ModInfo : KMod.UserMod2
    {
        public static string Namespace { get; private set; }

        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);

            Dictionary<string, CuisinePlantsTuning.CropsTuning> dictionary1 = new Dictionary<string, CuisinePlantsTuning.CropsTuning>();
            dictionary1.Add("KakawaTree", CuisinePlantsTuning.OakTreeTuning);
            dictionary1.Add("Creamcap", CuisinePlantsTuning.CreamcapTuning);
            dictionary1.Add("SunnyWheat", CuisinePlantsTuning.SunnyWheatTuning);
            MoreCuisineVariety_Patches_Plants.CropsDictionary = dictionary1;

            Namespace = GetType().Namespace;
            Debug.Log($"{Namespace}: Loaded from: {this.mod.ContentPath}");
            Debug.Log($"{Namespace}: DLL version: {GetType().Assembly.GetName().Version} " +
                        $"supporting game build {this.mod.packagedModInfo.minimumSupportedBuild} ({this.mod.packagedModInfo.supportedContent})");
        }
    }
}