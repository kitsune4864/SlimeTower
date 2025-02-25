using UnityEngine;

public class Slime_State : MonoBehaviour
{
    [SerializeField] 
    private int healthPoint = 10;
    [SerializeField]
    private Slime_Movement sMovement;
    private Rigidbody rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        SlimeDeath();
    }

    private void SlimeSpawn()
    {
        //추후 스폰 기능을 넣을 부분
    }

    public void SlimeDamaged(int damage)
    {
        healthPoint -= damage;
    }
    
    private void SlimeDeath()
    {
        if (healthPoint <= 0)
        {
            sMovement.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            animator.SetTrigger("IsDeath");
        }
    }
}
