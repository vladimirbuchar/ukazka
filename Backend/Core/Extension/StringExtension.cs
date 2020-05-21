using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Extension
{
    /// <summary>
    /// Extension for String
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// method for create hash from string
        /// </summary>
        /// <param name="inputString">input string</param>
        /// <returns>string</returns>
        public static string GetHashString(this string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
        private static byte[] GetHash(string inputString)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        /// <summary>
        /// method for validation email address
        /// </summary>
        /// <param name="inputString">string - email address</param>
        /// <returns>boolean - true when email is valid, false when email is not valid</returns>
        public static bool IsValidEmail(this string inputString)
        {
            try
            {
                if (string.IsNullOrEmpty(inputString))
                {
                    return false;
                }
                return Regex.IsMatch(inputString,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        /// <summary>
        /// method for convert normal string to base64
        /// </summary>
        /// <param name="inputString">some string value</param>
        /// <returns>encode string value in base64</returns>
        public static string ConvertToBase64(this string inputString)
        {
            byte[] encodedBytes = Encoding.Unicode.GetBytes(inputString);
            return Convert.ToBase64String(encodedBytes);
        }
        /// <summary>
        /// method for convert base64 to normal string 
        /// </summary>
        /// <param name="inputString">some base64 string</param>
        /// <returns>encode string value </returns>
        public static string ConvertFromBase64ToUTF8(this string inputString)
        {
            byte[] decodedBytes = Convert.FromBase64String(Convert.ToBase64String(Encoding.Unicode.GetBytes(inputString)));
            return Encoding.UTF8.GetString(decodedBytes);
        }
        /// <summary>
        /// metohod return text backwards 
        /// </summary>
        /// example abcd => dcba 
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseText(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        /// <summary>
        /// it is asmae function isnulloremty but it makes trim after
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyWithTrim(this string s)
        {
            return string.IsNullOrEmpty(s?.Trim());
        }
        /// <summary>
        /// validate uri
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValidUri(this string s)
        {
            return Uri.TryCreate(s, UriKind.Absolute, out Uri outUri)
               && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
        /// <summary>
        /// validate phone number
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValidPhoneNumber(this string s)
        {
            return Regex.Match(s, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").Success;
        }
    }
}