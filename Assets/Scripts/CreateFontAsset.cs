using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;
using UnityEditor;
using TMPro;

public class CreateFontAsset : MonoBehaviour
{
    private TMP_Text textComponent;
    public Font sourceFont;
    public TMP_FontAsset fontAsset;

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        fontAsset = TMP_FontAsset.CreateFontAsset(
            sourceFont, 30, 5, GlyphRenderMode.SDFAA, 1024, 1024, AtlasPopulationMode.Dynamic);
        fontAsset.TryAddCharacters("Test");
        textComponent.font = fontAsset;
        
        string fontAssetPath = "Assets/Z.FontAssets/TextMeshProFontAsset/a.asset";
        AssetDatabase.CreateAsset(fontAsset, fontAssetPath);
        AssetDatabase.AddObjectToAsset(fontAsset.material, fontAsset);
        AssetDatabase.AddObjectToAsset(fontAsset.atlasTexture, fontAsset);
        AssetDatabase.SaveAssets();
    }
}
