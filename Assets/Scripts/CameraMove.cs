using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        /*transform.position = Vector3.Lerp(transform.position, CamTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, CamTarget.rotation, rLerp);
        */
    }
}
