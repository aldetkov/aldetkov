using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.UI.Other
{
    public class ToggleSpriteChange : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Toggle toggle;
        [SerializeField] private Sprite enableIcon;
        [SerializeField] private Sprite disableIcon;

        private void Awake()
        {
            toggle.onValueChanged.AddListener(ChangeValue);
        }

        private void OnEnable()
        {
            ChangeValue(toggle.isOn);
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(ChangeValue);
        }

        private void ChangeValue(bool state)
        {
            icon.sprite = state ? enableIcon : disableIcon;
        }
    }
}