namespace baokan
{
    partial class baokan
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baokan));
            this.btnLog = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.textUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1yh = new System.Windows.Forms.RadioButton();
            this.radioButton2gly = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.Coral;
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLog.Location = new System.Drawing.Point(130, 298);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 32);
            this.btnLog.TabIndex = 0;
            this.btnLog.Text = "登录";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Coral;
            this.btnClose.Location = new System.Drawing.Point(431, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(138, 119);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(368, 25);
            this.textUser.TabIndex = 2;
            this.textUser.Text = "G000";
            this.textUser.TextChanged += new System.EventHandler(this.textUser_TextChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPwd.Location = new System.Drawing.Point(138, 176);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(368, 25);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "类型";
            // 
            // radioButton1yh
            // 
            this.radioButton1yh.AutoSize = true;
            this.radioButton1yh.CausesValidation = false;
            this.radioButton1yh.Location = new System.Drawing.Point(138, 239);
            this.radioButton1yh.Name = "radioButton1yh";
            this.radioButton1yh.Size = new System.Drawing.Size(58, 19);
            this.radioButton1yh.TabIndex = 8;
            this.radioButton1yh.Text = "用户";
            this.radioButton1yh.UseVisualStyleBackColor = true;
            // 
            // radioButton2gly
            // 
            this.radioButton2gly.AutoSize = true;
            this.radioButton2gly.Checked = true;
            this.radioButton2gly.Location = new System.Drawing.Point(376, 239);
            this.radioButton2gly.Name = "radioButton2gly";
            this.radioButton2gly.Size = new System.Drawing.Size(73, 19);
            this.radioButton2gly.TabIndex = 9;
            this.radioButton2gly.TabStop = true;
            this.radioButton2gly.Text = "管理员";
            this.radioButton2gly.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(481, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "注册";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // baokan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(568, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2gly);
            this.Controls.Add(this.radioButton1yh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLog);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "baokan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLog;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1yh;
        private System.Windows.Forms.RadioButton radioButton2gly;
        private System.Windows.Forms.Button button1;
    }
}

