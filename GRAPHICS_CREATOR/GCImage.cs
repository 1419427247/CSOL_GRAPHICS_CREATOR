using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GRAPHICS_CREATOR
{
    class GCImage
    {
        public Bitmap bitmap;
        public int boxCount;
        public string data = "";
        public string Type { get; }

        private Graphics graphics;


        public GCImage(char c,Font font)
        {
            bitmap = new Bitmap(64,64);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;

            graphics.DrawString(c.ToString(), font, Brushes.Black, new Rectangle(0, 0, 64, 64),stringFormat);
            Type = "text";
            GetBoxs();



        }

        public GCImage(Image image)
        {
            bitmap = new Bitmap(image);
            Type = "bitmap";
            GetBoxs();
        }

        public void GetBoxs()
        {
            int minx = 64;
            int miny = 64;

            Dictionary<int, List<int>> colorBoxsPairs = new Dictionary<int, List<int>>();

            Color[,] pix = new Color[bitmap.Height, bitmap.Width];

            for (int j = 0; j < bitmap.Height; j++)
                for (int k = 0; k < bitmap.Width; k++)
                    pix[j, k] = bitmap.GetPixel(k, j);

            for (int R = 0; R < bitmap.Height; R++)
            {
                for (int C = 0; C < bitmap.Width; C++)
                {
                    if (pix[R, C] != Color.Empty && pix[R, C].A != 0)
                    {
                        Color temp = pix[R, C];
                        int r = 0;
                        int c = 0;
                        while (R + r < bitmap.Height)
                        {
                            if (pix[R + r, C] != temp)
                                break;
                            r++;
                        }
                        while (C + c < bitmap.Width)
                        {
                            if (pix[R, C + c] != temp)
                                break;
                            c++;
                        }
                        int int_color = temp.R + temp.G * 256 + temp.B * 65536;

                        if (r > c)
                        {
                            for (int m = 0; m < r; m++)
                                pix[R + m, C] = Color.Empty;
                            if (!colorBoxsPairs.ContainsKey(int_color))
                                colorBoxsPairs.Add(int_color, new List<int>());
                            List<int> list = colorBoxsPairs[int_color];
                            if (Type == "text")
                            {
                                if (minx > C)
                                    minx = C;
                                if (miny > R)
                                    miny = R;
                            }
                            list.Add(C);
                            list.Add(R);
                            list.Add(1);
                            list.Add(r);
                        }
                        else
                        {
                            for (int m = 0; m < c; m++)
                                pix[R, C + m] = Color.Empty;
                            if (!colorBoxsPairs.ContainsKey(int_color))
                                colorBoxsPairs.Add(int_color, new List<int>());
                            List<int> list = colorBoxsPairs[int_color];
                            if (Type == "text")
                            {
                                if(minx > C)
                                    minx = C;
                                if (miny > R)
                                    miny = R;
                            }
                            list.Add(C);
                            list.Add(R);
                            list.Add(c);
                            list.Add(1);
                        }
                        boxCount++;
                    }
                }
            }

            Console.WriteLine(minx + "," + miny);

            StringBuilder builder = new StringBuilder(boxCount * 4);

            int bit;
            if (Type == "bitmap")
            {
                bit = 2;
            }
            else
            {
                bit = 1;
                foreach (var item in colorBoxsPairs.Values)
                {
                    for (int i = 0; i < item.Count; i+=4)
                    {
                        item[i] -= minx;
                        item[i+1] -= miny;
                    }
                }
            }

            foreach (var item in colorBoxsPairs)
            {
                if (Type == "bitmap")
                {
                    builder.Append(GCBase64.GetString(item.Key, 4));
                }
                foreach (var value in item.Value)
                {
                    builder.Append(GCBase64.GetString(value,bit));
                }
                builder.Append(" ");
            }
            builder.Remove(builder.Length - 1, 1);
            data = builder.ToString();
            Console.WriteLine(data);
        }
    }
}


