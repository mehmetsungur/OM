using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace OIT.Core.Utilities.Common
{
    public static class RandomValueGenerator
    {
        public static string GenerateRandomGuid(int count)
        {
            return Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0, count);
        }

        public static string GenerateSecurityCode()
        {
            string list = "abcdefghijklmnoprstuvyz";
            list += list.ToUpper();
            list += "0123456789";

            Random r = new Random();
            string result = "";

            for (int i = 0; i < 9; i++)
                result += list[r.Next(list.Length)];

            return result;
        }

        public static HatchStyle GenerateHacthStyle()
        {
            Random r = new Random();
            return (HatchStyle)r.Next(53);
        }

        public static Color GenerateColor()
        {
            Random r = new Random();

            return Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }
    }
}