using UnityEngine;
using DG.Tweening;

public class Trap_Coin : MonoBehaviour
{
    private enum CoinType
    {
        Front,
        Back,
    }
    [SerializeField]
    private GameObject coinPrefab;
    
    [SerializeField] 
    private bool isTurning;
    
    [SerializeField]
    private CoinType coinType;
    
    [SerializeField]
    private int coinNumber;

    [SerializeField] 
    private GameObject entranceDoor;

    [SerializeField] 
    private GameObject nextDoor;

    [SerializeField] 
    private GameObject shotGunPrefab;

    [SerializeField] 
    private Transform shotGunDestination;

    [SerializeField] 
    private GameObject shotGunBullet;

    [SerializeField] 
    private Transform bulletTransform;

    [SerializeField] 
    private GameObject anotherCoin;

    [SerializeField] 
    private AudioSource coinSystemSound;

    [SerializeField] 
    private AudioClip coinSound;
    
    [SerializeField]
    private AudioClip doorSound;
    
    [SerializeField]
    private AudioClip shotgunSound;
    
    void Start()
    {
        coinSystemSound = GetComponent<AudioSource>();
        
        if (coinType == CoinType.Front)
        {
            coinNumber = 1;
        }

        if (coinType == CoinType.Back)
        {
            coinNumber = 2;
        }
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isTurning)
            {
                isTurning = true;
            }
            
            if (isTurning)
            {
                CoinToss();
                coinSystemSound.clip = coinSound;
                coinSystemSound.Play();
                
                Destroy(anotherCoin.gameObject);
                
                BoxCollider bc = GetComponent<BoxCollider>();
                bc.enabled = false;
            }

            entranceDoor.transform.DORotate(new Vector3(0, 0, 0), 1f);

        }
    }

    private void CoinToss()
    {
        Sequence sequence = DOTween.Sequence();
        
        int coinDestiny =  Random.Range(1, 3);
        Debug.Log(coinDestiny);

        if (coinDestiny == 2)
        {
            Debug.Log(coinDestiny);
            sequence.Append(coinPrefab.transform.DOJump(
                endValue: coinPrefab.transform.position + new Vector3(0, 0, 0),
                jumpPower: 3f,
                numJumps: 1,
                duration: 1.5f));
            sequence.Join(coinPrefab.transform.DORotate(new Vector3(1620, 0, 0), 
                1.5f, RotateMode.FastBeyond360));
            sequence.Append(coinPrefab.transform.DOMove(new Vector3(coinPrefab.transform.position.x, 
                coinPrefab.transform.position.y 
                + 3f, coinPrefab.transform.position.z), 1.5f));
            sequence.Append(coinPrefab.transform.DORotate(new Vector3(90f, 0, 0), 
                1.5f).SetRelative(true));
            
        }
        else
        {
            sequence.Append(coinPrefab.transform.DOJump(
                endValue: coinPrefab.transform.position + new Vector3(0, 0, 0),
                jumpPower: 3f,
                numJumps: 1,
                duration: 1.5f));
            Debug.Log(coinDestiny);
            sequence.Join(coinPrefab.transform.DORotate(new Vector3(1440, 0, 0), 1.5f, RotateMode.FastBeyond360));
            sequence.Append(coinPrefab.transform.DOMove(new Vector3(coinPrefab.transform.position.x, coinPrefab.transform.position.y + 3f, coinPrefab.transform.position.z), 1.5f));
            sequence.Append(coinPrefab.transform.DORotate(new Vector3(-90f, 0, 0), 1.5f).SetRelative(true));
        }
        
        sequence.OnComplete(() =>
        {
            
            if (coinNumber == coinDestiny)
            {
                DoorOpening();
            }
            else
            {
                ShotGun();
            }
        }); 
        
    }

    private void ShotGun()
    {
       
        Sequence shotSequence = DOTween.Sequence();
        shotSequence.Append(shotGunPrefab.transform.DOMove(shotGunDestination.position, 1.5f));
        
        shotSequence.Append(shotGunPrefab.transform.DORotate(new Vector3(-23, 180, 0), 0.2f));
        
        shotSequence.AppendCallback(() =>
        {
            Instantiate(shotGunBullet, bulletTransform.position, Quaternion.identity);
            
            coinSystemSound.clip = shotgunSound;
            coinSystemSound.Play();
        });
        
    }

    private void DoorOpening()
    {
        
        nextDoor.transform.DORotate(new Vector3(0, -130f, 0), 1.5f);
        
        coinSystemSound.clip = doorSound;
        coinSystemSound.Play();
    }
}
