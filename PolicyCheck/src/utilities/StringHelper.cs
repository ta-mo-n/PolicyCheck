using System;

namespace PolicyCheck.src.utilities
{
    internal static class StringHelper
    {
        /// <summary>
        /// IsStringEqual
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsStringEqual(string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
    }
}
