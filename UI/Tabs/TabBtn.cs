using System;
using aldetkov.UI.ButtonActions;

namespace aldetkov.UI.Tabs
{
    public class TabBtn : AButtonAction
    {
        public uint Index { get; private set; }

        private Action<uint> _clickCallback;
    
        protected override void OnButtonClick()
        {
            btn.interactable = false;
            _clickCallback?.Invoke(Index);
        }

        public void Init(uint id, Action<uint> callback)
        {
            _clickCallback = callback;
            Index = id;
        }
        
        public virtual void SetSelect(bool active)
        {
            btn.interactable = active;
        }
    }
}