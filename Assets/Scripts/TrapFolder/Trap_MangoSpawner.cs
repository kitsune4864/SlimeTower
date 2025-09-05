using System;
using System.Collections;
using UnityEngine;

public class Trap_MangoSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Mango;

    private GameObject newMango;
    
    [SerializeField]
    private GameObject bigMango;
    
    private GameObject newBigMango;
    
    [SerializeField]
    private int sMangoRespawnCount;
    
    [SerializeField]
    private float bMangoRespawnCount;
    
    [SerializeField] 
    private int spawnCount;

    [SerializeField]
    private int bigMangoCount;
    
    private Coroutine mangoCoroutine;
    
    public void MangoFallen()
    {
        if (mangoCoroutine == null)
        {
            mangoCoroutine = StartCoroutine(MangoFallenCount());
        }

    }

    public void MangoFallenStop()
    {
        if (mangoCoroutine != null)
        {
            StopCoroutine(mangoCoroutine);
        }
        
        Destroy(newMango);
        Destroy(newBigMango);
        
    }

    private IEnumerator MangoFallenCount()
    {
        while (true)
        {
            if (bigMangoCount > spawnCount)
            {
                newMango = Instantiate(Mango, transform.position, Quaternion.identity);
                spawnCount++;
                yield return new WaitForSeconds(sMangoRespawnCount);
            }

            if (bigMangoCount <= spawnCount)
            {
                newBigMango = Instantiate(bigMango, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(bMangoRespawnCount);
            }
        }
    }
    
}
