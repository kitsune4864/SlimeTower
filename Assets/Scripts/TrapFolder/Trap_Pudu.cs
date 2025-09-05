using UnityEngine;
using UnityEngine.AI;

public class Trap_Pudu : MonoBehaviour
{
    private Animator puduAnim;
    private NavMeshAgent puduAgent;
    [SerializeField]
    private float moveSpeed;
    
    [SerializeField] 
    private Transform playerSlime;
    
    [SerializeField]
    private float chaseRange;

    [SerializeField] 
    private bool isChasing;
    
    private bool isSoundPlaying = false;
    
    [SerializeField]
    private AudioSource chaseSound;
    
    
    void Start()
    {
        puduAnim = GetComponentInChildren<Animator>();
        puduAgent = GetComponent<NavMeshAgent>();
        puduAgent.speed = moveSpeed;
        playerSlime = GameObject.FindGameObjectWithTag("Player").transform;
        puduAnim.SetBool("IsSpinning", true);
        chaseSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        PuduChase();
        PuduSoundPlayer();
    }
    
    private void PuduChase()
    {
        //RaycastHit hit;
        Collider[] hits = Physics.OverlapSphere(transform.position, chaseRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();
                if (rb.linearVelocity.magnitude > 2f)
                {
                    puduAgent.SetDestination(playerSlime.position);
                    puduAnim.SetBool("IsWalking", true);
                    isChasing = true;
                }
                else
                {
                    puduAgent.ResetPath();
                    puduAnim.SetBool("IsWalking", false);
                    isChasing = false;
                }
                
            }
        }
    }

    private void PuduSoundPlayer()
    {
        if (isChasing)
        {
            if (!isSoundPlaying)
            {
                chaseSound.Play();
                isSoundPlaying = true;
            }
        }
        else
        {
            if (chaseSound.isPlaying)
            {
                chaseSound.Stop();
            }
            isSoundPlaying = false;
        }

        if (Vector3.Distance(transform.position, playerSlime.position) > chaseRange)
        {
            chaseSound.Stop();
        }
    }
    
  /*  void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , chaseRange);
    } */
}
