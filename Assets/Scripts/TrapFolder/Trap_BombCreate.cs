using System;
using System.Collections;
using UnityEngine;

public class Trap_BombCreate : MonoBehaviour
{
    [SerializeField]
    private GameObject bombPrefab;
    
    [SerializeField]
    private float bombCount;

    [SerializeField]
    private float bombLimitCount;
    
    [SerializeField]
    private bool isDetected = false;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bombCount += Time.deltaTime;

            if (bombCount >= bombLimitCount)
            {
                if (!isDetected)
                {
                    BombCreateDetectedPlayer();
                    isDetected = true;
                }
                
            }
        }
    }

    private void BombCreateDetectedPlayer()
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
    }
}
