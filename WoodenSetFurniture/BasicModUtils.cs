﻿using STRINGS;

namespace WoodenSetFurniture
{
    class BasicModUtils
    {
        public static void RegisterBuildingStrings(string id, string name, string description, string effect)
        {
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{id.ToUpperInvariant()}.NAME", UI.FormatAsLink(name, id));
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{id.ToUpperInvariant()}.DESC", description);
            Strings.Add($"STRINGS.BUILDINGS.PREFABS.{id.ToUpperInvariant()}.EFFECT", effect);
        }

        public static void MakeSideScreenStrings(string key, string name)
        {
            Strings.Add(key, name);
        }
    }
}
