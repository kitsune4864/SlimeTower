using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum SlimeState
{
    Alive,
    Dead,
}
public class Slime_State : MonoBehaviour
{
    [SerializeField] 
    private float healthPoint = 10;
    
    [SerializeField]
    private float respawnTime;
    
    [SerializeField]
    private Slime_Movement sMovement;
    
    private Rigidbody rb;
    
    private Animator animator;
    
    [SerializeField]
    private Button retryButton;
    
    [SerializeField]
    public SlimeState sState;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        sState = SlimeState.Alive;
    }

    
    void Update()
    {
        SlimeDeath();
    }
    
    public void SlimeDamaged(float damage)
    {
        healthPoint -= damage;
    }
    
    private void SlimeDeath()
    {
        if (healthPoint <= 0)
        {
            sState = SlimeState.Dead;
            sMovement.enabled = false;
            rb.constraints = RigidbodyConstraints.None;
            animator.SetTrigger("IsDeath");
            StartCoroutine(ReloadScene());
        }
    }
    
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(respawnTime);
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            .buildIndex);
    }
}
