using System;
using UnityEngine;

public class System_Destroy_OnColl : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
