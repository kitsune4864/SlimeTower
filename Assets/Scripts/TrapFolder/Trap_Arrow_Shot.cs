using System;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Arrow_Shot : MonoBehaviour
{
    [SerializeField] 
    private List<Transform> arrowsTransform;
    
    [SerializeField]
    private GameObject arrowPrefab;
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
            foreach (Transform arrow in arrowsTransform)
            {
                Quaternion rotation = Quaternion.Euler(-90f, 0, 0);
                Instantiate(arrowPrefab, arrow.position, rotation);
            }
            
        }
    }
}
