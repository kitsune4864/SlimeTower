using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collections_SO", menuName = "Scriptable Objects/Collections_SO", order = 2)]
public class Collections_SO : ScriptableObject
{
    [Serializable]
    public class CollectionItemData
    {
        public int collectionIndex;
        public string collectionName;   
        public GameObject collectionPrefab;
    }

    public List<CollectionItemData> CollectionItems;



}
