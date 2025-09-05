using UnityEngine;
using UnityEngine.AI;

public class Trap_Dog : MonoBehaviour
{
    [SerializeField]
    private float dogSpeed;
    
    [SerializeField]
    private float dogChaseRange;

    [SerializeField]
    private Transform playerSlime;

    [SerializeField]
    private Transform dogOriginPosition;

    [SerializeField]
    private float dogChaseHeight;
    
    [SerializeField]
    private float dogStoppingDistance;

    [SerializeField]
    private bool isDetected;

    [SerializeField]
    private bool isReturning;
    
    [SerializeField]
    private AudioSource dogSoundSource;
    
    [SerializeField]
    private AudioClip dogSound;
    
    
    private bool isSoundPlaying = false;
    
    private Animator dogAnim;
    
    private NavMeshAgent dogAgent;
    void Start()
    {
        dogAnim = GetComponent<Animator>();
        dogAgent = GetComponent<NavMeshAgent>();
        
        dogAgent.speed = dogSpeed;
        playerSlime = GameObject.FindGameObjectWithTag("Player").transform;
        
        dogOriginPosition = GameObject.FindGameObjectWithTag("DogOriginTransform").transform;
        
        dogSoundSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        DogChase();
        PlayerSlimeDetected();
        ReturnCheck();
        DogSoundsPlayer();
    }

    private void DogChase()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, dogChaseRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                if (isDetected)
                {
                    dogAgent.SetDestination(playerSlime.position);
                    
                    dogAgent.stoppingDistance = dogStoppingDistance;
                    
                    dogAnim.SetBool("IsRunning", true);
                    
                    Debug.Log("추적 시작");
                }
                
                else
                {

                    dogAgent.isStopped = true;
                    
                    dogAgent.SetDestination(dogOriginPosition.position);
                    
                    dogAgent.isStopped = false;
                    
                    dogAnim.SetBool("IsRunning", false);
                    
                    dogAnim.SetBool("IsWalking", true);
                    
                    isReturning = true;
                    
                    
                } 
            }
        }
    }

    private void ReturnCheck()
    {
        if (isReturning)
        {
            if (!dogAgent.pathPending && dogAgent.remainingDistance <= dogStoppingDistance)
            {
                if (!dogAgent.hasPath || dogAgent.velocity.sqrMagnitude == 0f)
                {
                    dogAnim.SetBool("IsWalking", false);
                    isReturning = false;
                    
                }
            } 
        }
    }

    private void PlayerSlimeDetected()
    {
        if (Vector3.Distance(transform.position, playerSlime.position) < dogChaseRange)
        {
            isDetected = true;
        }
        else
        {
            isDetected = false;
        }
        
    }

    private void DogSoundsPlayer()
    {
        if (isDetected)
        {
            if (!isSoundPlaying)
            {
                dogSoundSource.clip = dogSound;
                dogSoundSource.Play();
                isSoundPlaying = true;
            }
           
        }
        else
        {
            if (dogSoundSource.isPlaying)
            {
                dogSoundSource.Stop();
            }
            isSoundPlaying = false;
           
        }
    }
    
    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , dogChaseRange);
    } */
}
