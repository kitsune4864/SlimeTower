using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    [SerializeField]
    private Collections_SO collectionsSO;
    
    void Start()
    {
        SpawnPoint[] spawnPoints = FindObjectsOfType<SpawnPoint>();

        foreach (var point in spawnPoints)
        {
            string key = $"Collected_{point.spawnPointIndex}";
            if (PlayerPrefs.HasKey(key) && PlayerPrefs.GetInt(key) == 1)
            {
                Debug.Log($"{point.spawnPointIndex} is already collected");
                continue;
            }
            
            var collectionData = collectionsSO.CollectionItems.Find(x => x.collectionIndex == point.spawnPointIndex);
            if (collectionData != null)
            {
               GameObject item =  Instantiate(collectionData.collectionPrefab, point.transform.position, Quaternion.identity);

               if (item.TryGetComponent<CollectableItem>(out var collectable))
               {
                   collectable.spawnIndex = point.spawnPointIndex;
               }
            }
        }
    }

    
    void Update()
    {
        
    }
}
