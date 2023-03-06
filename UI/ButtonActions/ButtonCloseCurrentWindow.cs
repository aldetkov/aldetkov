using aldetkov.UI.Window;

namespace aldetkov.UI.ButtonActions
{
    public class ButtonCloseCurrentWindow : AButtonAction
    {
        protected override void OnButtonClick()
        {
            WindowController.Instance.CloseCurrentWindow();
        }
    }
}