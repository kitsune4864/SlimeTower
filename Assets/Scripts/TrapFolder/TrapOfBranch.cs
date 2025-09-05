using UnityEngine;

public class TrapOfBranch : MonoBehaviour
{
    private Trap_Branch_Attack tBA;
    
    void Start()
    {
        tBA = FindObjectOfType<Trap_Branch_Attack>();
    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tBA.BranchAttack();
        }
    }
}
