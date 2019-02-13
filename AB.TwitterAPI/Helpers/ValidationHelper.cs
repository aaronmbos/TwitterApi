using System;
using System.Collections.Generic;
using System.Linq;

namespace AB.TwitterAPI.Helpers 
{
    internal static class ValidationHelper
    {
        internal static bool IsValidLength(int minLength, int maxLength, string str)
        {
            return str?.Length >= minLength && str?.Length <= maxLength;
        }
    }
}