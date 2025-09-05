using System;
using System.Collections;
using UnityEngine;


public class Trap_Mushroom_Jump : MonoBehaviour
{
    private enum MushroomType
    {
        Jump,
        HighJump,
        Destroy,
        Hiding,
    }
    [SerializeField]
    private int padJumpForce;
    
    [SerializeField]
    private int fullJumpForce;
    
    [SerializeField]
    private MushroomType mushroomType;
    
    [SerializeField]
    private AudioSource mushroomSound;
    
    [SerializeField]
    private GameObject mExplodeParticle;
    
    [SerializeField]
    private Transform destroyParticleTransform;
    
    public AudioClip jumpSound;
    
    
    public AudioClip destroySound;
    
    void Start()
    {
        mushroomSound = GetComponent<AudioSource>();
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && mushroomType == MushroomType.Jump)
        {
            Rigidbody sRb = other.gameObject.GetComponent<Rigidbody>();
            sRb.AddForce(Vector3.up * padJumpForce, ForceMode.Impulse);
            mushroomSound.clip = jumpSound;
            mushroomSound.Play();
        }

        if (other.gameObject.CompareTag("Player") && mushroomType == MushroomType.Hiding)
        {
            Rigidbody sRb = other.gameObject.GetComponent<Rigidbody>();
            sRb.AddForce(Vector3.up * padJumpForce, ForceMode.Impulse);
            mushroomSound.clip = jumpSound;
            mushroomSound.Play();
        }

        if (other.gameObject.CompareTag("Player") && mushroomType == MushroomType.Destroy)
        {
            Rigidbody sRb = other.gameObject.GetComponent<Rigidbody>();
            sRb.AddForce(Vector3.up * padJumpForce, ForceMode.Impulse);
            BoxCollider bc = GetComponent<BoxCollider>();
            bc.isTrigger = true;
            mushroomSound.clip = destroySound;
            mushroomSound.Play();
            MushRoomDestroyParticle();
            StartCoroutine(DestroyMushroom());
        }

        if (other.gameObject.CompareTag("Player") && mushroomType == MushroomType.HighJump)
        {
            Rigidbody sRb = other.gameObject.GetComponent<Rigidbody>();
            sRb.AddForce(Vector3.up * fullJumpForce, ForceMode.Impulse);
            mushroomSound.clip = jumpSound;
            mushroomSound.pitch = 1.5f;
            mushroomSound.Play();
        }
    }

    private void MushRoomDestroyParticle()
    {
        Instantiate(mExplodeParticle, destroyParticleTransform.position, Quaternion.identity);
    }

    private IEnumerator DestroyMushroom()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
