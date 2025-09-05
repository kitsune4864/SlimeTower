using System;
using UnityEngine;

public class Trap_Squid_Controller : MonoBehaviour
{
    [SerializeField] 
    private float questRange;

    [SerializeField] 
    private Transform playerTransform;
    
    [SerializeField]
    private GameObject squidInkPrefab;

    [SerializeField] 
    private float attackCoolTime;

    [SerializeField] 
    private float attackDelay;

    [SerializeField] 
    private Transform attackTransform;

    [SerializeField] 
    private float throwPower;

    [SerializeField] 
    private bool isCrash;
    
    [SerializeField]
    private AudioSource squidSound;
    
    [SerializeField]
    private AudioClip throwSound;

    private Animator squidAnim;
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        squidAnim = GetComponent<Animator>();
        
        squidSound = GetComponent<AudioSource>();

        attackDelay = 3;
    }

    
    void Update()
    {
        DetectedPlayers();
    }

    private void DetectedPlayers()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, questRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                if (attackDelay >= 0)
                {
                    attackDelay -= Time.deltaTime;
                    squidAnim.SetBool("IsAttack", false);
                }
                
                if (attackDelay <= 0.5f)
                {
                    SquidAttack();
                    squidAnim.SetBool("IsAttack", true);
                }
            }
        }
    }

    private void SquidAttack()
    {
        GameObject newSquidInk = Instantiate(squidInkPrefab, attackTransform.position, Quaternion.identity);
        
        squidSound.clip = throwSound;
        squidSound.Play();
        
        Vector3 targetDir = (playerTransform.position - attackTransform.position).normalized;
        
        Rigidbody rb = newSquidInk.GetComponent<Rigidbody>();
        
        rb.AddForce(targetDir * throwPower, ForceMode.Impulse);
        
        attackDelay += attackCoolTime;
        
    }
    
   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , questRange);
    } */
}
