using System.Collections.Generic;
using UnityEngine;

public class TeleportToNextPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportPoint;
    [SerializeField]
    private List<GameObject> teleportPoints;
    [SerializeField]
    private int count = 0;
   
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            if (count < teleportPoints.Count)
            {
                count++;
                transform.position = teleportPoints[count].transform.position;
            }
            
            if (count >= teleportPoints.Count)
            {
                count = 0;
            }
        }
    }
}
