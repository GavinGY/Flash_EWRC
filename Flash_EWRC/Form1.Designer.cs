namespace Flash_EWRC
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textReceive = new System.Windows.Forms.TextBox();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxS4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxS3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxS2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxS1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // textReceive
            // 
            this.textReceive.Location = new System.Drawing.Point(28, 96);
            this.textReceive.Multiline = true;
            this.textReceive.Name = "textReceive";
            this.textReceive.Size = new System.Drawing.Size(621, 100);
            this.textReceive.TabIndex = 0;
            this.textReceive.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSwitch
            // 
            this.btnSwitch.Location = new System.Drawing.Point(99, 30);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(75, 47);
            this.btnSwitch.TabIndex = 2;
            this.btnSwitch.Text = "Connect";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbSerial
            // 
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(28, 57);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(65, 20);
            this.cbSerial.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(180, 30);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 47);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Start";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Erase";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(486, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Write";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(547, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Read";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(602, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Verify";
            // 
            // pictureBoxS4
            // 
            this.pictureBoxS4.Location = new System.Drawing.Point(593, 30);
            this.pictureBoxS4.Name = "pictureBoxS4";
            this.pictureBoxS4.Size = new System.Drawing.Size(57, 48);
            this.pictureBoxS4.TabIndex = 13;
            this.pictureBoxS4.TabStop = false;
            // 
            // pictureBoxS3
            // 
            this.pictureBoxS3.Location = new System.Drawing.Point(536, 30);
            this.pictureBoxS3.Name = "pictureBoxS3";
            this.pictureBoxS3.Size = new System.Drawing.Size(51, 48);
            this.pictureBoxS3.TabIndex = 12;
            this.pictureBoxS3.TabStop = false;
            // 
            // pictureBoxS2
            // 
            this.pictureBoxS2.Location = new System.Drawing.Point(479, 30);
            this.pictureBoxS2.Name = "pictureBoxS2";
            this.pictureBoxS2.Size = new System.Drawing.Size(51, 48);
            this.pictureBoxS2.TabIndex = 11;
            this.pictureBoxS2.TabStop = false;
            // 
            // pictureBoxS1
            // 
            this.pictureBoxS1.Location = new System.Drawing.Point(422, 30);
            this.pictureBoxS1.Name = "pictureBoxS1";
            this.pictureBoxS1.Size = new System.Drawing.Size(51, 48);
            this.pictureBoxS1.TabIndex = 6;
            this.pictureBoxS1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(275, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 48);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(338, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 48);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "NOR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "NAND";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 208);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxS4);
            this.Controls.Add(this.pictureBoxS3);
            this.Controls.Add(this.pictureBoxS2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxS1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cbSerial);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.textReceive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Foxconn Flah EWRC Tool         V1.60";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbSerial;
        public System.Windows.Forms.Button btnSwitch;
        public System.Windows.Forms.Button btnSend;
        public System.Windows.Forms.TextBox textReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxS1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxS2;
        private System.Windows.Forms.PictureBox pictureBoxS3;
        private System.Windows.Forms.PictureBox pictureBoxS4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;

    }
}

