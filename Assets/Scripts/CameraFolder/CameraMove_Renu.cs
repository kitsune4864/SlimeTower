using UnityEngine;
using Unity.Cinemachine;

public class FreeLookCollisionZoom : MonoBehaviour
{
    public LayerMask collisionLayers;
    public float minDistance = 1.5f;
    public float defaultDistance = 4f;
    public float smoothing = 5f;
    public Transform playerTransform;
    public float checkRadius = 0.2f;

    [SerializeField]
    private CinemachineCamera freeLookCam;
    private Vector3 desiredCameraPos;
    private float currentDistance;

    void Start()
    {
        
        currentDistance = defaultDistance;
    }

    void LateUpdate()
    {
        Vector3 playerPos = playerTransform.position;
        Vector3 camDir = (freeLookCam.transform.position - playerPos).normalized;

        bool isBlocked = Physics.SphereCast(
            playerPos,
            checkRadius,
            camDir,
            out RaycastHit hit,
            defaultDistance,
            collisionLayers,
            QueryTriggerInteraction.Ignore
        );

        float targetDistance = isBlocked ? Mathf.Clamp(hit.distance, minDistance, defaultDistance) : defaultDistance;
        currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * smoothing);

        Vector3 targetPos = playerPos + camDir * currentDistance;
        freeLookCam.transform.position = targetPos;
        freeLookCam.transform.LookAt(playerPos);
    }
}