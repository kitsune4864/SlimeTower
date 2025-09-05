using System;
using UnityEngine;

public class Sound_Box_Collision : MonoBehaviour
{
    [SerializeField]
    private AudioSource trapSound;

    [SerializeField]
    private AudioClip soundClip;
    void Start()
    {
        trapSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground"))
        {
            trapSound.clip = soundClip;
            trapSound.Play();
        }
    }
}
