using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Language_SO", order = 3)]
public class LocalizedLanguageSO : ScriptableObject
{
    public string messageID;
    public string koreanText;
    public string englishText;

    public string GetLocalizedText(SystemLanguage lang)
    {
        switch (lang)
        {
            case SystemLanguage.Korean: return koreanText;
            case SystemLanguage.English: return englishText;
            default: return englishText;
        }
    }
}
