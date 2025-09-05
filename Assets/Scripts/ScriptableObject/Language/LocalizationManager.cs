using UnityEngine;

public static class LocalizationManager
{
    public static SystemLanguage CurrentLanguage { get; private set; }

    static LocalizationManager()
    {
        CurrentLanguage = Application.systemLanguage;
    }

    public static void SetLanguage(SystemLanguage lang)
    {
        CurrentLanguage = lang;
        Debug.Log($"언어가 {lang}으로 설정되었습니다.");
    }
}
