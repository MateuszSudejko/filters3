using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filters3
{
    public class Color_Cube
    {
        private List<Color> colors = new List<Color>();
        public int RMin;
        public int RMax;
        public int GMin;
        public int GMax;
        public int BMin;
        public int BMax;

        public Color_Cube(List<Color> colors)
        {
            this.colors = colors;

            RMin = colors.Min(c => c.R);
            RMax = colors.Max(c => c.R);
            GMin = colors.Min(c => c.G);
            GMax = colors.Max(c => c.G);
            BMin = colors.Min(c => c.B);
            BMax = colors.Max(c => c.B);
        }

        public int GetLongestDimension()
        {
            int rLength = RMax - RMin;
            int gLength = GMax - GMin;
            int bLength = BMax - BMin;

            if (rLength >= gLength && rLength >= bLength)
            {
                return 0;
            }
            else if (gLength >= rLength && gLength >= bLength)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public List<Color_Cube> Split()
        {
            int longestDimension = GetLongestDimension();

            if (longestDimension == 0)
            {
                colors.Sort((a, b) => a.R.CompareTo(b.R));
            }
            else if (longestDimension == 1)
            {
                colors.Sort((a, b) => a.G.CompareTo(b.G));
            }
            else
            {
                colors.Sort((a, b) => a.B.CompareTo(b.B));
            }

            int medianIndex = colors.Count / 2;

            List<Color> leftColors = colors.GetRange(0, medianIndex);
            List<Color> rightColors = colors.GetRange(medianIndex, colors.Count - medianIndex);

            Color_Cube leftCube = new Color_Cube(leftColors);
            Color_Cube rightCube = new Color_Cube(rightColors);

            return new List<Color_Cube>() { leftCube, rightCube };
        }

        public static List<Color> GetColorsFromImage(Bitmap image)
        {
            List<Color> colors = new List<Color>();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = Color.FromArgb(image.GetPixel(x, y).R, image.GetPixel(x, y).G, image.GetPixel(x, y).B);
                    colors.Add(pixelColor);
                }
            }
            return colors;
        }

        public static List<Color> MedianCut(Bitmap image, int numColors)
        {
            List<Color> colors = GetColorsFromImage(image);

            Color_Cube rootCube = new Color_Cube(colors);

            Queue<Color_Cube> cubes = new Queue<Color_Cube>();
            cubes.Enqueue(rootCube);

            while (cubes.Count < numColors)
            {
                Color_Cube cube = cubes.Dequeue();

                if (cube.colors.Count > 1)
                {
                    List<Color_Cube> splitCubes = cube.Split();
                    cubes.Enqueue(splitCubes[0]);
                    cubes.Enqueue(splitCubes[1]);
                }
                else
                {
                    cubes.Enqueue(cube);
                }
            }

            List<Color> resultColors = new List<Color>();

            foreach (Color_Cube cube in cubes)
            {
                resultColors.Add(Color.FromArgb((cube.RMax + cube.RMin) / 2, (cube.GMax + cube.GMin) / 2, (cube.BMax + cube.BMin) / 2));
            }

            return resultColors;
        }

        public static Bitmap ConvertToReducedColors2(Bitmap image, int numColors) // not optimised
        {
            List<Color> colors = MedianCut(image, numColors);

            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = Color.FromArgb(image.GetPixel(x, y).R, image.GetPixel(x, y).G, image.GetPixel(x, y).B);

                    int closestColorIndex = 0;
                    int closestColorDistance = int.MaxValue;

                    for (int i = 0; i < colors.Count; i++)
                    {
                        int colorDistance = GetColorDistancesqr(pixelColor, colors[i]);

                        if (colorDistance < closestColorDistance)
                        {
                            closestColorIndex = i;
                            closestColorDistance = colorDistance;
                        }
                    }

                    Color resultColor = colors[closestColorIndex];

                    resultImage.SetPixel(x, y, Color.FromArgb(resultColor.R, resultColor.G, resultColor.B));
                }
            }

            return resultImage;
        }

        public static Bitmap ConvertToReducedColors(Bitmap image, int numColors) // optimised
        {
            List<Color> colors = MedianCut(image, numColors);

            Bitmap resultImage = (Bitmap)image.Clone();

            int width = image.Width;
            int height = image.Height;

            Color[,] result = new Color[image.Width, image.Height];

            BitmapData pbits = resultImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int bytes = pbits.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

            int rgb;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    rgb = j * pbits.Stride + 3 * i;

                    Color pixelColor = Color.FromArgb(rgbValues[rgb + 2], rgbValues[rgb + 1], rgbValues[rgb + 0]);

                    int closestColorIndex = 0;
                    int closestColorDistance = int.MaxValue;

                    for (int k = 0; k < colors.Count; k++)
                    {
                        int colorDistance = GetColorDistancesqr(pixelColor, colors[k]);

                        if (colorDistance < closestColorDistance)
                        {
                            closestColorIndex = k;
                            closestColorDistance = colorDistance;
                        }
                    }

                    result[i, j] = colors[closestColorIndex];
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
            resultImage.UnlockBits(pbits);

            return resultImage;
        }

        public static int GetColorDistancesqr(Color a, Color b)
        {
            return (a.R - b.R)* (a.R - b.R) + (a.G - b.G)* (a.G - b.G) + (a.B - b.B)* (a.B - b.B);
        }

    }
}
