namespace secondLab.Forms
{
    partial class LoginDialog
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
            label1 = new Label();
            txbLogin = new TextBox();
            txbPassword = new TextBox();
            label2 = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(63, 24);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            // 
            // txbLogin
            // 
            txbLogin.Font = new Font("Trebuchet MS", 14.25F);
            txbLogin.Location = new Point(12, 36);
            txbLogin.Name = "txbLogin";
            txbLogin.Size = new Size(307, 30);
            txbLogin.TabIndex = 1;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Trebuchet MS", 14.25F);
            txbPassword.Location = new Point(12, 108);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(307, 30);
            txbPassword.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 14.25F);
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(74, 24);
            label2.TabIndex = 3;
            label2.Text = "Пароль";
            // 
            // btnLogin
            // 
            btnLogin.Dock = DockStyle.Bottom;
            btnLogin.Font = new Font("Trebuchet MS", 14.25F);
            btnLogin.Location = new Point(0, 172);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(331, 45);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 217);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(txbPassword);
            Controls.Add(txbLogin);
            Controls.Add(label1);
            Name = "LoginDialog";
            Text = "LoginDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txbLogin;
        private TextBox txbPassword;
        private Label label2;
        private Button btnLogin;
    }
}