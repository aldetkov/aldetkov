using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.UI.ButtonActions
{
    [RequireComponent(typeof(Button))]
    public abstract class AButtonAction : MonoBehaviour
    {
        protected Button btn;

        protected virtual void Awake()
        {
            btn = GetComponent<Button>();
        }

        protected virtual void Start()        {

            btn.onClick.AddListener(OnButtonClick);
        }

        protected virtual void OnDestroy()
        {
            btn.onClick.RemoveListener(OnButtonClick);
        }

        protected abstract void OnButtonClick();
    }
}