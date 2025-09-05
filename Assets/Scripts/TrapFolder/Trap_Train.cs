using System;
using UnityEngine;

public class Trap_Train : MonoBehaviour
{
    [SerializeField]
    private Rigidbody tRB;

    [SerializeField]
    private float trainSpeed;

    [SerializeField]
    private bool isStrike = false;
    
    [SerializeField]
    private AudioSource trainAudio;
    
    [SerializeField]
    private AudioClip trainSound;
    
    [SerializeField]
    private bool isSoundPlaying = false;
    
    
    void Start()
    {
        tRB = GetComponent<Rigidbody>();
        trainAudio = GetComponent<AudioSource>();
        isSoundPlaying = false;
    }

    
    void Update()
    {
       TrainStrike();
    }

    private void TrainStrike()
    {
        if (isStrike)
        {
            tRB.AddForce(Vector3.left * trainSpeed, ForceMode.Impulse);
        }
    }

    public void TrainStrikeDetected()
    {
        isStrike = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isSoundPlaying)
        {
            if (other.gameObject)
            {
                trainAudio.clip = trainSound;
                trainAudio.Play();
                isSoundPlaying = true;
            }
        }
    }
}
