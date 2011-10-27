namespace CheckDomainName
{
    partial class Main
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
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastStr = new System.Windows.Forms.TextBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbDoMailType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(52, 294);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始扫描";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 45);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(230, 243);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "这里显示可以注册的域名列表，您也可以去根目录下的当前日期.log文件查看...";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(86, 15);
            this.txtSize.Mask = "99999";
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(25, 21);
            this.txtSize.TabIndex = 2;
            this.txtSize.Text = "4";
            this.txtSize.ValidatingType = typeof(int);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "域名结尾：";
            // 
            // txtLastStr
            // 
            this.txtLastStr.Location = new System.Drawing.Point(207, 15);
            this.txtLastStr.Name = "txtLastStr";
            this.txtLastStr.Size = new System.Drawing.Size(37, 21);
            this.txtLastStr.TabIndex = 5;
            this.txtLastStr.Text = ".com";
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(145, 294);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(82, 35);
            this.btnEnd.TabIndex = 0;
            this.btnEnd.Text = "停止";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbDoMailType
            // 
            this.cmbDoMailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoMailType.FormattingEnabled = true;
            this.cmbDoMailType.Location = new System.Drawing.Point(16, 15);
            this.cmbDoMailType.Name = "cmbDoMailType";
            this.cmbDoMailType.Size = new System.Drawing.Size(57, 20);
            this.cmbDoMailType.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 344);
            this.Controls.Add(this.cmbDoMailType);
            this.Controls.Add(this.txtLastStr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Domain_Tools";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MaskedTextBox txtSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastStr;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbDoMailType;
    }
}