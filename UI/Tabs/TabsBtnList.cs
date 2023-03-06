using System.Collections;
using System.Collections.Generic;
using aldetkov.EventSystem;
using UnityEngine;

namespace aldetkov.UI.Tabs
{
    public interface ITabClick : IGlobalSubscriber
    {
        public void ClickTab(string tabName, uint tabIndex);
    }
    
    public class TabsBtnList : MonoBehaviour
    {
        [SerializeField] private List<TabBtn> tabs = new List<TabBtn>();
        [SerializeField] private string tabsName = "...";
        [SerializeField] private uint onActiveToEnable = 0;
        [SerializeField] private float delayToFirstEnable = 0;
        [SerializeField] private bool sendEventOnFirstOpen = false;

        private bool _firstOpen = true;
        
        private void Start()
        {
            for (var i = 0; i < tabs.Count; i++)
            {
                tabs[i].Init((uint)i, OnClickTab);
            }
        }

        private void OnEnable()
        {
            _firstOpen = true;
            StartCoroutine(DelayToFirstEnable());
        }

        private void OnClickTab(uint index)
        {
            tabs.ForEach(tab => tab.SetSelect(tab.Index != index));
            
            if (!_firstOpen || _firstOpen&&sendEventOnFirstOpen ) 
                EventManager.RaiseEvent<ITabClick>(e => e.ClickTab($"{tabsName}Tabs", index));
        }

        IEnumerator DelayToFirstEnable()
        {
            yield return new WaitForSeconds(delayToFirstEnable);
            OnClickTab(onActiveToEnable);
            _firstOpen = false;
        }
    }
}