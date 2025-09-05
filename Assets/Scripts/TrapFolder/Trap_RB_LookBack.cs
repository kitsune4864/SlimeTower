using System.Collections;
using UnityEngine;

public class Trap_RB_LookBack : MonoBehaviour
{
    [SerializeField]
    private Vector3 rMoveDirection = Vector3.right;
    [SerializeField]
    private Vector3 lMoveDirection = Vector3.left;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float moveDistance;
    
    private Rigidbody rb;
    private Vector3 originPosition;
    private Vector3 dosPosition;
    private Vector3 endPosition;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // 물리 엔진에 의해 영향을 받지 않도록 설정
        originPosition = transform.position;
        dosPosition = transform.position + rMoveDirection * moveDistance;
        endPosition = transform.position + lMoveDirection * moveDistance;
        
        StartCoroutine(TrapBackAndForth());
    }
    

    private IEnumerator TrapBackAndForth()
    {
        while (true)
        {
            float moveTime = 0f;
            Vector3 currentPosition = transform.position;
          
            
            
            while (moveTime < speed)
            {
                rb.MovePosition(Vector3.Lerp(currentPosition, dosPosition, moveTime / speed ));
                moveTime += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            
            moveTime = 0f;
            currentPosition = dosPosition;
            while (moveTime < speed)
            {
               rb.MovePosition(Vector3.Lerp(currentPosition, originPosition, moveTime / speed));
               moveTime += Time.fixedDeltaTime;
               yield return new WaitForFixedUpdate();
            }

            moveTime = 0f;
            currentPosition = originPosition;
            while (moveTime < speed)
            {
                rb.MovePosition(Vector3.Lerp(currentPosition, endPosition, moveTime / speed));
                moveTime += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            
            moveTime = 0f;
            currentPosition = endPosition;
            while (moveTime < speed)
            {
                rb.MovePosition(Vector3.Lerp(currentPosition, originPosition, moveTime / speed));
                moveTime += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }

        }
    }
}
