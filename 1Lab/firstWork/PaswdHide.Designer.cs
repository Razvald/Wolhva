namespace firstWork
{
    partial class PaswdHide
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            tbPassword = new TextBox();
            btnShowPswd = new Button();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Location = new Point(3, 25);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Введи пароль";
            tbPassword.Size = new Size(113, 23);
            tbPassword.TabIndex = 0;
            // 
            // btnShowPswd
            // 
            btnShowPswd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowPswd.Location = new Point(123, 25);
            btnShowPswd.Name = "btnShowPswd";
            btnShowPswd.Size = new Size(23, 23);
            btnShowPswd.TabIndex = 1;
            btnShowPswd.Text = "👁";
            btnShowPswd.UseVisualStyleBackColor = true;
            btnShowPswd.Click += btnShowPswd_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(3, 7);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(0, 15);
            lblPassword.TabIndex = 2;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPassword);
            Controls.Add(btnShowPswd);
            Controls.Add(tbPassword);
            MaximumSize = new Size(0, 50);
            MinimumSize = new Size(149, 50);
            Name = "UserControl1";
            Size = new Size(149, 50);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbPassword;
        private Button btnShowPswd;
        private Label lblPassword;
    }
}
