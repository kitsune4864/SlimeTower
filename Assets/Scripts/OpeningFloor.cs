using UnityEngine;

public class OpeningFloor : MonoBehaviour
{
    public GameObject leftFloor;
    public GameObject rightFloor;

    public void OpenFloor()
    {
        
    }

    public void DeactiveFloor()
    {
        leftFloor.SetActive(false);
        rightFloor.SetActive(false);
    }
}
