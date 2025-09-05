using System;
using UnityEngine;

public class Trap_Bullet : MonoBehaviour
{
    private enum BulletType
    {
        Bullet,
        Arrow,
    }
    [SerializeField] 
    private float bulletSpeed;
    
    private Rigidbody rb;
    
    [SerializeField]
    private BulletType bulletType;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        if (bulletType == BulletType.Bullet)
        {
            BulletShot();
        }

        if (bulletType == BulletType.Arrow)
        {
            ArrowShot();
        }
        
    }

    private void BulletShot()
    {
        rb.AddForce(Vector3.back * bulletSpeed, ForceMode.Impulse);
    }

    private void ArrowShot()
    {
        rb.AddForce(Vector3.down * bulletSpeed, ForceMode.Impulse);
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
