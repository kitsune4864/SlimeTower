using TMPro;
using UnityEngine;

public class Trap_Chess_Attack : MonoBehaviour
{
    private enum ChessType
    {
        King,
        Queen,
    }
    
    [SerializeField]
    private ChessType chessType;
    
    [SerializeField] 
    private float chessSpeed;
    
    [SerializeField]
    private bool isAttacking;
    
    [SerializeField]
    private AudioSource chessSound;
    
    [SerializeField]
    private AudioClip chessMoveSound;

    [SerializeField]
    private float trapDamage;
    
    [SerializeField]
    private LocalizedLanguageSO localizedDeathReason;
    
    [SerializeField]
    private TMP_Text deathReasonText;

    private Rigidbody rb;
    
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();
        chessSound = gameObject.GetComponent<AudioSource>();
        trapDamage = 0;
    }

    
    void Update()
    {
        if (isAttacking)
        {
            trapDamage = 10;
        }
    }

    public void ChessAttack()
    {
        if (chessType == ChessType.King)
        {
            rb.AddForce(Vector3.left * chessSpeed, ForceMode.Impulse);
            isAttacking = true;
            
        }

        if (chessType == ChessType.Queen)
        {
            rb.AddForce(Vector3.right * chessSpeed, ForceMode.Impulse);
            isAttacking = true;
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isAttacking)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                chessSound.clip = chessMoveSound;
                chessSound.Play();
                
                Slime_State sState = other.gameObject.GetComponent<Slime_State>();
                if (sState != null)
                {
                    sState.SlimeDamaged(trapDamage);
                }
            
            
                if (trapDamage >= 10 && sState.sState == SlimeState.Alive)
                {
                    string msg = localizedDeathReason.GetLocalizedText(LocalizationManager.CurrentLanguage);
                    deathReasonText.text = msg;
                }
            }
        }
    }
}
