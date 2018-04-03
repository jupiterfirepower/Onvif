using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Onvif.Contracts.Helper
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);
        private static readonly CryptoRandom CryptoRandom = new CryptoRandom();
        private static readonly object SyncLock = new object();

        public static string GenUniqueId()
        {
            return RemoveNonAlphaCharacters(string.Format("{0}-{1}", GenShortId(), GetUniqueKey(10)));
        }

        public static string GenStamp()
        {
            return string.Format("{0}", GetUniqueKey(35));
        }

        public static string GenUniqueActorSystemId()
        {
            var result = string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}", GetUniqueKey(15), GenerateKey(), RandomNumber(), GenerateToken(10), CryptoRandomNumber(), GenShortId(), Guid.NewGuid(), GenerateKeyBasedOnDateTime());
            return RemoveNonAlphaCharacters(result);
        }

        public static string GenUniqueActorNameId()
        {
            return RemoveNonAlphaCharacters(string.Format("{0}-{1}-{2}", GetUniqueKey(10), Guid.NewGuid(), GenShortId()));
        }

        private static string RemoveNonAlphaCharacters(string data)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            return rgx.Replace(data, string.Empty);
        }

        private static string GenShortId()
        {
            long i = Guid.NewGuid().ToByteArray().Aggregate<byte, long>(1, (current, b) => current * ((int)b + 1));
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        private static string GetUniqueKey(int maxSize)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private static string GenerateToken(int length)
        {
            using (var cryptRng = new RNGCryptoServiceProvider())
            {
                byte[] tokenBuffer = new byte[length];
                cryptRng.GetBytes(tokenBuffer);
                return Convert.ToBase64String(tokenBuffer).TrimEnd('=');
            }
        }

        private static string GenerateKey()
        {
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                myRijndael.GenerateKey();
                // Encrypt the string to an array of bytes.
                return Convert.ToBase64String(myRijndael.Key).TrimEnd('=');
            }
        }

        private static string GenerateKeyBasedOnDateTime()
        {
            return string.Format("{0}-{1}-{2}", DateTime.Now.Ticks.ToString("x"),
                DateTime.Now.ToString(CultureInfo.InvariantCulture).GetHashCode().ToString("x"),
                Guid.NewGuid().ToString().GetHashCode().ToString("x"));
        }

        private static int RandomNumber(int minimum = int.MinValue, int maximum = int.MaxValue)
        {
            lock (SyncLock) // synchronize
            {
                return Random.Next(minimum, maximum);
            }
        }

        private static int CryptoRandomNumber(int minimum = int.MinValue, int maximum = int.MaxValue)
        {
            lock (SyncLock) // synchronize
            {
                return CryptoRandom.Next(minimum, maximum);
            }
        }
    }
}
