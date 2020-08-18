using System.Security.Cryptography;
using System.Text;

namespace ErrorHub.Domain.Utilities
{
    public static class Md5
    {
        public static string Generate(this string text)
        {
            var hash = MD5.Create();
            var data = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            var stringBuilder = new StringBuilder();
            foreach (var t in data)
                stringBuilder.Append(t.ToString("x2"));

            return stringBuilder.ToString();
        }
    }
}
