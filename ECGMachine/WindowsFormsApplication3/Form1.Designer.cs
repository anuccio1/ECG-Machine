namespace WindowsFormsApplication3
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GainBox = new System.Windows.Forms.CheckBox();
            this.NotchBox = new System.Windows.Forms.CheckBox();
            this.Snapshot = new System.Windows.Forms.Button();
            this.fiveHP = new System.Windows.Forms.RadioButton();
            this.pointHP = new System.Windows.Forms.RadioButton();
            this.OverLoad = new System.Windows.Forms.TextBox();
            this.HeartRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.AutoScroll = true;
            this.zedGraphControl1.BackColor = System.Drawing.Color.Red;
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.zedGraphControl1.ForeColor = System.Drawing.Color.Black;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(975, 331);
            this.zedGraphControl1.TabIndex = 3;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(245, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 78);
            this.button1.TabIndex = 4;
            this.button1.Text = "Begin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GainBox
            // 
            this.GainBox.AutoSize = true;
            this.GainBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GainBox.Location = new System.Drawing.Point(486, 456);
            this.GainBox.Name = "GainBox";
            this.GainBox.Size = new System.Drawing.Size(57, 21);
            this.GainBox.TabIndex = 8;
            this.GainBox.Text = "Gain";
            this.GainBox.UseVisualStyleBackColor = true;
            this.GainBox.CheckedChanged += new System.EventHandler(this.GainBox_CheckedChanged);
            // 
            // NotchBox
            // 
            this.NotchBox.AutoSize = true;
            this.NotchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotchBox.Location = new System.Drawing.Point(486, 433);
            this.NotchBox.Name = "NotchBox";
            this.NotchBox.Size = new System.Drawing.Size(99, 21);
            this.NotchBox.TabIndex = 9;
            this.NotchBox.Text = "Notch Filter";
            this.NotchBox.UseVisualStyleBackColor = true;
            this.NotchBox.CheckedChanged += new System.EventHandler(this.NotchBox_CheckedChanged);
            // 
            // Snapshot
            // 
            this.Snapshot.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Snapshot.Location = new System.Drawing.Point(782, 416);
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.Size = new System.Drawing.Size(189, 65);
            this.Snapshot.TabIndex = 11;
            this.Snapshot.Text = "Take Snapshot";
            this.Snapshot.UseVisualStyleBackColor = true;
            this.Snapshot.Click += new System.EventHandler(this.Snapshot_Click);
            // 
            // fiveHP
            // 
            this.fiveHP.AutoSize = true;
            this.fiveHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fiveHP.Location = new System.Drawing.Point(625, 406);
            this.fiveHP.Name = "fiveHP";
            this.fiveHP.Size = new System.Drawing.Size(139, 21);
            this.fiveHP.TabIndex = 12;
            this.fiveHP.TabStop = true;
            this.fiveHP.Text = "0.05Hz High Pass";
            this.fiveHP.UseVisualStyleBackColor = true;
            this.fiveHP.CheckedChanged += new System.EventHandler(this.fiveHP_CheckedChanged);
            // 
            // pointHP
            // 
            this.pointHP.AutoSize = true;
            this.pointHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointHP.Location = new System.Drawing.Point(486, 406);
            this.pointHP.Name = "pointHP";
            this.pointHP.Size = new System.Drawing.Size(119, 21);
            this.pointHP.TabIndex = 13;
            this.pointHP.TabStop = true;
            this.pointHP.Text = "5Hz High Pass";
            this.pointHP.UseVisualStyleBackColor = true;
            this.pointHP.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // OverLoad
            // 
            this.OverLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OverLoad.Location = new System.Drawing.Point(33, 442);
            this.OverLoad.Name = "OverLoad";
            this.OverLoad.Size = new System.Drawing.Size(167, 30);
            this.OverLoad.TabIndex = 14;
            this.OverLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OverLoad.TextChanged += new System.EventHandler(this.Overload_TextChanged);
            // 
            // HeartRate
            // 
            this.HeartRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeartRate.Location = new System.Drawing.Point(418, 367);
            this.HeartRate.Name = "HeartRate";
            this.HeartRate.ReadOnly = true;
            this.HeartRate.Size = new System.Drawing.Size(167, 30);
            this.HeartRate.TabIndex = 15;
            this.HeartRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(450, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Heart Rate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 493);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeartRate);
            this.Controls.Add(this.OverLoad);
            this.Controls.Add(this.pointHP);
            this.Controls.Add(this.fiveHP);
            this.Controls.Add(this.Snapshot);
            this.Controls.Add(this.NotchBox);
            this.Controls.Add(this.GainBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ECG Machine";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox GainBox;
        private System.Windows.Forms.CheckBox NotchBox;
        private System.Windows.Forms.Button Snapshot;
        private System.Windows.Forms.RadioButton fiveHP;
        private System.Windows.Forms.RadioButton pointHP;
        private System.Windows.Forms.TextBox OverLoad;
        private System.Windows.Forms.TextBox HeartRate;
        private System.Windows.Forms.Label label1;
    }
}

