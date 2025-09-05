using UnityEngine;

public class Trap_Mango_State : MonoBehaviour
{
    [SerializeField]
    private AudioSource mangoSound;
    
    void Start()
    {
        mangoSound = GetComponent<AudioSource>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MangoGround"))
        {
            mangoSound.Play();
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            Destroy(gameObject);
        }
    }
}
