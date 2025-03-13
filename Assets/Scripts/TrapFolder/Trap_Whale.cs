using System.Collections;
using UnityEngine;

public class Trap_Whale : MonoBehaviour
{
    [SerializeField]
    private Trap_Whale_Attack tW_A;
    
    void Start()
    {
        tW_A = FindObjectOfType<Trap_Whale_Attack>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tW_A.WhaleAttack();
        }
    }
    
}
