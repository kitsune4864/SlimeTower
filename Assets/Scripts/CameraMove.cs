using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineOrbitalFollow cineOrbitFollow; 
    public Transform player; 
    [SerializeField]
    private float minLookY = -0.2f; // 아래쪽에서 위를 보는 최소 값 
    [SerializeField]
    private float maxLookY = 0.8f; // 위쪽에서 자연스러운 값
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        if (cineOrbitFollow == null || player == null) return;

        // 카메라의 높이를 기준으로 Look Orbit Y 값을 자동 조정
        float camHeight = cineOrbitFollow.FollowTarget.position.y;
        float playerHeight = player.position.y;

        // 높이에 따른 Look Orbit Y 값 자동 조절 (보간)
        float heightRatio = Mathf.InverseLerp(playerHeight - 1f, playerHeight + 3f, camHeight);
        float targetLookY = Mathf.Lerp(minLookY, maxLookY, heightRatio);

        // Cinemachine의 Look Orbit Y 값 업데이트
        cineOrbitFollow.TargetOffset.y = targetLookY;
    }
}
