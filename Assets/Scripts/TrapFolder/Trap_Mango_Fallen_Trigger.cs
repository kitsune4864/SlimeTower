using System.Collections.Generic;
using UnityEngine;

public class Trap_Mango_Fallen_Trigger : MonoBehaviour
{
    [SerializeField]
    private List<Trap_MangoSpawner> bMangoSpawner;
    
    [SerializeField]
    private bool isDetected = false;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Trap_MangoSpawner spawner in bMangoSpawner)
            {
                
                    spawner.MangoFallen();
                    
                
            }
        }
    }
}
