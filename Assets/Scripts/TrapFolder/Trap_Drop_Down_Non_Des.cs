using UnityEngine;

public class Trap_Drop_Down_Non_Des : MonoBehaviour
{
    private Rigidbody dDRb;

    [SerializeField] 
    private AudioSource dropDownSound;
    
    void Start()
    {
        dDRb = GetComponent<Rigidbody>();
        dropDownSound = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dDRb.useGravity = true;
            dDRb.isKinematic = false;
           BoxCollider bc = GetComponent<BoxCollider>();
           bc.isTrigger = true;
           if (bc == null)
           {
               return;
           }

           if (dropDownSound != null)
           {
               dropDownSound.Play();
           }
        }
    }
}

