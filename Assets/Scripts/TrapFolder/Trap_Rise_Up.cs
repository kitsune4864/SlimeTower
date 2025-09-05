using System;
using UnityEngine;

public class Trap_Rise_Up : MonoBehaviour
{
    [SerializeField]
    private GameObject riseUpTrap;
    
    [SerializeField]
    private float moveDistance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 lerpPosition = new Vector3(riseUpTrap.transform.localPosition.x, riseUpTrap.transform.localPosition.y + moveDistance, riseUpTrap.transform.localPosition.z);
           riseUpTrap.transform.localPosition = Vector3.Slerp(lerpPosition, Vector3.zero, Time.deltaTime * 3);
        }
    }
}
