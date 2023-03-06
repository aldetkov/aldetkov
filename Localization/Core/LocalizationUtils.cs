using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

namespace aldetkov.Localization.Core
{
    public static class LocalizationUtils
    {
        public static LanguageType GetLanguageSystemCode()
        {
            switch (Application.systemLanguage)
            {
                case SystemLanguage.Belarusian:
                case SystemLanguage.Russian:
                case SystemLanguage.Ukrainian:
                    return LanguageType.Russian;
                case SystemLanguage.Indonesian:
                    return LanguageType.Indonesian;
                default:
                    return LanguageType.English;
            }
        }
        
        public static string GetLanguageCodeShort(LanguageType codeFull)
        {
            return codeFull switch
            {
                LanguageType.English => "en",
                LanguageType.Russian => "ru",
                LanguageType.Indonesian => "id",
                _ => "en"
            };
        }

        public static Dictionary<LanguageType, Dictionary<string, string>> ReadLocalizeFiles(string path = "Localization")
        {
            Dictionary<LanguageType, Dictionary<string, string>> dictionary = new Dictionary<LanguageType, Dictionary<string, string>>();

            var textAssets = Resources.LoadAll<TextAsset>(path);

            foreach (var textAsset in textAssets)
            {
                var text = textAsset.text.Replace("\r\n", "\n").Replace("\"\"", "[_quote_]");
                var matches = Regex.Matches(text, "\"[\\s\\S]+?\"");

                foreach (Match match in matches)
                {
                    text = text.Replace(match.Value, match.Value.Replace("\"", null).Replace(",", "[_comma_]").Replace("\n", "[_newline_]"));
                }

                // Making uGUI line breaks to work in asian texts.
                text = text.Replace("。", "。 ").Replace("、", "、 ").Replace("：", "： ").Replace("！", "！ ").Replace("（", " （").Replace("）", "） ").Trim();

                var lines = text.Split('\n').Where(i => i != "").ToList();
                var languages = lines[0].Split(',').Skip(1).Select(i => i.Trim()).Select(i =>
                {
                    try
                    {
                        return Enum.Parse<LanguageType>(i);
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e + $" ERROR LANG = {i}");
                        return LanguageType.None;
                    }
                }).ToList();

                for (var i = 0; i < languages.Count; i++)
                {
                    if (!dictionary.ContainsKey(languages[i]))
                    {
                        dictionary.Add(languages[i], new Dictionary<string, string>());
                    }
                }
				
                for (var i = 1; i < lines.Count; i++)
                {
                    var columns = lines[i].Split(',').Select(j => j.Trim()).Select(j => j.Replace("[_quote_]", "\"").Replace("[_comma_]", ",").Replace("[_newline_]", "\n")).ToList();
                    var key = columns[0];

                    if (key == "") continue;

                    for (var j = 0; j < languages.Count; j++)
                    {
                        dictionary[languages[j]].Add(key, columns[j+1]);
                    }
                }
            }

            return dictionary;
        }
        
        public static string GetLanguageName(this LanguageType type)
        {
            return type switch
            {
                LanguageType.English => "English",
                LanguageType.Russian => "Russian",
                LanguageType.Indonesian => "Indonesian",
                _ => "English"
            };
        } 
    }
    
    public enum LanguageType
    {
        None = 0,
        English = 1,
        Russian = 2,
        Indonesian = 3,
    }
}