using UnityEngine;
using DG.Tweening;

public class Trap_Squid_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject squidPrefab;
    
    [SerializeField]
    private Transform squidDestination;
    
    [SerializeField]
    private bool isDetected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isDetected)
            {
                squidPrefab.transform.DOMove(squidDestination.position, 1.5f);
                isDetected = true;
            }
        }
    }
}
