using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Trap_Fruits_State : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Destroyer());
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            rb.useGravity = true;
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
    }
}
