using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Trap_Hebi : MonoBehaviour
{
    private enum HebiState
    {
        Quest,
        Attack,
        Return,
    }
    [SerializeField]
    private NavMeshAgent navAgent;
    
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField]
    private List<Transform> questPoints;
    
    [SerializeField]
    private HebiState hState;
    
    [SerializeField]
    private int currentPoint = 0;
    
    [SerializeField]
    private Transform returnPoint;
    
    [SerializeField]
    private Transform playerSlime;
    
    [SerializeField]
    private float hebiAttackDistance;

    [SerializeField] 
    private float hebiChaseRange;
    
    
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        hState = HebiState.Quest;
        navAgent.speed = moveSpeed;
        playerSlime = GameObject.FindGameObjectWithTag("Player").transform;
        //Debug.Log(questPoints.Count);
        
        if (questPoints.Count >= 0 && hState == HebiState.Quest)
        {
            navAgent.SetDestination(questPoints[currentPoint].position);
        }
    }

    
    void Update()
    {
        HebiRaycast();
        HebiMove();
    }

    private void HebiMove()
    {
        if (navAgent.remainingDistance < 1f)
        {
            MovePointController();
        }
    }

    private void MovePointController()
    {
        currentPoint = Random.Range(0, questPoints.Count);
        navAgent.SetDestination(questPoints[currentPoint].position);
    }
    
   /*  void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hebiChaseRange);
    } */

    private void HebiRaycast()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, hebiChaseRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                if (hit.gameObject.transform.position.y < 22)
                {
                    navAgent.SetDestination(playerSlime.position);
                }
            }
        }
    }
}
