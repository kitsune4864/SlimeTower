using System;
using TMPro;
using UnityEngine;

public class Trap_Damaged : MonoBehaviour
{
    [SerializeField] 
    private int trapDamage;

    [SerializeField]
    private string deathReason;
    
    [SerializeField]
    private TMP_Text deathReasonText;
    //private Slime_State sState;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Slime_State sState = other.gameObject.GetComponent<Slime_State>();
            sState.SlimeDamaged(trapDamage);
            BoxCollider bc = GetComponent<BoxCollider>();
            bc.isTrigger = true;

            deathReasonText.text = deathReason;
        }
    }
    
    
}
