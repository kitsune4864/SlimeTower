using UnityEngine;
using DG.Tweening;

public class Collection_Rotate_Dotween : MonoBehaviour
{
   
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 4f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    
    void Update()
    {
        
    }
}
