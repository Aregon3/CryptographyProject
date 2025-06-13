using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovProekt
{
    static class Class1
    {
        public static char[] M { get; set; } = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯ0123456789 ".ToCharArray();
        public static Dictionary<char, int> SubsCodes { get; private set; }
        public const string TestText = "МРАЗЯ ДА ПРАВЯ ПРЕЗЕНТАЦИИ";
        private static void InitializeDictionary()
        {
            SubsCodes = new Dictionary<char, int>(M.Length);
            for (int i = 0; i < M.Length; i++)
                SubsCodes[M[i]] = i + 1;
        }

        public static Tuple<string, string> Encrypt(string Text = TestText)
        {
            InitializeDictionary();
            var TextAsChars = Text.ToCharArray();
            var resultWithEncryptedSpaces = new string[Text.Length];
            var resultWithoutEncryptedSpaces = new string[Text.Length];

            for (int i = 0; i < TextAsChars.Length; i++)
            {

                if (!M.Contains(TextAsChars[i])) throw new ArgumentOutOfRangeException(TextAsChars[i].ToString(), $"\nТози текст съдържа символа '{TextAsChars[i]}', който не е част от множеството допустими символи.");

                resultWithEncryptedSpaces[i] = SubsCodes[TextAsChars[i]].ToString();
                resultWithoutEncryptedSpaces[i] = SubsCodes[TextAsChars[i]].ToString();

                if (Text[i] == ' ')
                    resultWithoutEncryptedSpaces[i] = "  ";

            }

            return new Tuple<string, string>(String.Join(" ", resultWithoutEncryptedSpaces), String.Join(" ", resultWithEncryptedSpaces));
        }

        public static string Decrypt(string cryptogram, bool areSpacesEncrypted = true)
        {
            InitializeDictionary();

            string[] input;

            if (areSpacesEncrypted)
            {
                input = cryptogram.Split(' ');
                char[] result = new char[input.Length];

                for (int i = 0; i < input.Length; i++)
                {
                    var isNum = int.TryParse(input[i], out int num);
                    if (!isNum)
                        throw new ArgumentException("Пиши само числа!!");

                    result[i] = SubsCodes.SingleOrDefault(x => x.Value == num).Key;

                    if (result[i] == 0)
                        throw new ArgumentException("Тази криптограма превишава лимита на допустими множества!!");
                }

                return new String(result);
            }
            else
            {
                input = cryptogram.Split(new string[] { "    " }, StringSplitOptions.None);
                List<char> output = new List<char>();

                for (int word = 0; word < input.Length; word++)
                {
                    var wordSymbols = input[word].Split(' ');
                    for (int symbol = 0; symbol < wordSymbols.Length; symbol++)
                    {
                        output.Add(SubsCodes.Single(x => x.Value == int.Parse(wordSymbols[symbol])).Key);
                    }

                    if (word != input.Length - 1) output.Add(' ');
                }

                return new string(output.ToArray());
            }

        }
    }
}
