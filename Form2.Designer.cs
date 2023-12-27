
namespace filters3
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.conv_matrix_width = new System.Windows.Forms.NumericUpDown();
            this.conv_matrix_height = new System.Windows.Forms.NumericUpDown();
            this.conv_anchor_x = new System.Windows.Forms.NumericUpDown();
            this.conv_anchor_y = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.adjust_button = new System.Windows.Forms.Button();
            this.coefs_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GBsize = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.gaussianBlurKernel = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.standardDevGauss = new System.Windows.Forms.NumericUpDown();
            this.set_gauss_kernel = new System.Windows.Forms.Button();
            this.gauss_matrix_name = new System.Windows.Forms.TextBox();
            this.conv_matrix_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Chosen_kernel = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.upload_kernel = new System.Windows.Forms.Button();
            this.adjust_coefs_values = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_matrix_width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_matrix_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_anchor_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_anchor_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBsize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussianBlurKernel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardDevGauss)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 227);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(1, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(290, 267);
            this.dataGridView1.TabIndex = 0;
            // 
            // conv_matrix_width
            // 
            this.conv_matrix_width.Location = new System.Drawing.Point(48, 95);
            this.conv_matrix_width.Name = "conv_matrix_width";
            this.conv_matrix_width.Size = new System.Drawing.Size(105, 22);
            this.conv_matrix_width.TabIndex = 1;
            this.conv_matrix_width.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // conv_matrix_height
            // 
            this.conv_matrix_height.Location = new System.Drawing.Point(179, 94);
            this.conv_matrix_height.Name = "conv_matrix_height";
            this.conv_matrix_height.Size = new System.Drawing.Size(107, 22);
            this.conv_matrix_height.TabIndex = 2;
            this.conv_matrix_height.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // conv_anchor_x
            // 
            this.conv_anchor_x.Location = new System.Drawing.Point(48, 154);
            this.conv_anchor_x.Name = "conv_anchor_x";
            this.conv_anchor_x.Size = new System.Drawing.Size(105, 22);
            this.conv_anchor_x.TabIndex = 3;
            this.conv_anchor_x.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // conv_anchor_y
            // 
            this.conv_anchor_y.Location = new System.Drawing.Point(179, 154);
            this.conv_anchor_y.Name = "conv_anchor_y";
            this.conv_anchor_y.Size = new System.Drawing.Size(107, 22);
            this.conv_anchor_y.TabIndex = 4;
            this.conv_anchor_y.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(207, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Anchor point x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Anchor point y";
            // 
            // adjust_button
            // 
            this.adjust_button.Location = new System.Drawing.Point(113, 182);
            this.adjust_button.Name = "adjust_button";
            this.adjust_button.Size = new System.Drawing.Size(103, 39);
            this.adjust_button.TabIndex = 9;
            this.adjust_button.Text = "Adjust size";
            this.adjust_button.UseVisualStyleBackColor = true;
            this.adjust_button.Click += new System.EventHandler(this.adjust_button_Click);
            // 
            // coefs_button
            // 
            this.coefs_button.Location = new System.Drawing.Point(190, 517);
            this.coefs_button.Name = "coefs_button";
            this.coefs_button.Size = new System.Drawing.Size(122, 39);
            this.coefs_button.TabIndex = 10;
            this.coefs_button.Text = "Set new kernel";
            this.coefs_button.UseVisualStyleBackColor = true;
            this.coefs_button.Click += new System.EventHandler(this.coefs_button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Blur kernel matrix";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(776, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Gaussian Blur kernel matrix";
            // 
            // GBsize
            // 
            this.GBsize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GBsize.Location = new System.Drawing.Point(738, 95);
            this.GBsize.Maximum = new decimal(new int[] {
            101,
            0,
            0,
            0});
            this.GBsize.Name = "GBsize";
            this.GBsize.Size = new System.Drawing.Size(120, 22);
            this.GBsize.TabIndex = 14;
            this.GBsize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GBsize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(776, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Size";
            // 
            // gaussianBlurKernel
            // 
            this.gaussianBlurKernel.AllowUserToAddRows = false;
            this.gaussianBlurKernel.AllowUserToDeleteRows = false;
            this.gaussianBlurKernel.AllowUserToResizeColumns = false;
            this.gaussianBlurKernel.AllowUserToResizeRows = false;
            this.gaussianBlurKernel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gaussianBlurKernel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gaussianBlurKernel.Location = new System.Drawing.Point(717, 134);
            this.gaussianBlurKernel.Name = "gaussianBlurKernel";
            this.gaussianBlurKernel.ReadOnly = true;
            this.gaussianBlurKernel.RowHeadersWidth = 51;
            this.gaussianBlurKernel.RowTemplate.Height = 24;
            this.gaussianBlurKernel.Size = new System.Drawing.Size(307, 273);
            this.gaussianBlurKernel.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(885, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Standard deviation";
            // 
            // standardDevGauss
            // 
            this.standardDevGauss.Location = new System.Drawing.Point(888, 95);
            this.standardDevGauss.Name = "standardDevGauss";
            this.standardDevGauss.Size = new System.Drawing.Size(120, 22);
            this.standardDevGauss.TabIndex = 19;
            this.standardDevGauss.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // set_gauss_kernel
            // 
            this.set_gauss_kernel.Location = new System.Drawing.Point(873, 433);
            this.set_gauss_kernel.Name = "set_gauss_kernel";
            this.set_gauss_kernel.Size = new System.Drawing.Size(151, 35);
            this.set_gauss_kernel.TabIndex = 20;
            this.set_gauss_kernel.Text = "Set new kernel";
            this.set_gauss_kernel.UseVisualStyleBackColor = true;
            this.set_gauss_kernel.Click += new System.EventHandler(this.set_gauss_kernel_Click);
            // 
            // gauss_matrix_name
            // 
            this.gauss_matrix_name.Location = new System.Drawing.Point(717, 446);
            this.gauss_matrix_name.Name = "gauss_matrix_name";
            this.gauss_matrix_name.Size = new System.Drawing.Size(141, 22);
            this.gauss_matrix_name.TabIndex = 21;
            // 
            // conv_matrix_name
            // 
            this.conv_matrix_name.Location = new System.Drawing.Point(22, 534);
            this.conv_matrix_name.Name = "conv_matrix_name";
            this.conv_matrix_name.Size = new System.Drawing.Size(141, 22);
            this.conv_matrix_name.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(766, 426);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(77, 514);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Name";
            // 
            // Chosen_kernel
            // 
            this.Chosen_kernel.FormattingEnabled = true;
            this.Chosen_kernel.Location = new System.Drawing.Point(433, 94);
            this.Chosen_kernel.Name = "Chosen_kernel";
            this.Chosen_kernel.Size = new System.Drawing.Size(158, 24);
            this.Chosen_kernel.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(438, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "Choose a saved kernel";
            // 
            // upload_kernel
            // 
            this.upload_kernel.Location = new System.Drawing.Point(471, 124);
            this.upload_kernel.Name = "upload_kernel";
            this.upload_kernel.Size = new System.Drawing.Size(74, 27);
            this.upload_kernel.TabIndex = 27;
            this.upload_kernel.Text = "Upload";
            this.upload_kernel.UseVisualStyleBackColor = true;
            this.upload_kernel.Click += new System.EventHandler(this.upload_kernel_Click);
            // 
            // adjust_coefs_values
            // 
            this.adjust_coefs_values.AutoSize = true;
            this.adjust_coefs_values.Checked = true;
            this.adjust_coefs_values.CheckState = System.Windows.Forms.CheckState.Checked;
            this.adjust_coefs_values.Location = new System.Drawing.Point(22, 573);
            this.adjust_coefs_values.Name = "adjust_coefs_values";
            this.adjust_coefs_values.Size = new System.Drawing.Size(238, 21);
            this.adjust_coefs_values.TabIndex = 28;
            this.adjust_coefs_values.Text = "Adjust coefficients to sum up to 1";
            this.adjust_coefs_values.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 641);
            this.Controls.Add(this.adjust_coefs_values);
            this.Controls.Add(this.upload_kernel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Chosen_kernel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.conv_matrix_name);
            this.Controls.Add(this.gauss_matrix_name);
            this.Controls.Add(this.set_gauss_kernel);
            this.Controls.Add(this.standardDevGauss);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gaussianBlurKernel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.GBsize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.coefs_button);
            this.Controls.Add(this.adjust_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.conv_anchor_y);
            this.Controls.Add(this.conv_anchor_x);
            this.Controls.Add(this.conv_matrix_height);
            this.Controls.Add(this.conv_matrix_width);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_matrix_width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_matrix_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_anchor_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conv_anchor_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBsize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gaussianBlurKernel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardDevGauss)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown conv_matrix_width;
        private System.Windows.Forms.NumericUpDown conv_matrix_height;
        private System.Windows.Forms.NumericUpDown conv_anchor_x;
        private System.Windows.Forms.NumericUpDown conv_anchor_y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button adjust_button;
        private System.Windows.Forms.Button coefs_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown GBsize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView gaussianBlurKernel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown standardDevGauss;
        private System.Windows.Forms.Button set_gauss_kernel;
        private System.Windows.Forms.TextBox gauss_matrix_name;
        private System.Windows.Forms.TextBox conv_matrix_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Chosen_kernel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button upload_kernel;
        private System.Windows.Forms.CheckBox adjust_coefs_values;
    }
}