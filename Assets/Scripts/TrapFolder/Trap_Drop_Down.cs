using System;
using System.Collections;
using UnityEngine;

public class Trap_Drop_Down : MonoBehaviour
{
    private Rigidbody dDRb;
    
    void Start()
    {
        dDRb = GetComponent<Rigidbody>();
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dDRb.useGravity = true;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
