using UnityEngine;
using UnityEditor;
using UnityEngine.TextCore.LowLevel;
using TMPro;
public class MenuItem_CreateFontAsset
{
    [MenuItem("TextMeshPro Helper/CreateFontAsset")]
    static void CreateAsset()
    {
        Font font = AssetDatabase.LoadAssetAtPath<Font>(
            "Assets/Z.FontAssets/Font/HuaGuangGangTieZhiHei.ttf");
        string fontText = AssetDatabase.LoadAssetAtPath<TextAsset>(
            "Assets/Z.FontAssets/FontCharacter/FontCharacter.txt").text;
        TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(
            font, 24, 4, GlyphRenderMode.SDFAA, 4096, 4096,AtlasPopulationMode.Dynamic);
        fontAsset.TryAddCharacters(fontText);
        fontAsset.atlasPopulationMode = AtlasPopulationMode.Static;

        string fontAssetPath = "Assets/Z.FontAssets/TextMeshProFontAsset/FontAsset.asset";
        AssetDatabase.CreateAsset(fontAsset, fontAssetPath);
        AssetDatabase.AddObjectToAsset(fontAsset.material, fontAsset);
        AssetDatabase.AddObjectToAsset(fontAsset.atlasTexture, fontAsset);
        AssetDatabase.SaveAssets();
    }
}
