using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filters3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;*.png)|*.jpg;*.jpeg;.*.gif;*.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
                pictureBox2.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureBox2.Width);
                int height = Convert.ToInt32(pictureBox2.Height);
                using (Bitmap bmp = new Bitmap(width, height))
                {
                    pictureBox2.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                    bmp.Save(dialog.FileName, ImageFormat.Png);
                }
            }
        }

        private Bitmap invert(Bitmap Image)
        {
            Bitmap inverted = (Bitmap)Image.Clone();
            for (int y = 0; (y <= (inverted.Height - 1)); y++)
            {
                for (int x = 0; (x <= (inverted.Width - 1)); x++)
                {
                    Color inv = inverted.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    inverted.SetPixel(x, y, inv);
                }
            }
            return inverted;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap pic = new Bitmap(pictureBox2.Image);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }
            pictureBox2.Image = pic;
        }

        private static float clamp(float value, float min, float max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            return value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap adjustedImage = (Bitmap)pictureBox2.Image.Clone();
            float contrast = (float)Contrast.Value;
            for (int i = 0; i < adjustedImage.Width;i++)
            {
                for(int j = 0; j < adjustedImage.Height; j++)
                {
                    Color color = adjustedImage.GetPixel(i, j);
                    Color colornew = Color.FromArgb((byte)clamp(color.R * contrast, 0, 255), (byte)clamp(color.G * contrast, 0, 255), (byte)clamp(color.B * contrast, 0, 255));
                    adjustedImage.SetPixel(i, j, colornew);
                }
            }
            pictureBox2.Image = adjustedImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap adjustedImage = (Bitmap)pictureBox2.Image.Clone();
            float gamma = (float)Gamma.Value;
            for (int i = 0; i < adjustedImage.Width; i++)
            {
                for (int j = 0; j < adjustedImage.Height; j++)
                {
                    Color color = adjustedImage.GetPixel(i, j);
                    Color colornew = Color.FromArgb((byte)clamp((float)Math.Pow(color.R/255.0f,gamma)*255, 0, 255), (byte)clamp((float)Math.Pow(color.G/255.0f,gamma)*255, 0, 255), (byte)clamp((float)Math.Pow(color.B/255.0f,gamma)*255, 0, 255));
                    adjustedImage.SetPixel(i, j, colornew);
                }
            }
            pictureBox2.Image = adjustedImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap adjustedImage = (Bitmap)pictureBox2.Image.Clone();
            float brightness = (float)Brightness.Value;
            for (int i = 0; i < adjustedImage.Width; i++)
            {
                for (int j = 0; j < adjustedImage.Height; j++)
                {
                    Color color = adjustedImage.GetPixel(i, j);
                    Color colornew = Color.FromArgb((byte)clamp(color.R + brightness, 0, 255), (byte)clamp(color.G + brightness, 0, 255), (byte)clamp(color.B + brightness, 0, 255));
                    adjustedImage.SetPixel(i, j, colornew);
                }
            }
            pictureBox2.Image = adjustedImage;
        }

        private Bitmap lockb(Bitmap aimage)
        {
            Bitmap b = new Bitmap(aimage);

            BitmapData bData = b.LockBits(new Rectangle(0, 0, aimage.Width, aimage.Height), ImageLockMode.ReadWrite, b.PixelFormat);

            int size = bData.Stride * bData.Height;

            byte[] data = new byte[size];

            System.Runtime.InteropServices.Marshal.Copy(bData.Scan0, data, 0, size);

            System.Runtime.InteropServices.Marshal.Copy(data, 0, bData.Scan0, data.Length);

            b.UnlockBits(bData);

            return b;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = (Bitmap)Blur2((Bitmap)pictureBox2.Image);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = (Bitmap)GaussianBlur((Bitmap)pictureBox2.Image);
        }

        public static Bitmap Sharpen(Bitmap image)
        {
            Bitmap sharpenImage = (Bitmap)image.Clone();

            int filterWidth = 3;
            int filterHeight = 3;
            int width = image.Width;
            int height = image.Height;

            double[,] filter = new double[filterWidth, filterHeight];
            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;

            double factor = 1.0;
            double bias = 0.0;

            Color[,] result = new Color[image.Width, image.Height];

            BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (i - filterWidth / 2 + filterX + width) % width;
                            int imageY = (j - filterHeight / 2 + filterY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red += rgbValues[rgb + 2] * filter[filterX, filterY];
                            green += rgbValues[rgb + 1] * filter[filterX, filterY];
                            blue += rgbValues[rgb + 0] * filter[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            sharpenImage.UnlockBits(pbits);

            return sharpenImage;
        }

        public static Bitmap Blur(Bitmap image, int filterWidth, int filterHeight)
        {
            Bitmap blurredImage = (Bitmap)image.Clone();

            int width = image.Width;
            int height = image.Height;

            double[,] filter = new double[filterWidth, filterHeight];
            for(int k = 0; k < filterWidth; k++)
            {
                for (int l= 0;l< filterHeight; l++)
                {
                    filter[k, l] = 0.1;
                }
            }
            filter[1, 1] = 0.2;
           

            Color[,] result = new Color[image.Width, image.Height];

            BitmapData pbits = blurredImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (i - filterWidth / 2 + filterX + width) % width;
                            int imageY = (j - filterHeight / 2 + filterY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red += rgbValues[rgb + 2] * filter[filterX, filterY];
                            green += rgbValues[rgb + 1] * filter[filterX, filterY];
                            blue += rgbValues[rgb + 0] * filter[filterX, filterY];
                        }
                        int r = (int)clamp((int)red, 0, 255);
                        int g = (int)clamp((int)green, 0, 255);
                        int b = (int)clamp((int)blue, 0, 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            blurredImage.UnlockBits(pbits);

            return blurredImage;
        }

        public static Bitmap Blur2(Bitmap image)
        {
            Bitmap blurredImage = (Bitmap)image.Clone();

            int width = image.Width;
            int height = image.Height;

            int filterWidth = Program.current.width;
            int filterHeight = Program.current.height;

            double[,] filter = Program.current.coefficients;

            int anchor_x = Program.current.anchor_x;
            int anchor_y = Program.current.anchor_y;

            Color[,] result = new Color[image.Width, image.Height];

            BitmapData pbits = blurredImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (i - filterWidth + anchor_x + filterX + width) % width;
                            int imageY = (j - filterHeight + anchor_y + filterY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red += rgbValues[rgb + 2] * filter[filterX, filterY];
                            green += rgbValues[rgb + 1] * filter[filterX, filterY];
                            blue += rgbValues[rgb + 0] * filter[filterX, filterY];
                        }
                        int r = (int)clamp((int)red, 0, 255);
                        int g = (int)clamp((int)green, 0, 255);
                        int b = (int)clamp((int)blue, 0, 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            blurredImage.UnlockBits(pbits);

            return blurredImage;
        }

        public static Bitmap GaussianBlur(Bitmap image)
        {
            Bitmap blurredImage = (Bitmap)image.Clone();

            int width = image.Width;
            int height = image.Height;

            int filterWidth = Program.current_gauss.width;
            int filterHeight = Program.current_gauss.height;

            double[,] filter = Program.current_gauss.coefficients;

            int anchor_x = Program.current_gauss.anchor_x;
            int anchor_y = Program.current_gauss.anchor_y;

            Color[,] result = new Color[image.Width, image.Height];

            BitmapData pbits = blurredImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (i - filterWidth + anchor_x + filterX + width) % width;
                            int imageY = (j - filterHeight + anchor_y + filterY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red += rgbValues[rgb + 2] * filter[filterX, filterY];
                            green += rgbValues[rgb + 1] * filter[filterX, filterY];
                            blue += rgbValues[rgb + 0] * filter[filterX, filterY];
                        }
                        int r = (int)clamp((int)red, 0, 255);
                        int g = (int)clamp((int)green, 0, 255);
                        int b = (int)clamp((int)blue, 0, 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            blurredImage.UnlockBits(pbits);

            return blurredImage;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Sharpen((Bitmap)pictureBox2.Image);
        }

        private Bitmap greyscale(Bitmap Image)
        {
            Bitmap c = Image;
            int x, y;

            for (x = 0; x < c.Width; x++)
            {
                for (y = 0; y < c.Height; y++)
                {
                    Color pixelColor = c.GetPixel(x, y);
                    int avg = (pixelColor.R + pixelColor.G + pixelColor.B)/ 3;
                    Color newColor = Color.FromArgb(avg, avg, avg);
                    c.SetPixel(x, y, newColor);
                }
            }
            return c;
        }

        private Bitmap edgedetection(Bitmap Image, int thresh)
        {
            Bitmap tmp = GaussianBlur(Image);
            tmp = greyscale(tmp);
            Bitmap edges = (Bitmap)tmp.Clone();
            float[][] sobelX =
            {
                new float[] {-1,-2,-1 },
                new float[] {0,0,0},
                new float[] {1,2,1}
            };
            float[][] sobelY =
            {
                new float[] {-1,0,1},
                new float[] {-2,0,2},
                new float[] {-1,0,1}
            };
            BitmapData pbits = edges.LockBits(new Rectangle(0, 0, edges.Width, edges.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * edges.Height;
            byte[] hueValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, hueValues, 0, bytes);
            Color[,] resultX = new Color[edges.Width, edges.Height];
            Color[,] resultY = new Color[edges.Width, edges.Height];
            int rgb;
            for (int i = 0; i < edges.Width; i++)
            {
                for(int j = 0; j < edges.Height; j++)
                {
                    float redX = 0;
                    float redY = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            int imageX = (i - 3 / 2 + 3 + 3) % 3;
                            int imageY = (j - 3 / 2 + 3 + 3) % 3;

                            rgb = imageY * pbits.Stride + 3 * imageX;
                            redX += sobelX[k][l] * hueValues[rgb + 2];
                            redY += sobelY[k][l] * hueValues[rgb + 2];
                        }
                        
                    }
                    int rX = (int)clamp((int)redX, 0, 255);
                    int rY = (int)clamp((int)redY, 0, 255);
                    resultX[i,j] = Color.FromArgb(rX, 0, 0);
                    resultY[i,j] = Color.FromArgb(rY, 0, 0);
                }
            }

            for (int x = 0; x < edges.Width; x++)
            {
                for (int y = 0; y < edges.Height; y++)
                {
                    rgb = y * pbits.Stride + 3 * x;
                    
                    if(Math.Sqrt(Math.Pow(resultX[x, y].R, 2) + Math.Pow(resultY[x, y].R, 2)) > thresh)
                    {
                        hueValues[rgb + 2] = 255;
                        hueValues[rgb + 1] = 255;
                        hueValues[rgb] = 255;
                    }
                    else
                    {
                        hueValues[rgb + 2] = 0;
                        hueValues[rgb + 1] = 0;
                        hueValues[rgb] = 0;
                    }
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(hueValues, 0, pbits.Scan0, bytes);
            edges.UnlockBits(pbits);

            return edges;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = edgedetection2((Bitmap)pictureBox2.Image);
        }

        private Bitmap edgedetection2(Bitmap Image)
        {
            Bitmap tmp = GaussianBlur(Image);
            tmp = greyscale(tmp);
            float[][] filterX =
            {
                new float[] {0,-1,0 },
                new float[] {0,1,0},
                new float[] {0,0,0}
            };
            float[][] filterY =
            {
                new float[] {0,0,0},
                new float[] {-1,1,0},
                new float[] {0,0,0}
            };
            float[][] filterD =
            {
                new float[] {-1,0,0},
                new float[] {0,1,0},
                new float[] {0,0,0}
            };
            Bitmap edges = (Bitmap)Image.Clone();

            int width = Image.Width;
            int height = Image.Height;

            Color[,] result = new Color[Image.Width, Image.Height];

            BitmapData pbits = edges.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int fX = 0; fX < 3; fX++)
                    {
                        for (int fY = 0; fY < 3; fY++)
                        {
                            int imageX = (i - 3 / 2 + fX + width) % width;
                            int imageY = (j - 3 / 2 + fY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red += rgbValues[rgb + 2] * filterD[fX][fY];
                            green += rgbValues[rgb + 1] * filterD[fX][fY];
                            blue += rgbValues[rgb + 0] * filterD[fX][fY];
                        }
                        int r = (int)clamp((int)red, 0, 255);
                        int g = (int)clamp((int)green, 0, 255);
                        int b = (int)clamp((int)blue, 0, 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            edges.UnlockBits(pbits);

            return edges;
        }

        private Bitmap emboss(Bitmap Image)
        {
            Bitmap embossed = (Bitmap)Image.Clone();

            int width = Image.Width;
            int height = Image.Height;

            float[][] filter =
            {
                new float[] {1,1,0},
                new float[] {1,1,-1},
                new float[] {0,-1,-1}
            };

            Color[,] result = new Color[Image.Width, Image.Height];

            BitmapData pbits = embossed.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < 3; filterX++)
                    {
                        for (int filterY = 0; filterY < 3; filterY++)
                        {
                            int imageX = (i - 3 / 2 + filterX + width) % width;
                            int imageY = (j - 3 / 2 + filterY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red += rgbValues[rgb + 2] * filter[filterX][filterY];
                            green += rgbValues[rgb + 1] * filter[filterX][filterY];
                            blue += rgbValues[rgb + 0] * filter[filterX][filterY];
                        }
                        int r = (int)clamp((int)red, 0, 255);
                        int g = (int)clamp((int)green, 0, 255);
                        int b = (int)clamp((int)blue, 0, 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            embossed.UnlockBits(pbits);

            return embossed;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = emboss((Bitmap)pictureBox2.Image);
        }

        private void goconv_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
        }

        private double median(double[] array, int size)
        {
            Array.Sort(array);
            return array[size / 2 - 1];
        }

        private Bitmap medianF(Bitmap Image)
        {
            Bitmap embossed = (Bitmap)Image.Clone();

            int width = Image.Width;
            int height = Image.Height;

            Color[,] result = new Color[Image.Width, Image.Height];

            BitmapData pbits = embossed.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double[] red = new double[9], green = new double[9], blue = new double[9];

                    for (int filterX = 0; filterX < 3; filterX++)
                    {
                        for (int filterY = 0; filterY < 3; filterY++)
                        {
                            int imageX = (i - 3 / 2 + filterX + width) % width;
                            int imageY = (j - 3 / 2 + filterY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red[filterX * 3 + filterY] = rgbValues[rgb + 2];
                            green[filterX * 3 + filterY] = rgbValues[rgb + 1];
                            blue[filterX * 3 + filterY] = rgbValues[rgb + 0];
                        }
                        int r = (int)clamp((int)median(red,9), 0, 255);
                        int g = (int)clamp((int)median(green,9), 0, 255);
                        int b = (int)clamp((int)median(blue, 9), 0, 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            embossed.UnlockBits(pbits);

            return embossed;
        }

        private void median_filter_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = medianF((Bitmap)pictureBox2.Image);
        }

        private Bitmap pixelate(Bitmap image)
        {
            Bitmap pixelated = (Bitmap)image.Clone();
            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 16; j++)
                {
                    int sumaR = 0, sumaG = 0, sumaB = 0, ile=0;
                    int pixelW = j * image.Width / 16;
                    int pixelH = i * image.Height / 16;
                    for(int imageX = pixelH; imageX<=pixelH + image.Height / 16; imageX++)
                    {
                        for (int imageY = pixelW; imageY <= pixelW + image.Width / 16; imageY++)
                        {
                            Color curr = image.GetPixel(imageX, imageY);
                            sumaR += curr.R;
                            sumaG += curr.G;
                            sumaB += curr.B;
                            ile++;
                        }
                    }
                    Color kolorek = Color.FromArgb(255, sumaR / ile, sumaG / ile, sumaB / ile);
                    for (int imageX = pixelH; imageX <= pixelH + image.Height / 16; imageX++)
                    {
                        for (int imageY = pixelW; imageY <= pixelW + image.Width / 16; imageY++)
                        {
                            pixelated.SetPixel(imageX, imageY, kolorek);
                        }
                    }
                }
            }
            return pixelated;
        }

        private void pixelate_button_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pixelate((Bitmap)pictureBox2.Image);
        }

        private void grayscale_button_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = greyscale((Bitmap)pictureBox2.Image);
        }

        private Bitmap dither(Bitmap Image)
        {
            Bitmap dithered = (Bitmap)Image.Clone();
            dithered = greyscale((Bitmap)dithered);

            int width = Image.Width;
            int height = Image.Height;

            Color[,] result = new Color[Image.Width, Image.Height];

            BitmapData pbits = dithered.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);
            double sum = 0;
            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    rgb = j * pbits.Stride + 3 * i;
                    sum += rgbValues[rgb];
                }
            }

            double avg = sum / (width * height);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    rgb = j * pbits.Stride + 3 * i;
                    if (rgbValues[rgb] > avg)
                    {
                        int r = 255;
                        int g = 255;
                        int b = 255;
                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                    else
                    {
                        int r = 0;
                        int g = 0;
                        int b = 0;
                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            dithered.UnlockBits(pbits);

            return dithered;
        }

        private void dithering_button_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = dither((Bitmap)pictureBox2.Image);
        }

        private void color_quantization_button_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Color_Cube.ConvertToReducedColors((Bitmap)pictureBox2.Image, (int)color_count.Value);
        }

        private Bitmap convToYCbCr2(Bitmap Image)
        {
            Bitmap embossed = (Bitmap)Image.Clone();

            int width = Image.Width;
            int height = Image.Height;

            float[][] filter =
            {
                new float[] {1,1,0},
                new float[] {1,1,-1},
                new float[] {0,-1,-1}
            };

            Color[,] result = new Color[Image.Width, Image.Height];

            BitmapData pbits = embossed.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;

                    for (int filterX = 0; filterX < 3; filterX++)
                    {
                        for (int filterY = 0; filterY < 3; filterY++)
                        {
                            int imageX = (i - 3 / 2 + filterX + width) % width;
                            int imageY = (j - 3 / 2 + filterY + height) % height;

                            rgb = imageY * pbits.Stride + 3 * imageX;

                            red += rgbValues[rgb + 2] * filter[filterX][filterY];
                            green += rgbValues[rgb + 1] * filter[filterX][filterY];
                            blue += rgbValues[rgb + 0] * filter[filterX][filterY];
                        }
                        int r = (int)clamp((int)red, 0, 255);
                        int g = (int)clamp((int)green, 0, 255);
                        int b = (int)clamp((int)blue, 0, 255);

                        result[i, j] = Color.FromArgb(r, g, b);
                    }
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            embossed.UnlockBits(pbits);

            return embossed;
        }

        private Bitmap convToYCbCr(Bitmap Image)
        {
            Bitmap converted = (Bitmap)Image.Clone();

            int width = Image.Width;
            int height = Image.Height;

            Color[,] result = new Color[Image.Width, Image.Height];

            BitmapData pbits = converted.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    rgb = j * pbits.Stride + 3 * i;
                    int red = rgbValues[rgb + 2];
                    int green = rgbValues[rgb + 1];
                    int blue = rgbValues[rgb + 0];

                    double y = 0.299 * red + 0.587 * green + 0.114 * blue;
                    double cb = 128 - 0.168736 * red - 0.331264 * green + 0.5 * blue;
                    double cr = 128 + 0.5 * red - 0.418688 * green - 0.081312 * blue;

                    //double y = 16 + (65.738*red)/256 + (129.057*green)/256 + (25.064*blue)/256;
                    //double cb = 128 - (37.945*red)/256 - (74.494*green)/256 + (112.439*blue)/256;
                    //double cr = 128 + (112.439*red)/256 -(94.154*green)/256 - (18.285*blue)/256;

            result[i, j] = Color.FromArgb(Math.Max(0, Math.Min((int)y, 255)), Math.Max(0, Math.Min((int)cb, 255)), Math.Max(0, Math.Min((int)cr, 255)));
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            converted.UnlockBits(pbits);

            return converted;
        }

        private Bitmap convToRGB(Bitmap Image)
        {
            Bitmap converted = (Bitmap)Image.Clone();
            converted = greyscale((Bitmap)converted);

            int width = Image.Width;
            int height = Image.Height;

            Color[,] result = new Color[Image.Width, Image.Height];

            BitmapData pbits = converted.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);
            int rgb;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    rgb = j * pbits.Stride + 3 * i;
                    int y = rgbValues[rgb + 2];
                    int cb = rgbValues[rgb + 1];
                    int cr = rgbValues[rgb + 0];

                    double red = y + 1.402 * Math.Max(0,Math.Max(255,cr-128));
                    double green = y - 0.344136 * Math.Max(0, Math.Min(255, cb - 128)) - 0.714136 * Math.Max(0, Math.Min(255, cr - 128));
                    double blue = y + 1.772 * Math.Max(0, Math.Min(255, cb - 128));

                    //double red = (298.082 * y) / 256 + (408.583 * cr) / 256 - 222.921;
                    //double green = (298.082 * y) / 256 - (100.291 * cb) / 256 - (208.120 * cr) / 256 + 135.576;
                    //double blue = (298.082 * y) / 256 + (516.412 * cb) / 256 - 276.836;

                    result[i, j] = Color.FromArgb(Math.Max(0,Math.Min((int)red,255)), Math.Max(0, Math.Min((int)green, 255)), Math.Max(0, Math.Min((int)blue, 255)));
                }
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    rgb = y * pbits.Stride + 3 * x;

                    rgbValues[rgb + 2] = result[x, y].R;
                    rgbValues[rgb + 1] = result[x, y].G;
                    rgbValues[rgb + 0] = result[x, y].B;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
            converted.UnlockBits(pbits);

            return converted;
        }

        private void convertToRGBBBBB_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = convToRGB((Bitmap)pictureBox2.Image);
        }

        private void convertToYCBCR_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = convToYCbCr((Bitmap)pictureBox2.Image);
        }
    }
}
