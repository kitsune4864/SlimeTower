using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 클리어 여부 
    private bool isClear;
    // 현재 라운드 인덱스
    private int curRound;
    // 현재 라운드 퍼즐 오브젝트들
    private GameObject curObstacles;
    // 현재 생성된 라운드 관리하는 배열
    private GameObject[] roundStructures;
    
    public RoundData[] rounds;
    // 각 라운드 프리팹

    public GameObject playerObject;
    private Rigidbody playerRb;
    private int stdHeight = 6;
    // Update is called once per frame
    public void Start()
    {
        playerRb = playerObject.GetComponent<Rigidbody>();

        /* 처음 라운드 로드 */
        curRound = 0;
        LoadRound(rounds[curRound]);
    }
    
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
    
    /* 다음 라운드 넘어가는 함수 */
    private void GoNextRound()
    {
        if (curRound < rounds.Length)
        {
            DeleteRound(curObstacles);
            LoadRound(rounds[++curRound]);
            
        }
    }

    private void LoadRound(RoundData round)
    {
        playerRb.MovePosition(round.spawnPoint);
        playerRb.MoveRotation(Quaternion.Euler(round.spawnRotation));
        Vector3 offset = new Vector3(0f, curRound * stdHeight, 0f);
        curObstacles = Instantiate(round.obstaclePrefab, offset, Quaternion.identity);
    }

    private void DeleteRound(GameObject obstacle)
    {
        Destroy(obstacle);
    }
    
    
    /* 태초 마을 함수 */
    public void HomeSweetHome()
    {
        Debug.Log("HomeSweetHome");
        Debug.Log($"curObstacles before delete: {curObstacles}");
        DeleteRound(curObstacles);
    
        // 바로 새 라운드를 로드하지 않고, 한 프레임 기다린 후 실행
        StartCoroutine(LoadFirstRoundAfterDelay());
    }

    private IEnumerator LoadFirstRoundAfterDelay()
    {
        yield return new WaitForEndOfFrame(); // 한 프레임 대기
        Debug.Log("Deleted obstacles, now loading first round.");
    
        LoadRound(rounds[0]); // 새로운 라운드 로드
        curRound = 0;
    }
}
