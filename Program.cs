using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filters3
{
    static class Program
    {
        public static List<Convolution_Matrix> settings = new List<Convolution_Matrix>();
        public static Convolution_Matrix current = new Convolution_Matrix(3, 3, 1, 1, "basic");
        public static Convolution_Matrix current_gauss = new Convolution_Matrix(3, 3, 1, 1, "basic_gauss");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
