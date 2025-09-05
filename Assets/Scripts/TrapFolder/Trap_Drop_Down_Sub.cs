using UnityEngine;

public class Trap_Drop_Down_Sub : MonoBehaviour
{
    private Rigidbody dRb;
    void Start()
    {
        dRb = GetComponent<Rigidbody>();
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dRb.useGravity = true;
            dRb.isKinematic = false;
        }
    }
}
