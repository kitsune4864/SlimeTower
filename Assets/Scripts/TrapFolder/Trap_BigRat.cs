using UnityEngine;
using UnityEngine.AI;

public class Trap_BigRat : MonoBehaviour
{
    [SerializeField]
    private float ratSpeed;
    
    [SerializeField]
    private float ratChaseRange;
    
    [SerializeField]
    private float ratChaseDistance;

    [SerializeField] 
    private Transform playerSlime;
    
    [SerializeField] 
    private float ratStoppingDistance;
    
    [SerializeField]
    private bool isDetected;
    
    [SerializeField]
    private AudioSource ratSound;

    [SerializeField] 
    private AudioClip ratHowlSound;

    private Animator ratAnim;
    
    private NavMeshAgent ratAgent;
    void Start()
    {
        ratAnim = GetComponent<Animator>();
        ratAgent = GetComponent<NavMeshAgent>();
        
        ratAgent.speed = ratSpeed;
        
        playerSlime = GameObject.FindGameObjectWithTag("Player").transform;
        
        ratSound = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        RatChase();
        PlayerSlimeDetected();
    }

    private void RatChase()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position + Vector3.down * 6f + Vector3.left * 2f, ratChaseRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                
                if (isDetected)
                {
                    ratAgent.SetDestination(playerSlime.position);

                    ratAgent.stoppingDistance = ratStoppingDistance;

                    ratAnim.SetBool("IsRunning", true);

                    
                    if(Vector3.Distance(transform.position, playerSlime.position) < 2)
                    {
                        ratAgent.isStopped = true;
                        ratAnim.SetBool("IsRunning", false);
                        ratAnim.SetTrigger("IsAttack");
                    }
                }
            }
        }
    }

    private void PlayerSlimeDetected()
    {
        if (Vector3.Distance(transform.position, playerSlime.position) < ratChaseDistance)
        {
            isDetected = true;
        }
        else
        {
            isDetected = false;
        }
    }
    
  /*  void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 6f + Vector3.left * 2f, ratChaseRange);
    } */

    public void DestroyRat()
    {
        Destroy(gameObject);
    }
}
