using UnityEngine;

public class Trap_Train_Trigger : MonoBehaviour
{
    [SerializeField] 
    private GameObject train;

    [SerializeField]
    private GameObject newTrain;
    
    [SerializeField]
    private Transform trainSpawnPoint;

    [SerializeField]
    private bool isSpawned = false;
    
    
    void Start()
    {
        isSpawned = false;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isSpawned)
            {
                TrainSpawner();
                isSpawned = true;
            }
        }
    }

    private void TrainSpawner()
    {
        Quaternion rot = Quaternion.Euler(0, -90f, 0);
        newTrain = Instantiate(train, trainSpawnPoint.position, rot);
    }
    
}
