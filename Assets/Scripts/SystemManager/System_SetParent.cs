using System;
using System.Collections.Generic;
using UnityEngine;

public class System_SetParent : MonoBehaviour
{
    private Dictionary<Transform, Vector3> originalScale = new Dictionary<Transform, Vector3>();
   

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transform playerTransform = other.gameObject.transform;

            if (!originalScale.ContainsKey(playerTransform))
            {
                originalScale[playerTransform] = playerTransform.localScale;
                
            }
            other.transform.SetParent(transform, true);
            
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
       Transform playerTransform = other.gameObject.transform;

       if (originalScale.TryGetValue(playerTransform, out Vector3 savedScale))
       {
           other.transform.SetParent(null);
           playerTransform.localScale = savedScale;
           originalScale.Remove(playerTransform);
       }
       
    }
}
