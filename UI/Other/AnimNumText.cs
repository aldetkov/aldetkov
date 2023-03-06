using System;
using System.Collections;
using aldetkov.EventSystem;
using aldetkov.Localization.Core;
using TMPro;
using UnityEngine;

namespace aldetkov.UI.Other
{
    public class AnimNumText : MonoBehaviour, IChangerLanguage
    {
        [SerializeField] private TMP_Text valueText;
        [SerializeField] private float timeAnim;
        [SerializeField] private string formatText = "{0}";
        [SerializeField] private bool localization;
        [SerializeField] private int crop = 1;

        private double current = 0;

        private void Awake()
        {
            if (valueText == null) valueText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            EventManager.Subscribe(this);
        }

        private void OnDisable()
        {
            EventManager.Unsubscribe(this);
        }

        public void SetValueAnim(double value)
        {
            if (Math.Abs(current - value) < 0.01d) return;
            StopAllCoroutines(); 
            StartCoroutine(SetValueAnimation(value));
        }
    
        public void SetValue(double value)
        {
            current = value;
            value = Math.Round(value, crop);
            valueText.text = localization ? LocalizationManager.Localize(formatText, $"{value}") : string.Format(formatText, $"{value}");
        }
    
        IEnumerator SetValueAnimation(double value)
        {
            float time = timeAnim;
            float rate = 0;
            while (time > 0)
            {
                rate = 1 - time / timeAnim;
                SetValue((value-current) * rate + current);
                time -= Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        
            SetValue(value);
        }

        public void ChangeLanguage()
        {
            if (!localization) return;
        
            SetValue(current);
        
        }
    }
}