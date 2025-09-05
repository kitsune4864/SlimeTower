using System;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public int spawnIndex;
    
    [SerializeField]
    private GameObject collectParticles;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            string key = $"Collected_{spawnIndex}";
            PlayerPrefs.SetInt(key, 1);
            PlayerPrefs.Save();
            
            Instantiate(collectParticles, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}
