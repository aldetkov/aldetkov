using System.Collections.Generic;
using aldetkov.EventSystem;
using UnityEngine;

namespace aldetkov.Strings
{
    public interface IDynamicText : IGlobalSubscriber
    {
        public void ChangeText(string key, string newValue);
    }
    
    public static class StringsLibrary
    {
        private static Dictionary<string, string> _textLibrary = new Dictionary<string, string>();

        public static void SetText(string key, string value)
        {
            if (_textLibrary.ContainsKey(key)) _textLibrary[key] = value;
            else _textLibrary.Add(key, value);
            
            EventManager.RaiseEvent<IDynamicText>(e => e.ChangeText(key, value));
        }

        public static string GetText(string key)
        {
            if (_textLibrary.ContainsKey(key)) return _textLibrary[key];
            
            Debug.LogError($"KEY {key} not found in TEXT LIBRARY");
            return "";
        }

    }
}