using System;
using UnityEngine;

public class Trap_Player_Detect_Trigger : MonoBehaviour
{
    private enum TrapType
    {
        SawBlade,
    }

    [SerializeField]
    private TrapType trapType;

    [SerializeField] 
    private Trap_Bullet_Creater tBulletCreator;
   
    void Update()
    {
        if (tBulletCreator == null)
        {
            tBulletCreator = FindObjectOfType<Trap_Bullet_Creater>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (trapType == TrapType.SawBlade)
            {
                tBulletCreator.SawBladeShot();
            }
        }
    }
}
