namespace aldetkov.Strings
{
    public class StringUtils
    {
        public static string GetTimeMSFormat(int time) => $"{time / 60:00}:{time % 60:00}";
        
        public static bool CheckCorrectLenghtString(string str, int minChar)
        {
            return !string.IsNullOrWhiteSpace(str) && str.Length >= minChar;
        }
    }
}