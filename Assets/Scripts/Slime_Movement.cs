using UnityEngine;

public class Slime_Movement : MonoBehaviour
{
    private CharacterController cc;
    [SerializeField]
    private float moveSpeed = 5f;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        
        cc.Move(dir * moveSpeed * Time.deltaTime );
        
    }
}
