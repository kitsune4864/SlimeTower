using UnityEngine;

public class CubePuzzleController : MonoBehaviour
{
    private float moveCooldown = 0.2f; // 이동 시간 간격;
    private float lastMoveTime;

    public PlayerStateManager_2 playerStateManager;
    public GameObject playerObject;
    void Update()
    {
        if (Time.time - lastMoveTime < moveCooldown)
            return;
        
        int hAxis = (int)Input.GetAxisRaw("Horizontal");
        int vAxis = (int)Input.GetAxisRaw("Vertical");

        if (hAxis != 0 || vAxis != 0)
        {
            Vector3 moveVec = new Vector3(hAxis, 0, vAxis);
            playerObject.transform.position += moveVec; // 한 칸씩 이동
            playerStateManager.curStructObject.transform.position += moveVec;
            lastMoveTime = Time.time;
        }
    }
}
