using UnityEngine;

public class Trap_Whale_Attack : MonoBehaviour
{
    [SerializeField]
    private int whaleSpeed;
    private Rigidbody whaleRb;
    
    void Start()
    {
        whaleRb = GetComponent<Rigidbody>();
    }
    

    public void WhaleAttack()
    {
        Vector3 direction = Vector3.up;
        whaleRb.AddForce(direction.normalized * whaleSpeed, ForceMode.Impulse);
    }
}
