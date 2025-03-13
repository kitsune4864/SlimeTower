using System.Collections.Generic;
using UnityEngine;

public class TeleportToNextPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportPoint;
    private List<GameObject> teleportPoints;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            transform.position = teleportPoint.transform.position;
        }
    }
}
