using UnityEngine;

public class CastVisualizer : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float castDistance = 0.5f;
    public float capsuleRadius = 0.2f;
    public float capsuleHeightOffset = 0.2f;
    public LayerMask layerMask;

    private void OnDrawGizmos()
    {
        Vector3 point1 = transform.position;
        Vector3 point2 = transform.position - Vector3.up * capsuleHeightOffset;

        // 시작 캡슐
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(point1, capsuleRadius);
        Gizmos.DrawWireSphere(point2, capsuleRadius);
        Gizmos.DrawLine(point1 + Vector3.forward * capsuleRadius, point2 + Vector3.forward * capsuleRadius);
        Gizmos.DrawLine(point1 - Vector3.forward * capsuleRadius, point2 - Vector3.forward * capsuleRadius);
        Gizmos.DrawLine(point1 + Vector3.right * capsuleRadius, point2 + Vector3.right * capsuleRadius);
        Gizmos.DrawLine(point1 - Vector3.right * capsuleRadius, point2 - Vector3.right * capsuleRadius);

        // 캡슐캐스트 경로
        Vector3 castDir = direction.normalized;
        Vector3 point1End = point1 + castDir * castDistance;
        Vector3 point2End = point2 + castDir * castDistance;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(point1End, capsuleRadius);
        Gizmos.DrawWireSphere(point2End, capsuleRadius);
        Gizmos.DrawLine(point1End + Vector3.forward * capsuleRadius, point2End + Vector3.forward * capsuleRadius);
        Gizmos.DrawLine(point1End - Vector3.forward * capsuleRadius, point2End - Vector3.forward * capsuleRadius);
        Gizmos.DrawLine(point1End + Vector3.right * capsuleRadius, point2End + Vector3.right * capsuleRadius);
        Gizmos.DrawLine(point1End - Vector3.right * capsuleRadius, point2End - Vector3.right * capsuleRadius);

        // 연결 라인
        Gizmos.DrawLine(point1, point1End);
        Gizmos.DrawLine(point2, point2End);
    }

    private void Update()
    {
        Vector3 point1 = transform.position;
        Vector3 point2 = transform.position - Vector3.up * capsuleHeightOffset;
        RaycastHit hit;

        bool isCollidingFront = Physics.CapsuleCast(point1, point2, capsuleRadius, direction.normalized, out hit, castDistance, layerMask, QueryTriggerInteraction.Ignore);

        if (isCollidingFront)
        {
            Debug.Log("CapsuleCast 충돌: " + hit.collider.name);
        }
    }
}

