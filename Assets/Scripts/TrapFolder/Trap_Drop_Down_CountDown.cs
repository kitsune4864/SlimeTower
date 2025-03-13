using System.Collections;
using UnityEngine;

public class Trap_Drop_Down_CountDown : MonoBehaviour
{
    private Rigidbody dDRb;
    
    void Start()
    {
        dDRb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DropCountDown());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DropCountDown()
    {
        yield return new WaitForSeconds(10f);
        dDRb.useGravity = true;
        
    }
}
