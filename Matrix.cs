using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace filters3
{
    public class Convolution_Matrix
    {
        static int nextId;
        public int matrixID { get; private set; }
        public string name;
        public int width = 0, height = 0;
        public int anchor_x = 0, anchor_y = 0;
        public double[,] coefficients;

        public Convolution_Matrix(int width, int height, int anchor_x, int anchor_y, string name)
        {
            this.matrixID = Interlocked.Increment(ref nextId);
            this.name = name;
            this.width = width;
            this.height = height;
            this.anchor_x = anchor_x;
            this.anchor_y = anchor_y;
            this.coefficients = new double[height, width];

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    this.coefficients[i,j] = 0.1;
                    if(i==1 && j==1) this.coefficients[i, j] = 0.2;
                }
            }
        }
    }
}
