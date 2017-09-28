namespace CG_lab2
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonLoadImg = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.radioButtonImage = new System.Windows.Forms.RadioButton();
            this.radioButtonColor = new System.Windows.Forms.RadioButton();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 318);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // labelColor
            // 
            this.labelColor.BackColor = System.Drawing.Color.Black;
            this.labelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelColor.Location = new System.Drawing.Point(788, 32);
            this.labelColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(66, 61);
            this.labelColor.TabIndex = 1;
            this.labelColor.BackColorChanged += new System.EventHandler(this.labelColor_BackColorChanged);
            this.labelColor.Click += new System.EventHandler(this.labelColor_Click);
            // 
            // buttonLoadImg
            // 
            this.buttonLoadImg.Location = new System.Drawing.Point(671, 32);
            this.buttonLoadImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLoadImg.Name = "buttonLoadImg";
            this.buttonLoadImg.Size = new System.Drawing.Size(67, 54);
            this.buttonLoadImg.TabIndex = 2;
            this.buttonLoadImg.Text = "Load Image";
            this.buttonLoadImg.UseVisualStyleBackColor = true;
            this.buttonLoadImg.Click += new System.EventHandler(this.buttonLoadImg_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radioButtonImage
            // 
            this.radioButtonImage.AutoSize = true;
            this.radioButtonImage.Location = new System.Drawing.Point(671, 157);
            this.radioButtonImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonImage.Name = "radioButtonImage";
            this.radioButtonImage.Size = new System.Drawing.Size(67, 21);
            this.radioButtonImage.TabIndex = 3;
            this.radioButtonImage.Text = "Image";
            this.radioButtonImage.UseVisualStyleBackColor = true;
            // 
            // radioButtonColor
            // 
            this.radioButtonColor.AutoSize = true;
            this.radioButtonColor.Location = new System.Drawing.Point(788, 157);
            this.radioButtonColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonColor.Name = "radioButtonColor";
            this.radioButtonColor.Size = new System.Drawing.Size(62, 21);
            this.radioButtonColor.TabIndex = 4;
            this.radioButtonColor.Text = "Color";
            this.radioButtonColor.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(726, 232);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(65, 54);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(614, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Область рисуется левой кнопкой мыши, заливка осуществляется нажатием правой кнопк" +
    "и";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 363);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.radioButtonColor);
            this.Controls.Add(this.radioButtonImage);
            this.Controls.Add(this.buttonLoadImg);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filling";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonLoadImg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radioButtonImage;
        private System.Windows.Forms.RadioButton radioButtonColor;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label1;
    }
}

