using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Short_Cut_Shark : MonoBehaviour
{
    
    [SerializeField]
    private Transform destination;

    [SerializeField]
    private float destinationMoveSpeed;
    
    [SerializeField]
    private float moveSpeed;
    
    private NavMeshAgent sharkAgent;
    
    [SerializeField]
    private List<Transform> waypoints;
    
    [SerializeField]
    private int currentPoint;
    
    [SerializeField]
    private bool hasArrived = false;

    [SerializeField]
    private bool isRidding;
    
    void Start()
    {
        sharkAgent = GetComponent<NavMeshAgent>();
        sharkAgent.speed = moveSpeed;
    }

    
    void Update()
    {
        if (!isRidding)
        {
            SharkAI();
        }
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어 접촉");
            sharkAgent.ResetPath();
            sharkAgent.isStopped = true;
            isRidding = true;
            StartCoroutine(SharkCoroutine());
        }
        else
        {
            
        }
    }
    
    private void SharkAI()
    {
        if (currentPoint >= waypoints.Count)
        {
            currentPoint = 0;
        }

        sharkAgent.SetDestination(waypoints[currentPoint].position);
        
        if (!hasArrived && sharkAgent.remainingDistance < 1.5f)
        {
            currentPoint++;
            hasArrived = true;
        }

        if (hasArrived && sharkAgent.remainingDistance > 1.5f)
        {
            hasArrived = false;
        }
    }

    private IEnumerator SharkCoroutine()
    {
        transform.position = Vector3.Lerp(transform.position, destination.position, destinationMoveSpeed);
        transform.rotation = Quaternion.identity;
        yield return null;
        
        isRidding = false;
    }
    
}
