using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Slime_State : MonoBehaviour
{
    [SerializeField] 
    private int healthPoint = 10;
    [SerializeField]
    private Slime_Movement sMovement;
    private Rigidbody rb;
    private Animator animator;
    [SerializeField]
    private Button retryButton;
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
            //retryButton.gameObject.SetActive(true);
            StartCoroutine(ReloadScene());
        }

        

    }
    
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(7f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene()
            .buildIndex);
    }
}
