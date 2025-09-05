using System.Collections;
using UnityEngine;

public class Trap_Drop_Down_CountDown : MonoBehaviour
{
    private Rigidbody dDRb;
    [SerializeField]
    private float countDown;
    void Start()
    {
        dDRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DropCountDown());
        }
    }

    private IEnumerator DropCountDown()
    {
        yield return new WaitForSeconds(countDown);
        dDRb.isKinematic = false;
        dDRb.useGravity = true;
        
    }
}
