using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace OIT.Core.Utilities.Common
{
    public static class ImageHelper
    {
        public static string SecurityCode { get; set; }
        public static byte[] CreateSecurityImage()
        {
            SecurityCode = RandomValueGenerator.GenerateSecurityCode();

            Bitmap bmp = new Bitmap(150, 50);
            Graphics gr = Graphics.FromImage(bmp);

            HatchBrush hb = new HatchBrush(RandomValueGenerator.GenerateHacthStyle(), Color.White, Color.Orange);
            gr.FillRectangle(hb, new Rectangle(0, 0, 150, 50));
            gr.DrawString(SecurityCode, new Font("Verdana", 14f), Brushes.White, 20, 10);

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }
    }
}