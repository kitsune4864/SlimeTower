using UnityEngine;

public class Prefs_Delete_Onclick_Manager : MonoBehaviour
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Tools/Reset PlayerPrefs")]
    private static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        UnityEditor.EditorUtility.DisplayDialog("초기화 완료", "PlayerPrefs가 초기화되었습니다.", "확인");
    }
#endif
}
