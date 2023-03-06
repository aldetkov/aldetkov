using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace aldetkov.Components.ButtonAnimEventTrigger
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Button))]
    public class BtnAnimEventHandler : MonoBehaviour, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] private ABtnAnimState btnAnimState = null;

        private Animator _animatorBtn;
        private Button _btn;

        private void Awake()
        {
            if (btnAnimState == null) btnAnimState = GetComponent<ABtnAnimState>();
            _animatorBtn = GetComponent<Animator>();
            _btn = GetComponent<Button>();
        }
        
        public void OnPressed()
        {
            btnAnimState.State = BtnStateAnimType.Pressed;
        }

        public void OnNormal()
        {
            btnAnimState.State = BtnStateAnimType.Normal;
        }

        public void OnDisabled()
        {
            btnAnimState.State = BtnStateAnimType.Disable;
        }

        private void SetNormalIfInteractable()
        {
            if (_btn.interactable) _animatorBtn.SetTrigger("Normal");
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            SetNormalIfInteractable();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //SetNormalIfInteractable();
        }
    }

    public enum BtnStateAnimType
    {
        Normal,
        Pressed,
        Disable
    }
}