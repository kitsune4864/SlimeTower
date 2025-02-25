using System;
using UnityEngine;

public class TrapOfCave : MonoBehaviour
{
    [SerializeField]
    private GameObject trapRock;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trapRock.GetComponent<Rigidbody>().isKinematic = false;
            trapRock.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
