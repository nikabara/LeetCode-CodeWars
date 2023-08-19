using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCoding
{
    public static class CodeWars
    {
        public static int DuplicateCount(string str)
        {
            List<char> distArr = new List<char>();
            str = str.ToLower();
            int distCount = 0;
            int cur = 0;

            for (int i = 1; i < str.Length; i++)
            {
                if (str[cur] == str[i] && !distArr.Contains(str[cur]))
                {
                    distArr.Add(str[cur]);
                    cur++;
                    i = cur;
                    distCount++;
                }
                if (str[cur] != str[^1] && i == str.Length - 1)
                {
                    distArr.Add(str[cur]);
                    cur++;
                    i = cur;
                }
            }

            return distCount;
        }

        public static string MakeComplement(string dna)
        {
            Dictionary<char, char> DNM_Config_Map = new Dictionary<char, char>()
            {
                {'A', 'T'}, {'T', 'A'}, {'G', 'C'}, {'C', 'G'}
            };

            string result = string.Empty;

            for (int i = 0; i < dna.Length; i++)
            {
                DNM_Config_Map.TryGetValue(dna[i], out char matchingElement);
                result += matchingElement;
            }

            return result;
        }

        public static string ToJadenCase(this string phrase)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(phrase);
        }

        /// <summary>
        ///  link to kata https://www.codewars.com/kata/517abf86da9663f1d2000003/train/csharp
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamelCase(string str)
        {

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string[] words = str.Trim().Split(new char[] { '-', '_', '@', '&', '#', '$', ' ', '!', '*' });
            words = words.Select(x => textInfo.ToTitleCase(x)).ToArray();
            string result = string.Join("", words);
            result = char.IsLower(str[0]) ? char.ToLower(result[0]) + result.Substring(1) : result;
            return result;
        }

        public static int SquareDigits(int n)
        {
            char[] nChars = n.ToString().ToCharArray();
            string result = string.Empty;

            for (int i = 0; i < nChars.Length; i++)
            {
                int nDigit = (int)Math.Pow((double)(Convert.ToInt32(nChars[i]) - Convert.ToInt32('0')), 2);
                result += nDigit.ToString();
            }

            return Convert.ToInt32(result);
        }

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            int iterableLen = 0;
            foreach (var item in iterable)
            {
                iterableLen++;
            }

            int indexer = 1;

            foreach (var item in iterable)
            {
                if (indexer < iterableLen && !item.Equals(iterable.ElementAt(indexer)))
                {
                    yield return item;
                }
                if (indexer == iterableLen - 1)
                {
                    yield return iterable.ElementAt(indexer);
                }

                indexer++;
                iterable.GetEnumerator().MoveNext();
            }
        }

        public static string Accum(string s)
        {
            TextInfo textInfo = new CultureInfo("en-US").TextInfo;

            char[] azChars = s.ToCharArray();
            string[] azStrings = new string[azChars.Length];
            string tempString = string.Empty;

            for (int i = 0; i < azChars.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    tempString += char.ToLower(azChars[i]);
                }
                azStrings[i] = textInfo.ToTitleCase(tempString);
                tempString = string.Empty;
            }

            return string.Join('-', azStrings);
        }

        /// <summary>
        /// kata link : https://www.codewars.com/kata/5804acd4e053562b5f00004d/train/csharp
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int SumOfTwoSumTargets(int[] numbers, int min, int max)
        {
            int[] targets = Enumerable.Range(min, max - min).ToArray();

            int targetIndex = 0;
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (targetIndex > targets.Length - 1)
                    {
                        return sum;
                    }
                    if (targetIndex < targets.Length && numbers[i] + numbers[j] == targets[targetIndex])
                    {
                        i = 0;
                        j = 0;
                        sum += targets[targetIndex];
                        targetIndex++;
                    }
                    if (j == numbers.Length - 1)
                    {
                        i = 0;
                        j = 0;
                        targetIndex++;
                    }
                }
            }

            return sum;
        }

        public static string GetMiddle(string s)
        {
            int offset = s.Length % 2 == 0 ? 1 : 0;
            string middle = s.Substring(s.Length / 2 - offset, offset + 1);

            return middle;
        }

        /// <summary>
        ///                                     ⣠⣤⣤⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣶⣿⠟⠉⠉⠻⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣾⠿⠉⠀⠀⠀⠀⠀⠹⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣾
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣾⡿⠛⠉
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⡿⠟⠁⠀⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣴⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣷⣶⣶⣦⣤⣤⣄⡀⠀⢀⣠⣾⣿⠿⠋⠀⠀⠀⠀⠀⣠
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⠶⠞⣿⠟⠋⠉⠉⠙⣻⠿⢿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⢀⡼⠁
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⠁⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠟⠁⢠⡞⠁⠀⠀⠀⢀⡴⠋⠀⢀⡿⠋⠁⠀⠀⠀⠀⠀⠀⠀⡞⠁⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣼⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⠃⠀⢠⠏⠀⠀⠀⠀⣰⠏⠀⠀⣠⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡥⠤⡀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣇⠀⣠⡏⠀⠀⠀⠀⣼⠁⠀⠀⣰⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠁
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣄⣄⣼⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡶⠋⠀⠀⠀⠀⢸⣧⠀⠀⣴⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢧⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⠀⠀⠀⠀⣾⡿⠿⣿⡿⠁⠀⠀⠀⠀⠀⠀⣠⣶⣶⣶⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳
        ///⠀⠀⠀⠀⠀⠀⢀⣾⠿⠛⢿⣿⣷⣄⡀⣿⠃⠀⠈⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠀⠀⣠⣤⣦⣼⣿⠀⠀⠀⣿⣿⣿⣿⣿⣦⣀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⢀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣾⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀
        ///⠀⣠⣾⡿⠋⠉⠉⠁⠀⠀⠀⠀⠉⢯⡙⠻⣿⣿⣷⣤⡀⠀⠀⠀⠀⢿⣿⣿⣿⣿⡿⠃⢀⡤⠖⠋⠉⠉⠉⠉⠉⠉⠒⠦⣄⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀
        ///⣾⣿⠋⠀⠀⠀⠀⣀⣀⠀⠀⠀⠀⠀⠙⢦⣄⠉⠻⢿⣿⣷⣦⡀⠀⠈⠙⠛⠛⠋⠀⢰⠟⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣄⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀
        ///⣿⡇⠀⠀⠀⣴⠟⣫⣿⣿⣄⠀⠀⠀⠀⡶⢌⡙⠶⣤⡈⠛⠿⣿⣷⣦⣀⠀⠀⠀⠀⡇⠀⢻⣄⠀⠀⣠⢷⠀⠀⠀⠀⠀⡶⠀⠘⡆⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀
        ///⣿⡇⠀⠀⢸⣟⢸⣿⣿⣿⣿⠀⠀⠀⠀⡇⠀⠈⠛⠦⣝⡳⢤⣈⠛⠻⣿⣷⣦⣀⠀⠀⠀⠀⠈⠙⠋⠁⠀⠛⠦⠤⠤⠚⠁⠀⠀⢳⠀⠀⠀⠈⠛⠿⠿⠿⠟⠋⠀⠀⠀⠀⠀⠀⠀
        ///⣿⡇⠀⠀⠈⢿⣞⣿⣿⣿⠏⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠙⠳⢬⣛⠦⠀⠙⢻⣿⣷⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⣿⡇⠀⠀⠀⠀⠉⠛⠋⠁⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠈⠁⠀⠀⠈⣿⠉⢻⣿⣷⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡼⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⣿⡇⠀⠀⠀⠀⠀⣠⣄⠀⠀⢰⠶⠒⠒⢧⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⢸⡇⢸⡟⢿⣷⣦⣴⣶⣶⣶⣶⣤⣔⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⣿⡇⠀⠀⣤⠀⠀⠿⠿⠁⢀⡿⠀⠀⠀⡄⠈⠙⡷⢦⣄⡀⠀⠀⠀⠀⠀⠀⠀⣿⠀⢸⡇⢸⡇⠀⣿⠙⣿⣿⣉⠉⠙⠿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⣿⡇⠀⠀⠙⠷⢤⣀⣠⠴⠛⠁⠀⠀⠀⠇⠀⠀⡇⢸⡏⢹⡷⢦⣄⡀⠀⠀⠀⣿⡀⢸⡇⢸⡇⠀⡟⠀⢸⠀⢹⡷⢦⣄⣘⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⣿⣿⠢⣤⡀⠀⠀⠀⠀⠀⠀⣠⠾⣿⣿⡷⣤⣀⡇⠸⡇⢸⡇⢸⠉⠙⠳⢦⣄⡻⢿⣾⣧⣸⣧⠀⡇⠀⢸⠀⢸⡇⢤⣈⠙⠻⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⢹⣿⣷⣌⡉⠛⠲⢶⣶⠖⠛⠛⢶⣄⡉⠛⠿⣽⣿⣶⣧⣸⡇⢸⠀⠀⠀⠀⠈⠙⠲⢮⣝⠻⣿⣷⣷⣄⣸⠀⢸⡇⠀⠈⠁⠀⢸⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠈⠙⠻⢿⣷⣶⣤⣉⡻⢶⣄⣀⠈⠙⠳⢦⣈⡉⠻⢿⣿⣷⣾⣦⡀⠀⠀⠀⠀⠀⠀⠈⠙⠲⢭⣛⠿⣿⣷⣼⡇⠀⠀⠀⠀⠈⣿⡇⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⣀
        ///⠀⠀⠀⠀⠀⠈⠙⠻⢿⣿⣷⣶⣽⣻⡦⠀⠀⠈⠙⠷⣦⣌⡙⠻⢿⣟⣷⣤⣀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠳⢯⣻⡇⠀⠀⠀⠀⠀⢸⣿⠀⣀⠀⠀⠀⠀⠈⠳⣄⠀⠀⠀⢀⡏⠙⠛
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠻⢿⣿⣿⣿⣶⣤⣤⣤⣀⣈⠛⠷⣤⣈⡛⠷⢽⡻⢶⣄⣀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠳⢤⣀⠀⠀⢸⣿⡀⠈⠳⢤⣀⣀⣰⠃⠈⠛⠶⠶⠿⠃⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣿⡿⠛⠉⠙⠛⠛⠻⢷⣦⣄⣩⣿⠶⠖⠛⠛⠛⠛⠛⠛⠿⢷⣶⣦⣄⠀⠀⠀⠀⠉⢻⣶⣿⣿⠇⠀⠀⠀⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⠁⠀⠀⠀⠀⠀⠀⠀⣿⣿⠋⠀⠀⠀⠀⠀⣠⠖⠂⠀⠀⠀⠈⠙⠿⣿⣦⡄⠀⠀⣸⣿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⣰⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢿⣶⣄⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⢸⣧⠀⠀⢀⠞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠙⢿⣿⣇⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ///⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡿⠿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡿⠦⠠⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠧⠤⠄⠙⡿⠿⠦⠤⠤⠤⠤⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public static int Cats(int start, int finish)
        {
            int stepsLeft = finish - start;
            int steps = 0;

            while (stepsLeft != 0)
            {
                if (stepsLeft - 3 >= 0)
                {
                    stepsLeft -= 3;
                    steps++;
                }
                else if (stepsLeft - 1 >= 0)
                {
                    stepsLeft -= 1;
                    steps++;
                }
            }

            return steps;
        }

        public static int CountBits(int n)
        {
            return Convert.ToString(n, 2).Count(x => x == '1');
        }

        public static string DoubleChar(string s)
        {
            char[] sChars = s.ToCharArray();
            string resultStr = string.Empty;
            for (int i = 0; i < sChars.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    resultStr += sChars[i];
                }
            }

            return resultStr;
        }

        public static string DoubleChar2(string s)
        {
            return string.Join("", s.Select(x => "" + x + x));
        }

        public static int MaxSequence(int[] arr)
        {
            if (arr.Length == 0)
            {
                return arr.Length;
            }
            int maxSub = arr[0];
            int curSum = 0;

            foreach (var n in arr)
            {
                if (curSum < 0)
                {
                    curSum = 0;
                }
                curSum += n;
                maxSub = Math.Max(maxSub, curSum);
            }
            return maxSub;
        }
    }
}
