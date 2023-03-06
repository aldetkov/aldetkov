using aldetkov.Strings;

namespace aldetkov.UI.Window
{
    public static class WindowUtils
    {
        public static void ErrorOpen(this WindowController wc, string err, WindowType back, bool closePrev, bool closeAll = false, WindowType windowError = WindowType.ErrorMessage)
        {
            StringsLibrary.SetText("Error", err);
            StringsLibrary.SetText("ErrorBack", $"{(int) back}");
            wc.OpenWindow(windowError, closePrev, closeAll);
        }
    }
}