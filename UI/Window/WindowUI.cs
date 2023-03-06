using UnityEngine;

namespace aldetkov.UI.Window
{
    public class WindowUI : MonoBehaviour
    {
        [SerializeField] private WindowType windowType;
        [SerializeField] private GameObject content;
        
        public WindowType WindowType => windowType;
        
        private void Start()
        {
            WindowController.Instance.AddWindow(this);
        }

        public virtual void Open()
        {
            content.gameObject.SetActive(true);
        }
        
        public virtual void Close()
        {
            content.gameObject.SetActive(false);
        }
    }
}