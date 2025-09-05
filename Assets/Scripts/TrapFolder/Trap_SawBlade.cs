using System;
using System.Collections;
using UnityEngine;

public class Trap_SawBlade : MonoBehaviour
{
    private enum SawBladeState
    {
        LookBack,
        Rotate,
        Shot,
        
    }
    private Vector3 firstPosition;
    
    [SerializeField]
    private Transform secondPosition;

    [SerializeField]
    private float moveDuration;
    
    [SerializeField]
    private float rotationSpeed;
    
    [SerializeField]
    private float shotSpeed;
    
    [SerializeField]
    private SawBladeState state;
    
    void Start()
    {
        firstPosition = transform.position;
        if (state == SawBladeState.LookBack)
        {
            StartCoroutine(SawBladeMovement());
            StartCoroutine(SawBladeRotation());
        }

        if (state == SawBladeState.Rotate)
        {
            StartCoroutine(SawBladeRotation());
        }

        if (state == SawBladeState.Shot)
        {
            StartCoroutine(SawBladeRotation());
            SawBladeShot();
        }
        
    }
    

    private IEnumerator SawBladeMovement()
    {
        {
            while (true)
            {
                float movedTime = 0f;
                while (movedTime < moveDuration)
                {
                    transform.position = Vector3.Lerp(firstPosition, secondPosition.position,
                        movedTime / moveDuration);
                    movedTime += Time.deltaTime;
                    yield return null;
                }

                movedTime = 0f;
                while (movedTime < moveDuration)
                {
                    transform.position = Vector3.Lerp(secondPosition.position, firstPosition,
                        movedTime / moveDuration);
                    movedTime += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }

    private IEnumerator SawBladeRotation()
    {
        while (true)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void SawBladeShot()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back * shotSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (state == SawBladeState.Shot)
        {
            if (other.gameObject.CompareTag("Destroyer"))
            {
                Destroy(gameObject);
            }
        }
    }
}
