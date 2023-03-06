using aldetkov.EventSystem;
using aldetkov.Localization.Core;
using TMPro;
using UnityEngine;

namespace aldetkov.Localization.Binders
{
	/// <summary>
	/// Localize text component.
	/// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class LocalizedText : MonoBehaviour, IChangerLanguage
    {
        [SerializeField] private string LocalizationKey;

        public void Start()
        {
            Localize();
            EventManager.Subscribe(this);
        }

        public void OnDestroy()
        {
            EventManager.Unsubscribe(this);
        }

        private void Localize()
        {
            GetComponent<TMP_Text>().text = LocalizationManager.Localize(LocalizationKey);
        }

        public void ChangeLanguage()
        {
            Localize();
        }
    }
}