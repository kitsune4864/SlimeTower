using System;
using UnityEngine;

public class Trap_JumpToNextStage : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
    
    [SerializeField]
    private AudioSource collisionSound;

    private void Start()
    {
        collisionSound = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            collisionSound.Play();
        }
    }
}
