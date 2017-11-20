namespace GernerateKey
{
    partial class GernerateFrm
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
            this.btnGernerate = new System.Windows.Forms.Button();
            this.txtNetPublicKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNetPrivateKey = new System.Windows.Forms.TextBox();
            this.txtJavaPrivateKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJavaPublicKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGernerate
            // 
            this.btnGernerate.Location = new System.Drawing.Point(42, 12);
            this.btnGernerate.Name = "btnGernerate";
            this.btnGernerate.Size = new System.Drawing.Size(75, 23);
            this.btnGernerate.TabIndex = 0;
            this.btnGernerate.Text = "生成RSA对";
            this.btnGernerate.UseVisualStyleBackColor = true;
            this.btnGernerate.Click += new System.EventHandler(this.btnGernerate_Click);
            // 
            // txtNetPublicKey
            // 
            this.txtNetPublicKey.Location = new System.Drawing.Point(42, 65);
            this.txtNetPublicKey.Multiline = true;
            this.txtNetPublicKey.Name = "txtNetPublicKey";
            this.txtNetPublicKey.Size = new System.Drawing.Size(423, 191);
            this.txtNetPublicKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(42, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = ".net public key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = ".net private key:";
            // 
            // txtNetPrivateKey
            // 
            this.txtNetPrivateKey.Location = new System.Drawing.Point(42, 296);
            this.txtNetPrivateKey.Multiline = true;
            this.txtNetPrivateKey.Name = "txtNetPrivateKey";
            this.txtNetPrivateKey.Size = new System.Drawing.Size(423, 191);
            this.txtNetPrivateKey.TabIndex = 5;
            // 
            // txtJavaPrivateKey
            // 
            this.txtJavaPrivateKey.Location = new System.Drawing.Point(492, 296);
            this.txtJavaPrivateKey.Multiline = true;
            this.txtJavaPrivateKey.Name = "txtJavaPrivateKey";
            this.txtJavaPrivateKey.Size = new System.Drawing.Size(423, 191);
            this.txtJavaPrivateKey.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(492, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Java private key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(492, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Java public key:";
            // 
            // txtJavaPublicKey
            // 
            this.txtJavaPublicKey.Location = new System.Drawing.Point(492, 63);
            this.txtJavaPublicKey.Multiline = true;
            this.txtJavaPublicKey.Name = "txtJavaPublicKey";
            this.txtJavaPublicKey.Size = new System.Drawing.Size(423, 191);
            this.txtJavaPublicKey.TabIndex = 6;
            // 
            // GernerateFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 502);
            this.Controls.Add(this.txtJavaPrivateKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtJavaPublicKey);
            this.Controls.Add(this.txtNetPrivateKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNetPublicKey);
            this.Controls.Add(this.btnGernerate);
            this.Name = "GernerateFrm";
            this.Text = "GernerateKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGernerate;
        private System.Windows.Forms.TextBox txtNetPublicKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNetPrivateKey;
        private System.Windows.Forms.TextBox txtJavaPrivateKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtJavaPublicKey;
    }
}

