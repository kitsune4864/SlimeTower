
using UnityEngine;
using DG.Tweening;
public class FallingTrigger : MonoBehaviour
{
    public GameObject[] FloorObjects;
    public GameObject playerObject;
    //public CharacterController playerCC;
    private Slime_Movement _slimeMovement;
    public float duration = 1.0f;
    public Transform target;
    public OpeningFloor _openingFloor;
    public void Start()
    {
        //playerCC = playerObject.GetComponent<CharacterController>();
        _slimeMovement = playerObject.GetComponent<Slime_Movement>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _openingFloor.OpenFloorMove();
            MoveToTarget();
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

    private void MoveToTarget()
    {
        Debug.Log("MovieWithBounce()");
        
        Vector3 startPosition = playerObject.transform.position;
        Vector3 targetPosition = target.position;

       
        playerObject.transform.DOMove(target.transform.position, duration)
            .SetEase(Ease.InOutQuad);
    }
}
