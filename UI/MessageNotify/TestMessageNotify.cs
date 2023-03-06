using aldetkov.EventSystem;
using UnityEngine;

namespace aldetkov.UI.MessageNotify
{
    public class TestMessageNotify : MonoBehaviour
    {
        [SerializeField] private KeyCode key = KeyCode.A;
        [SerializeField] private NotifyType notifyType;
        [SerializeField] private string text;
        
        private void Update()
        {
            if (Input.GetKeyDown(key))
            {
                EventManager.RaiseEvent<IMessageNotifyShow>(e => e.Notify(notifyType, text));
            }
        }
    }
}