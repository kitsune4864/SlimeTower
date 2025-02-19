using UnityEngine;

[CreateAssetMenu(fileName = "RoundData", menuName = "Game/Round Data")]
public class RoundData : ScriptableObject
{
    public int roundIndex = 0;
    public Vector3 spawnPoint;
    public Vector3 spawnRotation;
    public GameObject obstaclePrefab;
}