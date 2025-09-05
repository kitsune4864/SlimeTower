using UnityEngine;

public class Trap_AddForce : MonoBehaviour
{
    [SerializeField] 
    private float objectSpeed;
    
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.AddForce(Vector3.back * objectSpeed, ForceMode.Impulse);
    }
}
