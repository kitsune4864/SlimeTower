using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Trap_Chase_Domain : MonoBehaviour
{
    [SerializeField]
    private GameObject skr_Enemy;

    private GameObject newSkr_Enemy;

    [SerializeField]
    private GameObject skr_SpawnPoint;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SkrSpawn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(SkrSpawn());
            Destroy(newSkr_Enemy);
        }
    }

    private IEnumerator SkrSpawn()
    {
        Vector3 spawnPoint = skr_SpawnPoint.transform.position;
        newSkr_Enemy = Instantiate(skr_Enemy, spawnPoint,quaternion.identity);
        yield return null;
    }
}
