using System.Collections;
using UnityEngine;

public class Trap_Fruits_Maker : MonoBehaviour
{
    [SerializeField]
    private GameObject fruitPrefab;
    
    [SerializeField]
    private Transform player;
    
    [SerializeField]
    private GameObject newFruitPrefabs;

    [SerializeField]
    private float throwForce;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (newFruitPrefabs == null)
        {
            return;
        }
        
    }

    public void ThrowFruits()
    {
        newFruitPrefabs = Instantiate(fruitPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = newFruitPrefabs.GetComponent<Rigidbody>();
        Vector3 direction = (player.position - transform.position).normalized;
        rb.AddForce(direction * throwForce, ForceMode.Impulse);
        
    }
    
}
