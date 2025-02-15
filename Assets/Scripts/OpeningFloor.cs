using UnityEngine;
using DG.Tweening;

public class OpeningFloor : MonoBehaviour
{
    public GameObject leftFloor;
    public GameObject rightFloor;

    public Vector3 targetRotationL; // 목표 회전각
    public Vector3 targetRotationR;
    public Vector3 moveOffset;
    public float duration = 2f; // 회전 시간
    
  

    public void Start()
    {
        targetRotationL = new Vector3(0, 0, -180);
        targetRotationR = new Vector3(0, 0, 180);
        moveOffset = new Vector3(6f, 0f, 0f);
        
    }

    public void OpenFloorMove()
    {
        leftFloor.transform.DOBlendableMoveBy(moveOffset*(-1f), duration)
            .SetEase(Ease.InOutQuad);
        rightFloor.transform.DOBlendableMoveBy(moveOffset, duration)
            .SetEase(Ease.InOutQuad);
    }
    public void OpenFloorRotation()
    {

        leftFloor.transform.DORotate(targetRotationL, duration, RotateMode.FastBeyond360)
                .SetEase(Ease.InOutQuad); // 부드러운 Ease 적용
        rightFloor.transform.DORotate(targetRotationR, duration, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutQuad);
    }

    public void DeactiveFloor()
    {
        leftFloor.SetActive(false);
        rightFloor.SetActive(false);
    }
}
