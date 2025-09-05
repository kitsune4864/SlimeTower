using TMPro;
using UnityEngine;

public class Collection_Count_EndScene : MonoBehaviour
{
    [SerializeField]
    private int collectedCount = 0;
    
    [SerializeField]
    private int totalCount = 0;
    
    public TMP_Text collectionResultText;
    
    void Start()
    {
        for (int i = 0; i < totalCount; i++)
        {
            string key = $"Collected_{i}";
            if (PlayerPrefs.HasKey(key) && PlayerPrefs.GetInt(key) == 1)
            {
                collectedCount++;
            }
        }
        
        Debug.Log($"{collectedCount}/{totalCount}");
        
        collectionResultText.text = $"Your Collection :    {collectedCount}    /    {totalCount}";
    }

    
    void Update()
    {
        
    }
}
