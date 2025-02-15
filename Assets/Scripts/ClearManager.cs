using UnityEngine;

public class ClearManager : MonoBehaviour
{
    // 클리어 여부 
    private bool isClear;
    // 현재 라운드 인덱스
    private int round;
    // 현재 생성된 라운드 관리하는 배열
    private GameObject[] roundStructures;
    
    // 각 라운드 프리팹
    // FIXME : 추후 scriptableOjbect나 각 라운드 프리팹 할당으로 변경.
    public GameObject roundPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClear == true)
        {
            GoNextRound();
            isClear = false;
        }
    }

    public void SetClear(bool state)
    {
        isClear = state;
    }
    /* 라운드 생성 함수 */
    
    /* 라운드 삭제 함수 */
    
    /* 다음 라운드 넘어가는 함수 */
    private void GoNextRound()
    {
        
    }
}
