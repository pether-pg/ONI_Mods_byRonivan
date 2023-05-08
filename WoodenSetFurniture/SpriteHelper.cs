using System.IO;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace WoodenSetFurniture
{
    class SpriteHelper
    {
        public const string UNKNOWN = "unknown";

        public static Sprite GetSpriteForKanim(KAnimFile animFile, string animName, string spritePrefix = "")
        {
            Sprite spr = Def.GetUISpriteFromMultiObjectAnim(animFile, animName);
            if (spr.name != UNKNOWN) 
                return spr;

            string key = string.Format("{0}_{1}", spritePrefix, animName);
            if (Assets.Sprites.ContainsKey(key))
                return Assets.GetSprite(key);

            return LoadAndAddSprite(key);
        }

        public static Sprite LoadAndAddSprite(string iconName)
        {
            Texture2D tex = LoadTextureForIcon(iconName);
            if (tex == null)
                return Assets.GetSprite(UNKNOWN);

            MakeAndAddSprite(tex, iconName);
            return Assets.GetSprite(iconName);
        }

        public static Texture2D LoadTextureForIcon(string iconName)
        {
            string path = GetPathForIcon(iconName);
            if (File.Exists(path))
                return LoadTextureFromFile(path);

            Debug.Log($"{ModInfo.Namespace}: Could not find file: {path}");
            return null;
        }

        public static string GetPathForIcon(string iconName)
        {
            string iconFile = string.Format("{0}.png", iconName);
            string path = Path.Combine(GetIconDirectory(), iconFile);
            return path;
        }

        public static string GetIconDirectory()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dir = Path.Combine(path, "icons");
            return dir;
        }

        public static Texture2D LoadTextureFromFile(string filePath)
        {
            byte[] data = File.ReadAllBytes(filePath);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(data);

            Debug.Log($"{ModInfo.Namespace}: Loaded icon file {filePath}");

            return tex;
        }

        public static void MakeAndAddSprite(Texture2D texture, string name)
        {
            MakeAndAddSprite(texture, name, name);
        }

        public static void MakeAndAddSprite(Texture2D texture, string name, string keyName)
        {
            HashedString key = new HashedString(keyName);
            if (Assets.Sprites.ContainsKey(key))
            {
                Debug.Log($"{ModInfo.Namespace}: Assets.Sprites already contains {keyName} icon. Your icon will not be added.");
                return;
            }

            if (texture == null)
                return;

            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            sprite.name = name;
            Assets.Sprites.Add(key, sprite);
        }
    }
}
