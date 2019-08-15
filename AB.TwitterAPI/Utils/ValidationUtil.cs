using System;
using System.Collections.Generic;
using System.Linq;

namespace AB.TwitterAPI.Utils 
{
    public static class ValidationUtil
    {
        public static bool IsValidLength(int minLength, int maxLength, string str)
        {
            return str?.Length >= minLength && str?.Length <= maxLength;
        }
    }
}