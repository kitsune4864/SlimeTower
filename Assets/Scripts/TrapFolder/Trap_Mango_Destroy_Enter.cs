using System;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Mango_Destroy_Enter : MonoBehaviour
{
    [SerializeField]
    private List<Trap_MangoSpawner> bMangoSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Trap_MangoSpawner spawner in bMangoSpawner)
            {
                spawner.MangoFallenStop();
            }
        }
    }
}
