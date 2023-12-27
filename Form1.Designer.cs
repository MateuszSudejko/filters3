
namespace filters3
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Contrast = new System.Windows.Forms.NumericUpDown();
            this.Brightness = new System.Windows.Forms.NumericUpDown();
            this.Gamma = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.goconv = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.median_filter = new System.Windows.Forms.Button();
            this.pixelate_button = new System.Windows.Forms.Button();
            this.grayscale_button = new System.Windows.Forms.Button();
            this.dithering_button = new System.Windows.Forms.Button();
            this.color_quantization_button = new System.Windows.Forms.Button();
            this.color_count = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.convertToRGBBBBB = new System.Windows.Forms.Button();
            this.convertToYCBCR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_count)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Upload photo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(29, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(538, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(868, 661);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1323, 694);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 36);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 311);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Invert";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(28, 385);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 36);
            this.button4.TabIndex = 5;
            this.button4.Text = "Adjust contrast";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Contrast
            // 
            this.Contrast.Location = new System.Drawing.Point(46, 357);
            this.Contrast.Name = "Contrast";
            this.Contrast.Size = new System.Drawing.Size(120, 22);
            this.Contrast.TabIndex = 12;
            this.Contrast.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Brightness
            // 
            this.Brightness.Location = new System.Drawing.Point(46, 427);
            this.Brightness.Name = "Brightness";
            this.Brightness.Size = new System.Drawing.Size(120, 22);
            this.Brightness.TabIndex = 13;
            // 
            // Gamma
            // 
            this.Gamma.Location = new System.Drawing.Point(46, 497);
            this.Gamma.Name = "Gamma";
            this.Gamma.Size = new System.Drawing.Size(120, 22);
            this.Gamma.TabIndex = 14;
            this.Gamma.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 525);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 36);
            this.button5.TabIndex = 15;
            this.button5.Text = "Adjust gamma";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(28, 455);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(152, 36);
            this.button6.TabIndex = 16;
            this.button6.Text = "Adjust brightness";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(185, 312);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(157, 29);
            this.button7.TabIndex = 17;
            this.button7.Text = "Blur";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(185, 351);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(158, 32);
            this.button8.TabIndex = 18;
            this.button8.Text = "Gaussian Blur";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(186, 392);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(157, 29);
            this.button9.TabIndex = 19;
            this.button9.Text = "Sharpen";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(185, 427);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(157, 28);
            this.button10.TabIndex = 20;
            this.button10.Text = "Edge Detection";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(186, 461);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(156, 29);
            this.button11.TabIndex = 21;
            this.button11.Text = "Emboss";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // goconv
            // 
            this.goconv.Location = new System.Drawing.Point(167, 577);
            this.goconv.Name = "goconv";
            this.goconv.Size = new System.Drawing.Size(187, 47);
            this.goconv.TabIndex = 22;
            this.goconv.Text = "Edit convolution filters";
            this.goconv.UseVisualStyleBackColor = true;
            this.goconv.Click += new System.EventHandler(this.goconv_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(186, 243);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(156, 36);
            this.reset.TabIndex = 23;
            this.reset.Text = "Reset changes";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // median_filter
            // 
            this.median_filter.Location = new System.Drawing.Point(186, 497);
            this.median_filter.Name = "median_filter";
            this.median_filter.Size = new System.Drawing.Size(156, 33);
            this.median_filter.TabIndex = 24;
            this.median_filter.Text = "Median filter";
            this.median_filter.UseVisualStyleBackColor = true;
            this.median_filter.Click += new System.EventHandler(this.median_filter_Click);
            // 
            // pixelate_button
            // 
            this.pixelate_button.Location = new System.Drawing.Point(187, 536);
            this.pixelate_button.Name = "pixelate_button";
            this.pixelate_button.Size = new System.Drawing.Size(156, 35);
            this.pixelate_button.TabIndex = 25;
            this.pixelate_button.Text = "Pixelate";
            this.pixelate_button.UseVisualStyleBackColor = true;
            this.pixelate_button.Click += new System.EventHandler(this.pixelate_button_Click);
            // 
            // grayscale_button
            // 
            this.grayscale_button.Location = new System.Drawing.Point(348, 311);
            this.grayscale_button.Name = "grayscale_button";
            this.grayscale_button.Size = new System.Drawing.Size(155, 34);
            this.grayscale_button.TabIndex = 26;
            this.grayscale_button.Text = "Grayscale";
            this.grayscale_button.UseVisualStyleBackColor = true;
            this.grayscale_button.Click += new System.EventHandler(this.grayscale_button_Click);
            // 
            // dithering_button
            // 
            this.dithering_button.Location = new System.Drawing.Point(348, 351);
            this.dithering_button.Name = "dithering_button";
            this.dithering_button.Size = new System.Drawing.Size(155, 32);
            this.dithering_button.TabIndex = 27;
            this.dithering_button.Text = "Dithering";
            this.dithering_button.UseVisualStyleBackColor = true;
            this.dithering_button.Click += new System.EventHandler(this.dithering_button_Click);
            // 
            // color_quantization_button
            // 
            this.color_quantization_button.Location = new System.Drawing.Point(350, 392);
            this.color_quantization_button.Name = "color_quantization_button";
            this.color_quantization_button.Size = new System.Drawing.Size(153, 29);
            this.color_quantization_button.TabIndex = 28;
            this.color_quantization_button.Text = "Color quantization";
            this.color_quantization_button.UseVisualStyleBackColor = true;
            this.color_quantization_button.Click += new System.EventHandler(this.color_quantization_button_Click);
            // 
            // color_count
            // 
            this.color_count.Location = new System.Drawing.Point(348, 455);
            this.color_count.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.color_count.Name = "color_count";
            this.color_count.Size = new System.Drawing.Size(153, 22);
            this.color_count.TabIndex = 29;
            this.color_count.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Colors";
            // 
            // convertToRGBBBBB
            // 
            this.convertToRGBBBBB.Location = new System.Drawing.Point(350, 497);
            this.convertToRGBBBBB.Name = "convertToRGBBBBB";
            this.convertToRGBBBBB.Size = new System.Drawing.Size(153, 33);
            this.convertToRGBBBBB.TabIndex = 34;
            this.convertToRGBBBBB.Text = "Convert to RGB";
            this.convertToRGBBBBB.UseVisualStyleBackColor = true;
            this.convertToRGBBBBB.Click += new System.EventHandler(this.convertToRGBBBBB_Click);
            // 
            // convertToYCBCR
            // 
            this.convertToYCBCR.Location = new System.Drawing.Point(350, 536);
            this.convertToYCBCR.Name = "convertToYCBCR";
            this.convertToYCBCR.Size = new System.Drawing.Size(151, 36);
            this.convertToYCBCR.TabIndex = 35;
            this.convertToYCBCR.Text = "Convert to YCbCr";
            this.convertToYCBCR.UseVisualStyleBackColor = true;
            this.convertToYCBCR.Click += new System.EventHandler(this.convertToYCBCR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 742);
            this.Controls.Add(this.convertToYCBCR);
            this.Controls.Add(this.convertToRGBBBBB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.color_count);
            this.Controls.Add(this.color_quantization_button);
            this.Controls.Add(this.dithering_button);
            this.Controls.Add(this.grayscale_button);
            this.Controls.Add(this.pixelate_button);
            this.Controls.Add(this.median_filter);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.goconv);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Gamma);
            this.Controls.Add(this.Brightness);
            this.Controls.Add(this.Contrast);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Filters";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown Contrast;
        private System.Windows.Forms.NumericUpDown Brightness;
        private System.Windows.Forms.NumericUpDown Gamma;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button goconv;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button median_filter;
        private System.Windows.Forms.Button pixelate_button;
        private System.Windows.Forms.Button grayscale_button;
        private System.Windows.Forms.Button dithering_button;
        private System.Windows.Forms.Button color_quantization_button;
        private System.Windows.Forms.NumericUpDown color_count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button convertToRGBBBBB;
        private System.Windows.Forms.Button convertToYCBCR;
    }
}

