using UnityEngine;

enum State
{
    Idle,
    Chase,
    Attack,
}
public class Skr_State : MonoBehaviour
{
    private State state;
    private Animator animator;
    private Transform playerSlime;
    private CharacterController cc;
    [SerializeField]
    private int skr_MoveSpeed;
    [SerializeField]
    private int skr_Damage;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        playerSlime = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
        state = State.Idle;
    }

    void Update()
    {
        //transform.LookAt(playerSlime);
    }
    
    void FixedUpdate()
    {
        ChaseToSlime();
        AttackToSlime();
    }

    private void ChaseToSlime()
    {
        if (Vector3.Distance(transform.position, playerSlime.transform.position) < 30f)
        {
            state = State.Chase;
            if (state == State.Chase)
            {
                animator.SetBool("IsChase", true);
                Vector3 moveDir = (playerSlime.position - transform.position).normalized;
                cc.Move(moveDir * skr_MoveSpeed * Time.deltaTime);
                
            }
            else
            {
                animator.SetBool("IsChase", false);
            }
        } 
    }

    private void AttackToSlime()
    {
        if (Vector3.Distance(transform.position, playerSlime.transform.position) < 2f)
        {
            state = State.Attack;
            if (state == State.Attack)
            {
                animator.SetTrigger("IsAttack");
                playerSlime.GetComponent<Slime_State>().SlimeDamaged(skr_Damage);
            }
        }
        else
        {
            state = State.Chase;
        }
    }
}
