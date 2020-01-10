namespace WuwuChess
{
    partial class Register
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.PasswordAgain = new System.Windows.Forms.TextBox();
            this.Allow = new System.Windows.Forms.Button();
            this.Allowed = new System.Windows.Forms.PictureBox();
            this.OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Allowed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(45, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "密  码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "再次输入密码：";
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(155, 9);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(137, 21);
            this.ID.TabIndex = 3;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(155, 39);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(137, 21);
            this.Password.TabIndex = 4;
            // 
            // PasswordAgain
            // 
            this.PasswordAgain.Location = new System.Drawing.Point(155, 70);
            this.PasswordAgain.Name = "PasswordAgain";
            this.PasswordAgain.PasswordChar = '*';
            this.PasswordAgain.Size = new System.Drawing.Size(137, 21);
            this.PasswordAgain.TabIndex = 5;
            // 
            // Allow
            // 
            this.Allow.Location = new System.Drawing.Point(298, 9);
            this.Allow.Name = "Allow";
            this.Allow.Size = new System.Drawing.Size(75, 23);
            this.Allow.TabIndex = 6;
            this.Allow.Text = "可用性检测";
            this.Allow.UseVisualStyleBackColor = true;
            this.Allow.Click += new System.EventHandler(this.Allow_Click);
            // 
            // Allowed
            // 
            this.Allowed.BackColor = System.Drawing.Color.Transparent;
            this.Allowed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Allowed.Location = new System.Drawing.Point(379, 10);
            this.Allowed.Name = "Allowed";
            this.Allowed.Size = new System.Drawing.Size(20, 20);
            this.Allowed.TabIndex = 7;
            this.Allowed.TabStop = false;
            // 
            // OK
            // 
            this.OK.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OK.Location = new System.Drawing.Point(299, 39);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(100, 52);
            this.OK.TabIndex = 8;
            this.OK.Text = "确认";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 100);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Allowed);
            this.Controls.Add(this.Allow);
            this.Controls.Add(this.PasswordAgain);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Register";
            this.Text = "Register";
            ((System.ComponentModel.ISupportInitialize)(this.Allowed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox PasswordAgain;
        private System.Windows.Forms.Button Allow;
        private System.Windows.Forms.PictureBox Allowed;
        private System.Windows.Forms.Button OK;
    }
}