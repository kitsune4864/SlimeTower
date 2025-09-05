using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Trap_Chase_Domain : MonoBehaviour
{
    [SerializeField]
    private GameObject dog_Enemy;

    private GameObject newSkr_Enemy;

    [SerializeField]
    private GameObject dog_SpawnPoint;
    
    [SerializeField]
    private Coroutine dogSpawn;
    
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
            dogSpawn = StartCoroutine(DogSpawn());
        }
    }
    
    private IEnumerator DogSpawn()
    {
        Vector3 spawnPoint = dog_SpawnPoint.transform.position;
        newSkr_Enemy = Instantiate(dog_Enemy, spawnPoint,quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
