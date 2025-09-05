using UnityEngine;

public class Trap_LogAttack : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
   
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
