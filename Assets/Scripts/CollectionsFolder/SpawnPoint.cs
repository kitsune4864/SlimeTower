using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int spawnPointIndex;
    public Color gizmoColor = Color.cyan;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, 0.3f);

        // 인덱스 숫자 표시
#if UNITY_EDITOR
        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.Label(transform.position + Vector3.up * 0.5f, $"Index: {spawnPointIndex}");
#endif
    }
}
