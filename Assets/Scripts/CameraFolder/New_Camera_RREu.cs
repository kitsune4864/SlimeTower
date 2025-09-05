using System;
using UnityEngine;

using Unity.Cinemachine;

public class FreeLookCameraManualOrbit_Unity6 : MonoBehaviour
{
    public Transform playerTransform;
    public Transform targetTransform;
    public float distance = 4f;
    public float xSpeed = 150f;
    public float ySpeed = 100f;
    public Vector2 yClamp = new Vector2(-80f, 80f);

    private float xRot;
    private float yRot = 20f;
    
   [SerializeField]
   private CinemachineCamera xCam;

    private void Start()
    {
        if (targetTransform == null)
        {

            GameObject pivotObj = new GameObject("CameraPivot");
            targetTransform = pivotObj.transform;
            targetTransform.position = playerTransform.position;

        }
        
        xCam.Follow = targetTransform;
        xCam.LookAt = targetTransform;

    }

    void LateUpdate()
    {
        xRot += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        yRot -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, yClamp.x, yClamp.y);

        Quaternion rotation = Quaternion.Euler(yRot, xRot, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -distance);

        targetTransform.position = playerTransform.position + offset;
        targetTransform.LookAt(playerTransform.position);
    }
}
