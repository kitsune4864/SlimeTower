using UnityEngine;

public class TPSCameraPureOrbit_Unity6 : MonoBehaviour
{
    public Transform playerTransform;
    public float orbitDistance = 4f;
    public Vector2 yClamp = new Vector2(-80f, 80f);
    
    [SerializeField]
    private float mouseSensitivity = 100f;

    [Header("Collision Settings")]
    public LayerMask collisionLayers;
    public float minDistance = 1.5f;
    public float smoothing = 5f;
    public float checkRadius = 0.3f;

    private float xRot;
    private float yRot = 20f;
    private float currentDistance;

    private bool isCursorLocked = true;

    void Start()
    {
        
        SetCursorLock(true);
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 100f);
        
        currentDistance = orbitDistance;
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
       
    }

    void LateUpdate()
    {
        xRot += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yRot -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, yClamp.x, yClamp.y);

        Quaternion rotation = Quaternion.Euler(yRot, xRot, 0);

        // 충돌 처리
        Vector3 desiredCameraPos = playerTransform.position + rotation * new Vector3(0, 0, -orbitDistance);
        Vector3 dirToCamera = desiredCameraPos - playerTransform.position;

        if (Physics.SphereCast(playerTransform.position, checkRadius, dirToCamera.normalized, out RaycastHit hit, orbitDistance, collisionLayers))
        {
            float targetDist = Mathf.Clamp(hit.distance, minDistance, orbitDistance);
            currentDistance = Mathf.Lerp(currentDistance, targetDist, Time.deltaTime * smoothing);
        }
        else
        {
            currentDistance = Mathf.Lerp(currentDistance, orbitDistance, Time.deltaTime * smoothing);
        }

        Vector3 finalPos = playerTransform.position + rotation * new Vector3(0, 0, -currentDistance);
        transform.position = finalPos;
        transform.LookAt(playerTransform.position);
    }

    public void MouseSensitivityController(float userSensitivity)
    {
        mouseSensitivity = userSensitivity;
    }

    public void SetCursorLock(bool value)
    {
        isCursorLocked = value;
        Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !value;
    }
}
