using System.Collections;
using UnityEngine;

public class Trap_TimeLimitBomb : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(TimeLimit());
    }
    

    private IEnumerator TimeLimit()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        
    }
}
