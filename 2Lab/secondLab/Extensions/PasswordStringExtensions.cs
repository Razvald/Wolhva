﻿using System.Text;

namespace secondLab.Extensions
{
    static class PasswordStringExtensions
    {
        public static string ToHash(this string pswd)
        {
            return pswd.ToBytes().Hash().ToHashString();
        }

        private static byte[] ToBytes(this string pswd)
        {
            return Encoding.UTF8.GetBytes(pswd);
        }
        private static byte[] Hash(this byte[] bytes)
        {
            return System.Security.Cryptography.SHA256.HashData(bytes);
        }
        private static string ToHashString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in bytes)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }
    }
}
