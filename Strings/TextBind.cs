using aldetkov.EventSystem;
using TMPro;
using UnityEngine;

namespace aldetkov.Strings
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextBind : MonoBehaviour, IDynamicText
    {
        [SerializeField] private string textKey;
        [SerializeField] private bool setOnEnable = true;
        
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            EventManager.Subscribe(this);
            if (setOnEnable) _text.text = StringsLibrary.GetText(textKey);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe(this);
        }

        public void ChangeText(string key, string newValue)
        {
            if (key == textKey) _text.text = newValue;
        }
    }
}