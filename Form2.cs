using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace filters3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void adjust_button_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 0;
            dataGridView1.RowCount = 0;

            int width = (int)conv_matrix_width.Value;
            int height = (int)conv_matrix_height.Value;

            dataGridView1.ColumnCount = (int)conv_matrix_width.Value;

            for (int i = 0; i < height; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                for (int j = width; j < width; j++)
                {
                    row.Cells[j].Value = "0";
                }
                this.dataGridView1.Rows.Add(row);
            }
        }

        private void coefs_button_Click(object sender, EventArgs e)
        {
            int width = dataGridView1.ColumnCount;
            int height = dataGridView1.RowCount;
            Convolution_Matrix matrix = new Convolution_Matrix(width, height, (int)conv_anchor_x.Value-1, (int)conv_anchor_y.Value-1, conv_matrix_name.Text);
            if (adjust_coefs_values.Checked)
            {
                double suma = 0;
                for (int i = 0; i < height; i++)
                {
                    var row = dataGridView1.Rows[i];
                    for (int j = 0; j < width; j++)
                    {
                        var cell = row.Cells[j];
                        suma += Convert.ToDouble(cell.Value.ToString());
                    }
                }
                for (int i = 0; i < height; i++)
                {
                    var row = dataGridView1.Rows[i];
                    for (int j = 0; j < width; j++)
                    {
                        var cell = row.Cells[j];
                        matrix.coefficients[i, j] = Convert.ToDouble(cell.Value.ToString()) /suma;
                    }
                }
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        matrix.coefficients[i, j] = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    }
                }
            }
            Program.settings.Add(matrix);
            Program.current = matrix;
            string nameID = matrix.matrixID.ToString() + " " + matrix.name;
            Chosen_kernel.Items.Add(nameID);
            string message = "Kernel has been set successfully";
            MessageBox.Show(message);
        }

        private double gaussian_func(double sd, int x, int y)
        {
            return Math.Exp(-(Math.Pow(x, 2) + Math.Pow(y, 2)) / (2 * Math.Pow(sd, 2))) / (2 * Math.PI * Math.Pow(sd, 2));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int size = ((int)GBsize.Value-1)/2;

            gaussianBlurKernel.ColumnCount = 0;
            gaussianBlurKernel.RowCount = 0;

            gaussianBlurKernel.ColumnCount = (int)GBsize.Value;

            double suma = 0;

            for(int i = -size; i <= size; i++)
            {
                for (int j = -size; j <= size; j++)
                {
                    suma += gaussian_func((double)standardDevGauss.Value, i, j);
                }
            }

            for (int i = -size; i <= size; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.gaussianBlurKernel);
                for (int j = -size; j <= size; j++)
                {
                    row.Cells[j+size].Value = Math.Round(gaussian_func((double)standardDevGauss.Value, i, j) / suma, 4);
                }
                this.gaussianBlurKernel.Rows.Add(row);
            }
        }

        private void set_gauss_kernel_Click(object sender, EventArgs e)
        {
            int width = (int)GBsize.Value;
            int height = (int)GBsize.Value;
            Convolution_Matrix matrix = new Convolution_Matrix(width, height, (int)conv_anchor_x.Value - 1, (int)conv_anchor_y.Value - 1, gauss_matrix_name.Text);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix.coefficients[i, j] = Convert.ToDouble(gaussianBlurKernel.Rows[i].Cells[j].Value.ToString());
                }
            }
            Program.settings.Add(matrix);
            Program.current_gauss = matrix;
            string nameID = matrix.matrixID.ToString() + " " + matrix.name;
            Chosen_kernel.Items.Add(nameID);
            string message = "Kernel has been set successfully";
            MessageBox.Show(message);
        }

        private void upload_kernel_Click(object sender, EventArgs e)
        {
            if (Chosen_kernel.Items.Count == 0)
            {
                string message = "No kernel has been chosen";
                MessageBox.Show(message);
            }
            else
            {
                string matrixID = Chosen_kernel.SelectedItem.ToString().Split(' ')[0];
                Convolution_Matrix matrix = Program.settings.Find(x => x.matrixID.ToString() == matrixID);

                int width = matrix.width;
                int height = matrix.height;

                dataGridView1.RowCount = 0;
                dataGridView1.ColumnCount = width;

                for (int i = 0; i < height; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridView1);
                    for (int j = 0; j < width; j++)
                    {
                        row.Cells[j].Value = matrix.coefficients[i, j];
                    }
                    this.dataGridView1.Rows.Add(row);
                }
            }
        }
    }
}
