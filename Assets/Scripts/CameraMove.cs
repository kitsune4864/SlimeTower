using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform CamTarget;
    public float pLerp = 0.02f;
    public float rLerp = 0.01f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CamTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, CamTarget.rotation, rLerp);
    }
}
