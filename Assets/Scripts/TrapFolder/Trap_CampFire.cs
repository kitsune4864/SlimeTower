using System;
using TMPro;
using UnityEngine;

public class Trap_CampFire : MonoBehaviour
{
    [SerializeField] 
    private float trapDamage;
    
    [SerializeField]
    private LocalizedLanguageSO localizedDeathReason;
    
    [SerializeField]
    private TMP_Text deathReasonText;

    [SerializeField]
    private float burnedTimer;

    [SerializeField]
    private float burnedRange;

    [SerializeField]
    private Transform playerSlime;
    void Start()
    {
        playerSlime = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        CampFireDetected();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Slime_State sState = other.gameObject.GetComponent<Slime_State>();
            
            if (trapDamage >= 10 && sState.sState == SlimeState.Alive)
            {
                sState.SlimeDamaged(trapDamage);
                string msg = localizedDeathReason.GetLocalizedText(LocalizationManager.CurrentLanguage);
                deathReasonText.text = msg;
                
            }

            if (sState.sState == SlimeState.Dead)
            {
                trapDamage = 0;
            }
        }
    }

    private void CampFireDetected()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, burnedRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                trapDamage += Time.deltaTime * burnedTimer;
            }
        }

        if (Vector3.Distance(transform.position, playerSlime.position) > burnedRange)
        {
            if (trapDamage >= 1)
            {
                trapDamage -= Time.deltaTime * burnedTimer;
            }
        }
    }
    
  /*  void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , burnedRange);
    } */
    
}
