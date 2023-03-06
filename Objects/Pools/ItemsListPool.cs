using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace aldetkov.Objects.Pools
{
    public abstract class ItemsListPool<T, TK> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int createObjOnStart;
        
        private List<T> items = new List<T>();
        
        public Transform Parent => parent;
        public List<T> GetList => items;

        protected virtual bool IsCreateFirstHierarchy => false;
        
        protected abstract void SetInfo(T item, TK itemData, int index);
        
        protected virtual void Awake()
        {
            for (int i = 0; i < createObjOnStart; i++)
            {
                CreateItem();
                items[i].gameObject.SetActive(false);
            }
        }

        public virtual void RefreshList(List<TK> itemsData)
        {
            for (int i = 0; i < itemsData.Count; i++)
            {
                if (i >= items.Count) CreateItem();
                items[i].gameObject.SetActive(true);
                SetInfo(items[i], itemsData[i], i);
            }

            for (int i = itemsData.Count; i < items.Count; i++)
            {
                items[i].gameObject.SetActive(false);
            }
        }

        public T GetItem(int index)
        {
            if (index >= items.Count || index < 0)
            {
                Debug.LogError("Element not found");
                return null;
            }

            return items[index];
        }

        public void ResetPool()
        {
            items.ForEach(item =>
            {
                item.gameObject.SetActive(false);
                item.transform.SetParent(parent);
            });
        }
        
        private void CreateItem()
        {
            // If parent is null, make objects children of this script object 
            items.Add(Instantiate(itemPrefab, parent ? parent : transform).GetComponent<T>());
            if (IsCreateFirstHierarchy) items.Last().transform.SetSiblingIndex(0);
        }
    }
}