using System;
using System.Text;

namespace Lesson_11_BDD.Utils
{
    public class PasswordGenerator
    {
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
                res.Append(rnd.Next(10));
            }
            return res.ToString();
        }
    }
}
