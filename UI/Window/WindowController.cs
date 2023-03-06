using System.Collections.Generic;
using UnityEngine;

namespace aldetkov.UI.Window
{
    public class WindowController : MonoBehaviour
    {
        [SerializeField] private WindowType startOpenWindow;
        
        public static WindowController Instance;
        
        private Dictionary<WindowType, List<WindowUI>> _windows;
        private Stack<WindowType> _openWindows = new Stack<WindowType>();
        
        private void Awake()
        {
            Instance = this;
            _windows = new Dictionary<WindowType, List<WindowUI>>();
        }

        public void AddWindow(WindowUI window)
        {
            if (!_windows.ContainsKey(window.WindowType)) _windows.Add(window.WindowType, new List<WindowUI>());
            
            _windows[window.WindowType].Add(window);
            
            if (startOpenWindow == window.WindowType) OpenWindow(window.WindowType, false, false);
            else window.Close();
        }

        public void OpenWindow(WindowType windowType, bool closePrev, bool closeAll)
        {
            if (!CheckContainsWindowsKey(windowType)) return;
            
            print($"open {windowType}");
            if (closeAll) CloseAll();
            else if (closePrev && _openWindows.Count != 0) CloseCurrentWindow();

            if (_openWindows.Count == 0 || !_openWindows.Contains(windowType))
            {
                _openWindows.Push(windowType);
            }
            
            _windows[windowType].ForEach(window => window.Open());
        }

        public void CloseAll()
        {
            while (_openWindows.Count > 0)
            {
                CloseWindow(_openWindows.Pop());
            }
        }

        public void CloseCurrentWindow()
        {
            if (_openWindows.Count > 0)
            {
                CloseWindow(_openWindows.Pop());
            }
        }
        
        public void CloseWindow(WindowType windowType)
        {
            if (!CheckContainsWindowsKey(windowType)) return;
            _windows[windowType].ForEach(window => window.Close());
        }

        private bool CheckContainsWindowsKey(WindowType windowType)
        {
            if (_windows.ContainsKey(windowType)) return true;
            
            Debug.LogError($"Key {windowType} not found");
            return false;
        }
    }

    public enum WindowType
    {
        Main = 0,
        Load = 1,
        Login = 2,
        Register = 3,
        ErrorMessage = 4,
        EnterEmail = 5,
        ErrorMessageLoadScene = 6,
        Rank = 7,
        UpClicksConfirm = 8,
        DailyQuests = 9,
        GameStats = 10,
        RewardsFlash = 11,
        LoadSimple = 12,
        Option = 13,
        SwapDiamond = 14,
        RewardsInfo = 15,
        RewardsRankFlash = 16,
        AddCoins = 17,
        Language = 18,
    }
}