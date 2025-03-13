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
    
    void Update()
    {
        
    }

    public void WhaleAttack()
    {
        whaleRb.AddForce(Vector3.up * whaleSpeed, ForceMode.Impulse);
        Debug.Log("고래 출발");
    }
}
