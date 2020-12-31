using System;
using System.Collections.Generic;

namespace StringProcessing
{
    /// <summary>
    /// Transliteration.
    /// </summary>
    public static class Transliteration
    {
        /// <summary>
        /// List with letters.
        /// </summary>
        private static Dictionary<string, string> _letters = new Dictionary<string, string>()
        {
            {"а","a"},
            {"б","b"},
            {"в","v"},
            {"г","g"},
            {"д","d"},
            {"е","e"},
            {"ё","yo"},
            {"ж","zh"},
            {"з","z"},
            {"и","i"},
            {"й","y"},
            {"к","k"},
            {"л","l"},
            {"м","m"},
            {"н","n"},
            {"о","o"},
            {"п","p"},
            {"р","r"},
            {"с","s"},
            {"т","t"},
            {"у","u"},
            {"ф","f"},
            {"х","h"},
            {"ц","ts"},
            {"ч","ch"},
            {"ш","sh"},
            {"щ","sch"},
            {"ъ","'"},
            {"ы","yi"},
            {"ь",""},
            {"э","e"},
            {"ю","yu"},
            {"я","ya"},
            {"А","A"},
            {"Б","B"},
            {"В","V"},
            {"Г","G"},
            {"Д","D"},
            {"Е","E"},
            {"Ё","Yo"},
            {"Ж","Zh"},
            {"З","Z"},
            {"И","I"},
            {"Й","Y"},
            {"К","K"},
            {"Л","L"},
            {"М","M"},
            {"Н","N"},
            {"О","O"},
            {"П","P"},
            {"Р","R"},
            {"С","S"},
            {"Т","T"},
            {"У","U"},
            {"Ф","F"},
            {"Х","H"},
            {"Ц","Ts"},
            {"Ч","Ch"},
            {"Ш","Sh"},
            {"Щ","Sch"},
            {"Ъ",""},
            {"Ы","Yi"},
            {"Ь",""},
            {"Э","E"},
            {"Ю","Yu"},
            {"Я","Ya"}
        };

        /// <summary>
        /// Make transliteration.
        /// </summary>
        /// <param name="message">Message for transliteration.</param>
        public static string TransliterationMessages(this string message)
        {
            string result = "";

            foreach (var symbol in message)
            {
                if (_letters.TryGetValue(symbol.ToString(), out var newLetter))
                {
                    result += newLetter;
                }
                else result += symbol;
            }

            return result;
        }
    }
}
