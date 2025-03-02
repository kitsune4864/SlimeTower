using System;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private GameManager gm;
    
    void Start()
    {
       gm = GameObject.Find("GameManager").GetComponent<GameManager>();
       if (gm == null)
       {
           Debug.LogError("GameManager not found");
       }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.HomeSweetHome();
        }
    }
}
