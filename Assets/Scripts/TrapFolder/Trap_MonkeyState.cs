using UnityEngine;

public class Trap_MonkeyState : MonoBehaviour
{
    [SerializeField]
    private float detectedRange;

    [SerializeField]
    private Trap_Fruits_Maker tFM;
    
    [SerializeField]
    private float throwCooldown;

    [SerializeField]
    private float throwDelay;
    
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource monkeySound;
    
    [SerializeField]
    private AudioClip throwSound;
    
    [SerializeField]
    private AudioClip howlSound;

    [SerializeField] 
    private bool isSoundPlaying;
    
    [SerializeField]
    private bool isDetected;
    
    [SerializeField]
    private bool isThrowing;
    
    [SerializeField]
    private Transform playerTransform;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        monkeySound = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        MonkeySoundPlayer();
        
        DetectedPlayer();
        
        if (throwCooldown > 0f)
        {
            throwCooldown -= Time.deltaTime;
        }
    }

    private void DetectedPlayer()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectedRange);
        foreach (var hit in hits)
        {
            if (hit.gameObject.CompareTag("Player"))
            {
                isDetected = true;
                
                if (throwCooldown <= 0f)
                {
                    isDetected = false;
                    tFM.ThrowFruits();
                    throwCooldown = throwDelay;
                    animator.SetTrigger("IsThrowing");
                    
                    isThrowing = true;
                }
                else
                {
                    isThrowing = false;
                }
            }
        }
    }

    private void MonkeySoundPlayer()
    {
        if (isDetected)
        {
            if (!isSoundPlaying)
            {
                monkeySound.clip = howlSound;
                monkeySound.Play();
                monkeySound.loop = true;
                isSoundPlaying = true;
            }
        }
        else if(isThrowing)
        {
            monkeySound.loop = false;
            monkeySound.PlayOneShot(throwSound);
        }
        else
        {
            if (monkeySound.isPlaying)
            {
                monkeySound.Stop();
                isSoundPlaying = false;
            }
        }

        if (Vector3.Distance(transform.position, playerTransform.position) > detectedRange)
        {
            monkeySound.Stop();
        }
        
    }
  /*  void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position , detectedRange);
    } */
    
}
