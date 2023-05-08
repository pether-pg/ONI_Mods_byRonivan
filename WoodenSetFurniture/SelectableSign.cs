using System;
using System.Collections.Generic;
using KSerialization;

namespace WoodenSetFurniture
{
    [SerializationConfig(MemberSerialization.OptIn)]
    class SelectableSign : KMonoBehaviour
    {
        [MyCmpGet]
        KBatchedAnimController kbac;

        [Serialize]
        public List<string> AnimationNames = new List<string>();

        [Serialize]
        public int selectedIndex = 0;

        [Serialize]
        public string IconPrefix = "";


        protected override void OnSpawn()
        {
            if (AnimationNames == null || AnimationNames.Count == 0)
                return;

            if (selectedIndex >= AnimationNames.Count)
                selectedIndex = 0;

            kbac.Play(AnimationNames[selectedIndex]);
        }

        public void SetVariant(string variant)
        {
            if (!AnimationNames.Contains(variant))
                return;

            selectedIndex = AnimationNames.FindIndex(str => str == variant);
            kbac.Play(variant);
        }
    }
}
