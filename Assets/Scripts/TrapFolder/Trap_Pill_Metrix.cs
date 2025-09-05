using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trap_Pill_Metrix : MonoBehaviour
{
    private enum PillType
    {
        Red,
        Blue,
    }

    [SerializeField]
    private PillType pillType;

    [SerializeField]
    private GameObject jailDoor;
    
    [SerializeField]
    private GameObject pillExplodeEffect;
    
    [SerializeField]
    private bool isTriggered = false;
    
    [SerializeField]
    private List<Trap_Bullet_Creater> tBullets;
    
    void Start()
    {
        isTriggered = false;
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (pillType == PillType.Red)
            {
                Transform jDTransform = jailDoor.GetComponent<Transform>();
                jDTransform.transform.DORotate(new Vector3(0f, 140f, 0f), 2f);
                foreach (Trap_Bullet_Creater creator in tBullets)
                {
                    StartCoroutine(creator.BulletShot());
                    isTriggered = true;
                    BoxCollider bc = GetComponent<BoxCollider>();
                    
                    Quaternion rot = Quaternion.Euler(-90f, 0f, 0);
                    Instantiate(pillExplodeEffect, transform.position, rot);
                    if (isTriggered)
                    {
                        bc.isTrigger = false;
                    }
                }
            }

            if (pillType == PillType.Blue)
            {
                Quaternion rot = Quaternion.Euler(-90f, 0f, 0);
                Instantiate(pillExplodeEffect, transform.position, rot);
            }
        }
    }

    
}
