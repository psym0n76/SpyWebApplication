using System;
using System.Text.RegularExpressions;

namespace Spy.Library
{
    public static class ExtensionMethods
    {
        public static int[] ToIntArray(this string str)
        {
            var removeBrackets = str.RemoveSquareBrackets();
            var arr = removeBrackets.Split(',');
            return Array.ConvertAll(arr, int.Parse);
        }

        public static string RemoveSquareBrackets(this string str)
        {
            return Regex.Replace(str, @"[\[\]']+", "");
        }
    }
}
