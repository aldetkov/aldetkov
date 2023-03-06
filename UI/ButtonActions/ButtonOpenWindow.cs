using aldetkov.UI.Window;
using UnityEngine;

namespace aldetkov.UI.ButtonActions
{
    public class ButtonOpenWindow : AButtonAction
    {
        [SerializeField] private WindowType windowType;
        [SerializeField] private bool closePrev;
        [SerializeField] private bool closeAll;
        
        protected override void OnButtonClick()
        {
            WindowController.Instance.OpenWindow(windowType, closePrev, closeAll);
        }
    }
}