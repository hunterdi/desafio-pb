using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Architecture.Extensions
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string word)
        {
            word = Regex.Replace(word, @"[^0-9A-Za-z ,]", string.Empty).ToLower();

            int length = word.Length;
            for (int i = 0; i < (length / 2); ++i)
            {
                if (word[i] != word[length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
