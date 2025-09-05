using UnityEngine;

public class Teleport_To_Next_Floor : MonoBehaviour
{
    [SerializeField] 
    private Transform currentFloor;
    
    [SerializeField]
    private Transform nextFloor;

    [SerializeField] 
    private Transform playerSlime;
    
    
    void Start()
    {
        playerSlime = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerSlime.position = nextFloor.position;
        }
    }
}
