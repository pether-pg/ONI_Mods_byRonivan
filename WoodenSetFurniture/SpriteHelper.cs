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

        // code from https://github.com/Sgt-Imalas/Sgt_Imalas-Oni-Mods/blob/d0b25100d947dc632b3257f63a248e5827f925ed/BawoonFwiend/ModAssets.cs#L106
        // use it to get sprite from kanim based on frame index        
        /*public static Sprite GetSpriteFrom(KAnimFile animFile, KAnim.Build.Symbol symbol)
        {
            KAnimFileData data = animFile.GetData();
            int frame2 = default(KAnim.Anim.FrameElement).frame;
            KAnim.Build.SymbolFrame symbolFrame = symbol.GetFrame(frame2).symbolFrame;
            if (symbolFrame == null)
            {
                Debug.Log("SymbolFrame [" + frame2 + "] is missing");
                return Assets.GetSprite("unknown");
            }

            Texture2D texture = data.build.GetTexture(0);
            Debug.Assert(texture != null, "Invalid texture on " + animFile.name);
            float x = symbolFrame.uvMin.x;
            float x2 = symbolFrame.uvMax.x;
            float y = symbolFrame.uvMax.y;
            float y2 = symbolFrame.uvMin.y;
            int num = (int)((float)texture.width * Mathf.Abs(x2 - x));
            int num2 = (int)((float)texture.height * Mathf.Abs(y2 - y));
            float num3 = Mathf.Abs(symbolFrame.bboxMax.x - symbolFrame.bboxMin.x);
            Rect rect = default(Rect);
            rect.width = num;
            rect.height = num2;
            rect.x = (int)((float)texture.width * x);
            rect.y = (int)((float)texture.height * y);
            float pixelsPerUnit = 100f;
            if (num != 0)
            {
                pixelsPerUnit = 100f / (num3 / (float)num);
            }

            Sprite sprite = Sprite.Create(texture, rect, false ? new Vector2(0.5f, 0.5f) : Vector2.zero, pixelsPerUnit, 0u, SpriteMeshType.FullRect);
            return sprite;
        }*/
    }
}
