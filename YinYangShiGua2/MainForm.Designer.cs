namespace YinYangShiGua2
{
    partial class MainForm
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
            this.jueXingBtn = new System.Windows.Forms.Button();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.stopBtn = new System.Windows.Forms.Button();
            this.yunHunBtn = new System.Windows.Forms.Button();
            this.yunHunCntTextBox = new System.Windows.Forms.TextBox();
            this.juXingCntTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // jueXingBtn
            // 
            this.jueXingBtn.Location = new System.Drawing.Point(12, 12);
            this.jueXingBtn.Name = "jueXingBtn";
            this.jueXingBtn.Size = new System.Drawing.Size(75, 23);
            this.jueXingBtn.TabIndex = 0;
            this.jueXingBtn.Text = "觉醒材料";
            this.jueXingBtn.UseVisualStyleBackColor = true;
            this.jueXingBtn.Click += new System.EventHandler(this.jueXingBtn_Click);
            // 
            // debugTextBox
            // 
            this.debugTextBox.Location = new System.Drawing.Point(287, 12);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugTextBox.Size = new System.Drawing.Size(301, 343);
            this.debugTextBox.TabIndex = 1;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(12, 321);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(75, 23);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "停止";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // yunHunBtn
            // 
            this.yunHunBtn.Location = new System.Drawing.Point(12, 51);
            this.yunHunBtn.Name = "yunHunBtn";
            this.yunHunBtn.Size = new System.Drawing.Size(75, 23);
            this.yunHunBtn.TabIndex = 3;
            this.yunHunBtn.Text = "御魂";
            this.yunHunBtn.UseVisualStyleBackColor = true;
            this.yunHunBtn.Click += new System.EventHandler(this.yunHunBtn_Click);
            // 
            // yunHunCntTextBox
            // 
            this.yunHunCntTextBox.Location = new System.Drawing.Point(138, 53);
            this.yunHunCntTextBox.Name = "yunHunCntTextBox";
            this.yunHunCntTextBox.Size = new System.Drawing.Size(100, 21);
            this.yunHunCntTextBox.TabIndex = 4;
            // 
            // juXingCntTextBox
            // 
            this.juXingCntTextBox.Location = new System.Drawing.Point(138, 14);
            this.juXingCntTextBox.Name = "juXingCntTextBox";
            this.juXingCntTextBox.Size = new System.Drawing.Size(100, 21);
            this.juXingCntTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "次数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "次数";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 367);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.juXingCntTextBox);
            this.Controls.Add(this.yunHunCntTextBox);
            this.Controls.Add(this.yunHunBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.debugTextBox);
            this.Controls.Add(this.jueXingBtn);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button jueXingBtn;
        private System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button yunHunBtn;
        private System.Windows.Forms.TextBox yunHunCntTextBox;
        private System.Windows.Forms.TextBox juXingCntTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

