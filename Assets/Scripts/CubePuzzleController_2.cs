using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePuzzleController_2 : MonoBehaviour
{
    private float moveCooldown = 0.2f; // 이동 시간 간격;
    private float lastMoveTime;
    
    public PlayerStateManager_2 playerStateManager;
    public GameObject playerObject;
    
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float spinSpeed = 270;
    [SerializeField] private Transform fakeCube = null;
    
    private Vector3 dir;
    private Vector3 destPos;
    private Vector4 rotDir;
    private Quaternion destRot;
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time - lastMoveTime < moveCooldown)
                return;
            else
            {
                StartAction();
            }
        }
    }

    void StartAction()
    {
        // 방향 계산
        dir.Set(Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal"));
        
        // 이동 목표값 계산
        destPos = playerObject.transform.position+new Vector3(dir.x,0f,dir.z);

        rotDir = new Vector3(-dir.z, 0f, -dir.x);
        fakeCube.RotateAround(playerStateManager.transform.position, rotDir, spinSpeed);
        destRot = fakeCube.rotation;
        StartCoroutine(MoveCo());
        StartCoroutine(SpinCo());
    }

    IEnumerator MoveCo()
    {
        while (Vector3.SqrMagnitude(playerStateManager.curStructObject.transform.position-destPos) >= 0.001f)
        {
            playerStateManager.curStructObject.transform.position = Vector3.MoveTowards(playerStateManager.curStructObject.transform.position, destPos,
                moveSpeed * Time.deltaTime);
            yield return null;
        }

        playerStateManager.curStructObject.transform.position = destPos;
    }

    IEnumerator SpinCo()
    {
        Transform realTransform = playerStateManager.curStructObject.transform;
        while (Quaternion.Angle(playerStateManager.curStructObject.transform.rotation, destRot) > 0.5f)
        {
            
            realTransform.rotation = Quaternion.RotateTowards(realTransform.rotation, destRot, spinSpeed * Time.deltaTime);
            yield return null;
        }
        realTransform.rotation = destRot;
    }
}
