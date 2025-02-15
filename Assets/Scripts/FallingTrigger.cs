
using UnityEngine;
using DG.Tweening;
public class FallingTrigger : MonoBehaviour
{
    public GameObject[] FloorObjects;
    public GameObject playerObject;
    public CharacterController playerCC;
    public float bounceDuration = 1.0f;
    public Transform target;

    public void Start()
    {
        playerCC = playerObject.GetComponent<CharacterController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DeactivateFloorOjbects();
            MoveWithBounce();
        }
        

    }


    private void DeactivateFloorOjbects()
    {
        foreach (GameObject obj in FloorObjects)
        {
            obj.SetActive(false);
        }
    }

    private void OpenFloors()
    {
        foreach (GameObject obj in FloorObjects)
        {
            obj.SetActive(false);
        }
    }

    private void MoveWithBounce()
    {
        Debug.Log("MovieWithBounce()");
        
        Vector3 startPosition = playerObject.transform.position;
        Vector3 targetPosition = target.position;

        /*
        playerObject.transform.DOKill();
        playerObject.transform.DOMove(target.position, bounceDuration)
            .SetEase(Ease.OutBounce); // 바운스 효과 적용
            */
        DOTween.To(() => startPosition, x =>
        {
            Vector3 move = x - playerObject.transform.position;
            playerCC.Move(move); // CharacterController로 이동 적용
        }, targetPosition, bounceDuration).SetEase(Ease.OutQuad);
    }
}
