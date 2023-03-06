using UnityEngine;
using UnityEngine.UI;

namespace aldetkov.UI.Other
{
    public class SetColorOnEnable : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color enableColor;
        [SerializeField] private float time = 0.5f;

        private float progress = 0f;
        
        private void Awake()
        {
            if (icon == null) icon = GetComponent<Image>();
        }

        private void OnEnable()
        {
            icon.color = defaultColor;
            progress = 0f;
        }

        private void FixedUpdate()
        {
            if (progress > 1f) return;

            progress += Time.fixedDeltaTime / time;
            icon.color = Color.Lerp(defaultColor, enableColor, progress);
        }
    }
}
