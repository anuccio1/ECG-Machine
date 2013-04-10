namespace WindowsFormsApplication3
{
    partial class Database
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
            this.EnterName = new System.Windows.Forms.Label();
            this.SubmitName = new System.Windows.Forms.Button();
            this.NBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.HeartRate = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EnterName
            // 
            this.EnterName.AutoSize = true;
            this.EnterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterName.Location = new System.Drawing.Point(154, 9);
            this.EnterName.Name = "EnterName";
            this.EnterName.Size = new System.Drawing.Size(270, 25);
            this.EnterName.TabIndex = 0;
            this.EnterName.Text = "Please Enter Your Information";
            // 
            // SubmitName
            // 
            this.SubmitName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SubmitName.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitName.Location = new System.Drawing.Point(0, 202);
            this.SubmitName.Name = "SubmitName";
            this.SubmitName.Size = new System.Drawing.Size(563, 49);
            this.SubmitName.TabIndex = 1;
            this.SubmitName.Text = "Submit";
            this.SubmitName.UseVisualStyleBackColor = true;
            this.SubmitName.Click += new System.EventHandler(this.SubmitName_Click);
            // 
            // NBox
            // 
            this.NBox.Location = new System.Drawing.Point(168, 69);
            this.NBox.Name = "NBox";
            this.NBox.Size = new System.Drawing.Size(243, 20);
            this.NBox.TabIndex = 2;
            this.NBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(117, 68);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(45, 17);
            this.NameLabel.TabIndex = 3;
            this.NameLabel.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(168, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(243, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(124, 93);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(38, 17);
            this.DateLabel.TabIndex = 7;
            this.DateLabel.Text = "Date";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(123, 120);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(39, 17);
            this.TimeLabel.TabIndex = 8;
            this.TimeLabel.Text = "Time";
            // 
            // HeartRate
            // 
            this.HeartRate.AutoSize = true;
            this.HeartRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeartRate.Location = new System.Drawing.Point(85, 146);
            this.HeartRate.Name = "HeartRate";
            this.HeartRate.Size = new System.Drawing.Size(77, 17);
            this.HeartRate.TabIndex = 10;
            this.HeartRate.Text = "Heart Rate";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(168, 146);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(243, 20);
            this.textBox3.TabIndex = 9;
            // 
            // Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 251);
            this.Controls.Add(this.HeartRate);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NBox);
            this.Controls.Add(this.SubmitName);
            this.Controls.Add(this.EnterName);
            this.Name = "Database";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database";
            this.Load += new System.EventHandler(this.Database_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EnterName;
        private System.Windows.Forms.Button SubmitName;
        private System.Windows.Forms.TextBox NBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label HeartRate;
        private System.Windows.Forms.TextBox textBox3;
    }
}