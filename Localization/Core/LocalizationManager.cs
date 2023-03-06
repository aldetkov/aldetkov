using System.Collections.Generic;
using aldetkov.EventSystem;
using SmartFormat;
using SmartFormat.Extensions;
using UnityEngine;

namespace aldetkov.Localization.Core
{

	public interface IChangerLanguage : IGlobalSubscriber
	{
		public void ChangeLanguage();
	}
	
	/// <summary>
	/// Localization manager.
	/// </summary>
    public static class LocalizationManager
    {
		private static Dictionary<LanguageType, Dictionary<string, string>> _dictionary = new Dictionary<LanguageType, Dictionary<string, string>>();
        private static LanguageType _language = LanguageType.English;
        private static string _languagePrefsKey = "languagegame";

        private static LanguageType _fallbackLang = LanguageType.English;
        
		/// <summary>
		/// Get or set language.
		/// </summary>
        public static LanguageType Language
        {
            get => _language;
            set
            {
	            _language = value; 
	            SaveLanguage(_language);
	            EventManager.RaiseEvent<IChangerLanguage>(t => t.ChangeLanguage()); 
            }
        }

		/// <summary>
        /// Check if a key exists in localization.
        /// </summary>
        public static bool HasKey(string localizationKey)
        {
            return _dictionary[Language].ContainsKey(localizationKey);
        }

        public static void Init()
        {
	        _dictionary = LocalizationUtils.ReadLocalizeFiles();
	        
	        if (!LoadLanguage(out _language))
	        {
		        _language = LocalizationUtils.GetLanguageSystemCode();
		        
		        SaveLanguage(_language);
	        }
	        
	        Smart.Default.GetFormatterExtension<PluralLocalizationFormatter>().DefaultTwoLetterISOLanguageName = 
		        LocalizationUtils.GetLanguageCodeShort(_language);
        }

        public static bool LoadLanguage(out LanguageType lang)
        {
	        lang = LanguageType.None;
	        
	        if (PlayerPrefs.HasKey(_languagePrefsKey))
	        {
		        lang = (LanguageType) PlayerPrefs.GetInt(_languagePrefsKey);
		        return true;
	        }
	        
	        return false;
        }
        
        public static void SaveLanguage(LanguageType langCode)
        {
	        PlayerPrefs.SetInt(_languagePrefsKey, (int)langCode);
	        PlayerPrefs.Save();
        }

        /// <summary>
        /// Get localized value by localization key.
        /// </summary>
        public static string Localize(string localizationKey)
        {
	        if (_dictionary.Count == 0)
	        {
		        Init();
	        }

            if (!_dictionary.ContainsKey(Language)) throw new KeyNotFoundException("Language not found: " + Language);

            var missed = !HasKey(localizationKey) || string.IsNullOrWhiteSpace(_dictionary[Language][localizationKey]);

            if (missed)
            {
                Debug.LogWarning($"Translation not found: {localizationKey} ({Language}).");

                return _dictionary[_fallbackLang].ContainsKey(localizationKey) ? _dictionary[_fallbackLang][localizationKey] : localizationKey;
            }

            return _dictionary[Language][localizationKey];
        }

	    /// <summary>
	    /// Get localized value by localization key.
	    /// </summary>
		public static string Localize(string localizationKey, params object[] args)
        {
            var pattern = Localize(localizationKey);

            return Smart.Format(pattern, args);
        }
    }
}