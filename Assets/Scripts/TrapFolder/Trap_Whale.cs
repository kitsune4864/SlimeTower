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
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WhaleAttackTrigger());
        }
    }

    private IEnumerator WhaleAttackTrigger()
    {
        tW_A.WhaleAttack();
        yield return new WaitForFixedUpdate();
    }
    
}
