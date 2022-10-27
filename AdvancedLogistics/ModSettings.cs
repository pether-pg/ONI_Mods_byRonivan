using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PeterHan.PLib;
using PeterHan.PLib.Options;

namespace AdvancedLogistics
{
    [RestartRequired]
    [JsonObject(MemberSerialization.OptIn)]
    [ConfigFile("CustomReservoirsBaseConfig.json", true)]
    public class ModSettings
    {
        //==================================================================> Refrigerated Storage Cabinet        
        [Option("Refrigerated Storage Cabinet", "Storage Capacity.", null)]
        [Limit(100, 990000)]
        [JsonProperty]
        public int Capacity_CabinetFrozen { get; set; }

        //==================================================================> Normal Storage Cabinet       
        [Option("Storage Cabinet", "Storage Capacity.", null)]
        [Limit(100, 990000)]
        [JsonProperty]
        public int Capacity_CabinetNormal { get; set; }

        //==================================================================> Storage Pod A       
        [Option("Green Storage Pod", "Storage Capacity.", null)]
        [Limit(100, 990000)]
        [JsonProperty]
        public int Capacity_StoragePod_A { get; set; }

        //==================================================================> Storage Pod B        
        [Option("Brown Storage Pod", "Storage Capacity.", null)]
        [Limit(100, 990000)]
        [JsonProperty]
        public int Capacity_StoragePod_B { get; set; }

        //==================================================================> Storage Pod C        
        [Option("Yellow Storage Pod", "Storage Capacity.", null)]
        [Limit(100, 990000)]
        [JsonProperty]
        public int Capacity_StoragePod_C { get; set; }

        //==================================================================> LOGISTIC RECEPTACLE       
        [Option("Logistic Receptacle", "Storage Capacity.", null)]
        [Limit(100, 990000)]
        [JsonProperty]
        public int Capacity_LogisticOutBox { get; set; }

        //==================================================================> LOGISTIC AUTO-SWEEPER     
        [Option("Logistic Auto-Sweeper Range", "Auto-Sweeper Reach Zone.", null)]
        [Limit(4, 12)]
        [JsonProperty]
        public int Range_AutoSweeper { get; set; }

        //==================================================> Option for Enable/Disable Refrigerated Storage Cabinet 
        [Option("Enable Refrigerated Storage Cabinet", "")]
        [JsonProperty]
        public bool Enable_CabinetFrozen { get; set; }

        //==================================================> Option for Enable/Disable Normal Storage Cabinet 
        [Option("Enable Storage Cabinet", "")]
        [JsonProperty]
        public bool Enable_CabinetNormal { get; set; }

        //==================================================> Option for Enable/Disable Storage Pod A 
        [Option("Enable Green Storage Pod", "")]
        [JsonProperty]
        public bool Enable_StoragePod_A { get; set; }

        //==================================================> Option for Enable/Disable Storage Pod B 
        [Option("Enable Brown Storage Pod", "")]
        [JsonProperty]
        public bool Enable_StoragePod_B { get; set; }

        //==================================================> Option for Enable/Disable Storage Pod C 
        [Option("Enable Yellow Storage Pod", "")]
        [JsonProperty]
        public bool Enable_StoragePod_C { get; set; }

        //==================================================> Option for Enable/Disable Logistic Chute
        [Option("Enable Logistic Chute", "")]
        [JsonProperty]
        public bool Enable_LogisticVent { get; set; }

        //==================================================> Option for Enable/Disable Logistic Solid Filter
        [Option("Enable Logistic Solid Filter", "")]
        [JsonProperty]
        public bool Enable_LogisticFilter { get; set; }

        //==================================================> Option for Enable/Disable Logistic Receptacle
        [Option("Enable Logistic Receptacle", "")]
        [JsonProperty]
        public bool Enable_LogisticOutBox { get; set; }

        //==================================================> Option for Enable/Disable Logistic Loader
        [Option("Enable Logistic Loader", "")]
        [JsonProperty]
        public bool Enable_LogisticLoader { get; set; }

        //==================================================> Option for Enable/Disable Logistic Bridge
        [Option("Enable Logistic Bridge", "")]
        [JsonProperty]
        public bool Enable_LogisticBridge{ get; set; }

        //==================================================> Option for Enable/Disable Logistic Rail
        [Option("Enable Logistic Rail", "")]
        [JsonProperty]
        public bool Enable_LogisticRail { get; set; }

        //==================================================> Option for Enable/Disable Logistic Auto-Sweeper
        [Option("Enable Logistic Auto-Sweeper", "")]
        [JsonProperty]
        public bool Enable_LogisticAutoSweeper { get; set; }


        //=================================================================================
        private static ModSettings _instance = null;
        public static ModSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModSettings();
                }
                return _instance;
            }
        }

        //===> Default Settings <==========================================================
        public ModSettings()
        {
            Capacity_CabinetFrozen = 100;
            Capacity_CabinetNormal = 100;
            Capacity_StoragePod_A = 100;
            Capacity_StoragePod_B = 100;
            Capacity_StoragePod_C = 100;
            Capacity_LogisticOutBox = 100;
            Range_AutoSweeper = 10;

            Enable_CabinetFrozen = true;
            Enable_CabinetNormal = true;
            Enable_StoragePod_A = true;
            Enable_StoragePod_B = true;
            Enable_StoragePod_C = true;
            Enable_LogisticVent = true;
            Enable_LogisticFilter = true;
            Enable_LogisticOutBox = true;
            Enable_LogisticLoader = true;
            Enable_LogisticBridge = true;
            Enable_LogisticRail = true;
            Enable_LogisticAutoSweeper = true;

        }
    }
}
