using System;
using System.Collections.Generic;
using UnityEngine;

namespace aldetkov.Components.SpriteCollection
{
    public class SpriteCollectionList : MonoBehaviour
    {
        [SerializeField] private List<SpriteCollectionsListData> collections;

        private static Dictionary<string, ASpriteCollection> _collectionLibrary;
        
        private void Awake()
        {
            if (_collectionLibrary == null) _collectionLibrary = new Dictionary<string, ASpriteCollection>();
            collections.ForEach(t => _collectionLibrary.Add(t.CollectionName, t.Collection));
        }
        
        public static ASpriteCollection GetSpriteCollection(string collectionName) => _collectionLibrary[collectionName];
    }

    [Serializable]
    public class SpriteCollectionsListData
    {
        [SerializeField] private string collectionName = String.Empty;
        [SerializeField] private ASpriteCollection collection;

        public string CollectionName => collectionName;

        public ASpriteCollection Collection => collection;
    }
}