namespace ConvertKeyTool
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtNetPublicKey = new System.Windows.Forms.TextBox();
            this.txtJavaPublicKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJavaPrivateKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNetPrivateKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(499, 41);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtNetPublicKey
            // 
            this.txtNetPublicKey.Location = new System.Drawing.Point(620, 25);
            this.txtNetPublicKey.Multiline = true;
            this.txtNetPublicKey.Name = "txtNetPublicKey";
            this.txtNetPublicKey.Size = new System.Drawing.Size(440, 118);
            this.txtNetPublicKey.TabIndex = 1;
            // 
            // txtJavaPublicKey
            // 
            this.txtJavaPublicKey.Location = new System.Drawing.Point(23, 25);
            this.txtJavaPublicKey.Multiline = true;
            this.txtJavaPublicKey.Name = "txtJavaPublicKey";
            this.txtJavaPublicKey.Size = new System.Drawing.Size(440, 118);
            this.txtJavaPublicKey.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Java public key :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Java private key :";
            this.label2.Visible = false;
            // 
            // txtJavaPrivateKey
            // 
            this.txtJavaPrivateKey.Location = new System.Drawing.Point(23, 193);
            this.txtJavaPrivateKey.Multiline = true;
            this.txtJavaPrivateKey.Name = "txtJavaPrivateKey";
            this.txtJavaPrivateKey.Size = new System.Drawing.Size(440, 118);
            this.txtJavaPrivateKey.TabIndex = 4;
            this.txtJavaPrivateKey.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(618, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = ".net public key :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(618, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = ".net private key :";
            this.label4.Visible = false;
            // 
            // txtNetPrivateKey
            // 
            this.txtNetPrivateKey.Location = new System.Drawing.Point(620, 193);
            this.txtNetPrivateKey.Multiline = true;
            this.txtNetPrivateKey.Name = "txtNetPrivateKey";
            this.txtNetPrivateKey.Size = new System.Drawing.Size(440, 118);
            this.txtNetPrivateKey.TabIndex = 7;
            this.txtNetPrivateKey.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 378);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNetPrivateKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJavaPrivateKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJavaPublicKey);
            this.Controls.Add(this.txtNetPublicKey);
            this.Controls.Add(this.btnConvert);
            this.Name = "Form1";
            this.Text = "ConvertKeyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtNetPublicKey;
        private System.Windows.Forms.TextBox txtJavaPublicKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJavaPrivateKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNetPrivateKey;
    }
}

