using System;
using UnityEngine;
using DG.Tweening;
public class System_Door_Open_Dotween : MonoBehaviour
{
    [SerializeField] 
    private GameObject doorPrefab;

    [SerializeField] 
    private AudioSource doorSound;
    
    [SerializeField]
    private AudioClip doorOpenSound;
    
    void Start()
    {
        doorSound = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorPrefab.transform.DORotate(new Vector3(0f, 140f , 0f), 2f);
            DoorSoundPlayer();
        }
    }

    private void DoorSoundPlayer()
    {
        doorSound.clip = doorOpenSound;
        doorSound.Play();
    }
}
