using System;
using System.Collections;
using UnityEngine;

public class Trap_Drop_Down : MonoBehaviour
{
    private Rigidbody dDRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dDRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
