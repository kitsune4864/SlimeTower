using UnityEngine;

public class Trap_Bomb : MonoBehaviour
{
    [SerializeField]
    private AudioSource explodeSound;
    
    [SerializeField]
    private GameObject explodeParticles;
    
    [SerializeField]
    private bool isSpawned = false;
    void Start()
    {
        explodeSound = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!isSpawned)
            {
                BombExplosion();
                isSpawned = true;
            }
            
            
        }
    }

    private void BombExplosion()
    {
        
        explodeSound.Play();
        Instantiate(explodeParticles, transform.position, Quaternion.identity);
    }
    
}
