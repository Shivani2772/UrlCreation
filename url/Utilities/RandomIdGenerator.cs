using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlCreation.Utilities
{
    public static class RandomIdGenerator
    {
        private static char[] _base62chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static Random _random = new Random();

        public static string GetBase62(int length)
        {
            var stringBuilder = new StringBuilder(length);

            for(int i = 0; i < length; i++)
            {
                stringBuilder.Append(_base62chars[_random.Next(62)]);
            }

            return stringBuilder.ToString();
        }
    }
}
