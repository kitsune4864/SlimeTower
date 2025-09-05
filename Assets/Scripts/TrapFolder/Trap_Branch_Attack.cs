using System.Collections;
using TMPro;
using UnityEngine;

public class Trap_Branch_Attack : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed;
    [SerializeField] 
    private int trapDamage;

    [SerializeField]
    private string deathReason;
    
    [SerializeField]
    private TMP_Text deathReasonText;

    [SerializeField] 
    private AudioSource tree_Attack_Sound;
    void Start()
    {
        tree_Attack_Sound = GetComponent<AudioSource>();
    }
    
    public void BranchAttack()
    {
        float rotationZ = transform.eulerAngles.z;
        float newRotationZ = Mathf.LerpAngle(rotationZ, 80f, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, newRotationZ);
        trapDamage = 10;
        tree_Attack_Sound.Play();
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Slime_State sState = other.gameObject.GetComponent<Slime_State>();
            sState.SlimeDamaged(trapDamage);
            if (trapDamage > 0)
            {
                deathReasonText.gameObject.SetActive(true);
                deathReasonText.text = deathReason;
            }
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(TrapDamagedCancler());
        }
    }
    

    IEnumerator TrapDamagedCancler()
    {
        yield return new WaitForSeconds(1.5f);
        deathReasonText.gameObject.SetActive(false);
        trapDamage = 0;
        
    }
}
