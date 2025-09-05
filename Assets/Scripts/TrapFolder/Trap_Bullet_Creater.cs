using System.Collections;
using UnityEngine;

public class Trap_Bullet_Creater : MonoBehaviour
{
    private enum BulletType
    {
        Bullet,
        SawBlade,
        
    }
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float countDown;
    
    [SerializeField]
    private float timeBetweenShots;
    
    [SerializeField]
    private BulletType bulletType;
    
    [SerializeField]
    private AudioSource bulletSound;
    
    [SerializeField]
    private AudioClip bulletSoundClip;
    
    [SerializeField]
    private AudioClip sawBladeSoundClip;
    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
        
        countDown = 0;
        if (bulletType == BulletType.Bullet)
        {
            
        }
        
    }

    
    void Update()
    {
        countDown += Time.deltaTime;
    }

    public IEnumerator BulletShot()
    {
        while (true)
        {
            
            if (countDown < timeBetweenShots)
            {
                yield return null;
                continue;
            }
            
            if (countDown >= timeBetweenShots)
            {
                Quaternion rotation = Quaternion.Euler(-90f, 0, 0);
                Instantiate(bullet, transform.position, rotation);
                bulletSound.clip = bulletSoundClip;
                bulletSound.Play();
                countDown = 0;
                yield return null;
            }
        }
    }
    
    public void SawBladeShot()
    {
        if (bulletType == BulletType.SawBlade)
        {
            Quaternion rotation = Quaternion.Euler(0, 90, 0);
            Instantiate(bullet, transform.position, rotation);
            bulletSound.clip = sawBladeSoundClip;
            bulletSound.Play();
        }
    }
}
