using UnityEngine;

public class Trap_Throwing_Ink : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
