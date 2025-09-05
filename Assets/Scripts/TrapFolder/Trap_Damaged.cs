using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Trap_Damaged : MonoBehaviour
{
    [SerializeField] 
    private float trapDamage;
    
    [SerializeField]
    private LocalizedLanguageSO localizedDeathReason;
    
    [SerializeField]
    private TMP_Text deathReasonText;
    
    void Update()
    {
        if (deathReasonText == null)
        {
            deathReasonText = GameObject.FindGameObjectWithTag("DamageText").GetComponent<TMP_Text>();
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Slime_State sState = other.gameObject.GetComponent<Slime_State>();
            sState.SlimeDamaged(trapDamage);
            
            if (trapDamage >= 10 && sState.sState == SlimeState.Alive)
            {
                string msg = localizedDeathReason.GetLocalizedText(LocalizationManager.CurrentLanguage);
                deathReasonText.text = msg;
            }

            if (sState.sState == SlimeState.Dead)
            {
                trapDamage = 0;
            }
        }
        
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("TrainStructure"))
        {
            StartCoroutine(TrapDamagedCancler());
        }
    }

    IEnumerator TrapDamagedCancler()
    {
        yield return new WaitForSeconds(1f);
        trapDamage = 0;
    }
}
