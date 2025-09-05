using TMPro;
using UnityEngine;

public class Trap_Damaged_isTrigger : MonoBehaviour
{
    [SerializeField] 
    private float trapDamage;
    
    [SerializeField]
    private LocalizedLanguageSO localizedDeathReason;
    
    [SerializeField]
    private TMP_Text deathReasonText;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (deathReasonText == null)
        {
            deathReasonText = GameObject.FindGameObjectWithTag("DamageText").GetComponent<TMP_Text>();
        }
    }

    private void OnTriggerEnter(Collider other)
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
    }
}
