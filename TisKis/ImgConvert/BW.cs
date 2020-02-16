using System;
using System.Drawing;

namespace TisKis.ImgConvert
{
    public struct RGB
    {
        public byte a;
        public byte b;
        public byte g;
        public byte r;
    };

    public class BW
    {
        private static int k_srednee(RGB rgb)
        {
            return (Convert.ToInt32(rgb.b) + Convert.ToInt32(rgb.g) + Convert.ToInt32(rgb.r)) / 3;
        }
        private static int k_max3(RGB rgb)
        {
            if (rgb.b > rgb.g & rgb.b > rgb.r)
                return Convert.ToInt32(rgb.b);
            if (rgb.g > rgb.b & rgb.g > rgb.r)
                return Convert.ToInt32(rgb.g);
            return Convert.ToInt32(rgb.r);
        }
        private static int k_min3(RGB rgb)
        {
            if (rgb.b < rgb.g & rgb.b < rgb.r)
                return Convert.ToInt32(rgb.b);
            if (rgb.g < rgb.b & rgb.g < rgb.r)
                return Convert.ToInt32(rgb.g);
            return Convert.ToInt32(rgb.r);
        }
        private static int k_srRG(RGB rgb)
        {
            return (Convert.ToInt32(rgb.g) + Convert.ToInt32(rgb.r)) / 2;
        }
        private static int k_srRB(RGB rgb)
        {
            return (Convert.ToInt32(rgb.b) + Convert.ToInt32(rgb.r)) / 2;
        }
        private static int k_srBG(RGB rgb)
        {
            return (Convert.ToInt32(rgb.g) + Convert.ToInt32(rgb.b)) / 2;
        }
        private static int k_R(RGB rgb)
        {
            return Convert.ToInt32(rgb.r);
        }
        private static int k_B(RGB rgb)
        {
            return Convert.ToInt32(rgb.b);
        }
        private static int k_G(RGB rgb)
        {
            return Convert.ToInt32(rgb.g);
        }
        private static RGB[,] bitmap_to_rgb(Bitmap b)
        {
            RGB[,] d_rgb = new RGB[b.Width, b.Height];
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    d_rgb[i, j].a = b.GetPixel(i, j).A;
                    d_rgb[i, j].b = b.GetPixel(i, j).B;
                    d_rgb[i, j].g = b.GetPixel(i, j).G;
                    d_rgb[i, j].r = b.GetPixel(i, j).R;
                }
            }
            return d_rgb;
        }
        private static Bitmap rgb_bw_srednee(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //Среднее арифметическое
                    k = k_srednee(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_max3(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По максимальному из 3
                    k = k_max3(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_min3(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По минимальному из 3
                    k = k_min3(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_RG(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По среднему RG
                    k = k_srRG(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_RB(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По среднему RB
                    k = k_srRB(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_BG(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По среднему BG
                    k = k_srBG(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_R(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По R
                    k = k_R(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_B(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По B
                    k = k_B(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        private static Bitmap rgb_bw_G(Bitmap b)
        {
            RGB[,] d_rgb = bitmap_to_rgb(b);
            int k = 0;
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    //По G
                    k = k_G(d_rgb[i, j]);
                    d_rgb[i, j].b = Convert.ToByte(k);
                    d_rgb[i, j].g = Convert.ToByte(k);
                    d_rgb[i, j].r = Convert.ToByte(k);
                    Color color = Color.FromArgb(
                        Convert.ToInt32(d_rgb[i, j].a),
                        Convert.ToInt32(d_rgb[i, j].r),
                        Convert.ToInt32(d_rgb[i, j].g),
                        Convert.ToInt32(d_rgb[i, j].b));
                    b.SetPixel(i, j, color);
                }
            }
            return b;
        }
        public static Bitmap rgb_bw(Bitmap b, int n)
        {
            switch (n)
            {
                case 0:
                    b = rgb_bw_srednee(b);
                    break;
                case 1:
                    b = rgb_bw_max3(b);
                    break;
                case 2:
                    b = rgb_bw_min3(b);
                    break;
                case 3:
                    b = rgb_bw_RG(b);
                    break;
                case 4:
                    b = rgb_bw_RB(b);
                    break;
                case 5:
                    b = rgb_bw_BG(b);
                    break;
                case 6:
                    b = rgb_bw_R(b);
                    break;
                case 7:
                    b = rgb_bw_G(b);
                    break;
                case 8:
                    b = rgb_bw_B(b);
                    break;
            }
            return b;
        }
    }
}