namespace LeetCoding
{
    public static class LeetCodeFN
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target && i != j)
                    {
                        int[] result_array = { i, j };
                        return result_array;
                    }
                }
            }
            return Array.Empty<int>();
        }

        public static bool IsPalindrome(int x)
        {
            int n = x;
            int rem;
            int reverse = 0;
            if (n < 0)
            {
                return false;
            }
            else
            {
                while (n != 0)
                {
                    rem = n % 10;
                    reverse = reverse * 10 + rem;
                    n /= 10;
                }
                return reverse == x;
            }
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> romanNumberMap = new Dictionary<char, int>
            {
                {'I', 1},{'V', 5},{'X', 10},{'L', 50},{'C', 100},{'D', 500},{'M', 1000}
            };

            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char currentRomanNumber = s[i];
                romanNumberMap.TryGetValue(currentRomanNumber, out int number);

                if (i + 1 < s.Length && romanNumberMap[s[i + 1]] > romanNumberMap[currentRomanNumber])
                {
                    sum -= number;
                }
                else
                {
                    sum += number;
                }
            }

            return sum;
        }

        public static string IntToRoman(int num)
        {
            Dictionary<int, string> romanNumbersMap = new Dictionary<int, string>()
            {
                { 1, "I" }, { 4, "IV" }, { 5, "V" },
                { 9, "IX"}, { 10, "X" }, { 40, "XL" },
                { 50, "L" }, { 90, "XC" }, { 100, "C" },
                { 400, "CD"}, { 500, "D" }, { 900, "CM"},
                { 1000, "M" }
            };

            string romanNumberResult = "";

            foreach (var item in romanNumbersMap.Reverse())
            {
                if (num <= 0) break;
                while (num >= item.Key)
                {
                    romanNumberResult += item.Value;
                    num -= item.Key;
                }
            }

            return romanNumberResult;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return string.Empty;
            }

            Array.Sort(strs);
            string prefix = string.Empty;
            for (int i = 0; i < strs[0].Length; i++)
            {
                char currentChar = strs[0][i];
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i > strs[j].Length || strs[j][i] != currentChar)
                    {
                        return prefix;
                    }
                }
                prefix += currentChar;
            }
            return prefix;
        }

        public static bool IsValid(string s)
        {
            Stack<char> parenthesies = new Stack<char>();

            foreach (char _char_ in s)
            {
                switch (_char_)
                {
                    case '(':
                        parenthesies.Push(')');
                        break;
                    case '[':
                        parenthesies.Push(']');
                        break;
                    case '{':
                        parenthesies.Push('}');
                        break;
                    case '}':
                    case ']':
                    case ')':
                        if (parenthesies.Count == 0 || _char_ != parenthesies.Pop())
                        {
                            return false;
                        }
                        break;
                }
            }
            return parenthesies.Count == 0;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int i = 0;

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    int tempVal = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tempVal;
                    i++;
                }
            }
            return i;
        }

        public static int FirstOccurance(string haystack, string needle)
        {
            if (haystack.Contains(needle))
            {
                return haystack.IndexOf(needle);
            }

            return -1;
        }

        public static int SearchInsert(int[] nums, int target)
        {
            if (Array.IndexOf(nums, target) != -1)
            {
                return Array.IndexOf(nums, target);
            }
            else if (Array.IndexOf(nums, target) == -1 && target > nums[^1])
            {
                return Array.IndexOf(nums, nums[^1]) + 1;
            }
            else if (Array.IndexOf(nums, target) == -1 && target < nums[0])
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 1; j < nums.Length; j++)
                    {
                        if (nums[i] < target && nums[j] > target)
                        {
                            return j;
                        }
                    }
                }
            }
            return -1;
        }

        public static int LengthOfLastWord(string s)
        {
            return s.Trim().Split(' ')[^1].Length;
        }

        public static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i] += 1;
                    return digits;
                }
            }
            int[] newArray = new int[] { 1 };
            return newArray.Concat(digits).ToArray();
        }

        public static string AddBinary(string a, string b)
        {
            a = new(a.ToCharArray().Reverse().ToArray());
            b = new(b.ToCharArray().Reverse().ToArray());

            string result = string.Empty;
            int carry = 0;

            for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
            {
                int digitA = i < a.Length ? (int)(a[i]) - (int)('0') : 0;
                int digitB = i < b.Length ? (int)(b[i]) - (int)('0') : 0;

                int total = digitA + digitB + carry;
                string _char = Convert.ToString(total % 2);
                result = _char + result;
                carry = total / 2;
            }

            if (carry != 0)
            {
                result = "1" + result;
            }
            return result;
        }
    }
}
