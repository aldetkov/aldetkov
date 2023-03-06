using UnityEngine;

namespace aldetkov.Components.ButtonAnimEventTrigger
{
    public abstract class ABtnAnimState : MonoBehaviour
    {
        private BtnStateAnimType _state = BtnStateAnimType.Normal;
        
        public BtnStateAnimType State
        {
            get => _state;
            set
            {
                if (_state == value) return;
                _state = value;
                ApplyState();
            }
        }

        protected void Start()
        {
            StartThis();
            ApplyState();
        }
        
        protected virtual void StartThis() {}
        
        protected abstract void ApplyState();
    }
}