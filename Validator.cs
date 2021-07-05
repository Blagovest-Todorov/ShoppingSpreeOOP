using System;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str, string exceptionMessage) 
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfNumberIsNegative(decimal number, string exceptionMessage) 
        {
            if (number < 0)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
