namespace secondLab.Forms
{
    partial class RegisterDialog
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
            btnRegister = new Button();
            label2 = new Label();
            txbPassword = new TextBox();
            txbLogin = new TextBox();
            label1 = new Label();
            label3 = new Label();
            txbPasswordAgain = new TextBox();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Dock = DockStyle.Bottom;
            btnRegister.Font = new Font("Trebuchet MS", 14.25F);
            btnRegister.Location = new Point(0, 261);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(335, 45);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 14.25F);
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(74, 24);
            label2.TabIndex = 8;
            label2.Text = "Пароль";
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Trebuchet MS", 14.25F);
            txbPassword.Location = new Point(12, 104);
            txbPassword.Name = "txbPassword";
            txbPassword.Size = new Size(311, 30);
            txbPassword.TabIndex = 7;
            // 
            // txbLogin
            // 
            txbLogin.Font = new Font("Trebuchet MS", 14.25F);
            txbLogin.Location = new Point(12, 32);
            txbLogin.Name = "txbLogin";
            txbLogin.Size = new Size(311, 30);
            txbLogin.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 14.25F);
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(63, 24);
            label1.TabIndex = 5;
            label1.Text = "Логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 14.25F);
            label3.Location = new Point(12, 152);
            label3.Name = "label3";
            label3.Size = new Size(170, 24);
            label3.TabIndex = 11;
            label3.Text = "Повторите пароль";
            // 
            // txbPasswordAgain
            // 
            txbPasswordAgain.Font = new Font("Trebuchet MS", 14.25F);
            txbPasswordAgain.Location = new Point(12, 179);
            txbPasswordAgain.Name = "txbPasswordAgain";
            txbPasswordAgain.Size = new Size(311, 30);
            txbPasswordAgain.TabIndex = 10;
            // 
            // RegisterDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 306);
            Controls.Add(label3);
            Controls.Add(txbPasswordAgain);
            Controls.Add(btnRegister);
            Controls.Add(label2);
            Controls.Add(txbPassword);
            Controls.Add(txbLogin);
            Controls.Add(label1);
            Name = "RegisterDialog";
            Text = "RegisterDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegister;
        private Label label2;
        private TextBox txbPassword;
        private TextBox txbLogin;
        private Label label1;
        private Label label3;
        private TextBox txbPasswordAgain;
    }
}