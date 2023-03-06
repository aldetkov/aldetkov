using aldetkov.EventSystem;
using aldetkov.Localization.Core;
using aldetkov.UI.MessageNotify;
using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.UI.ButtonActions
{
    [RequireComponent(typeof(Button))]
    public class ButtonNotify : AButtonAction
    {
        [SerializeField] private NotifyType notifyType;
        [SerializeField] private string message;
        [SerializeField] private bool localize;
    
        protected override void OnButtonClick()
        {
            EventManager.RaiseEvent<IMessageNotifyShow>(t => t.Notify(notifyType, localize ? LocalizationManager.Localize(message) : message));
        }
    }
}
