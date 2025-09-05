using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Short_Cut_RiseUp : MonoBehaviour
{
    [SerializeField]
    private Transform riseUpTarget;
    
    [SerializeField]
    private float riseUpSpeed;
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
            RiseUpDoTween();
        }
    }

    private void RiseUpDoTween()
    {
        transform.DOMove(riseUpTarget.position, riseUpSpeed);
    }

    
}
