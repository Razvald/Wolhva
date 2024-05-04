namespace firstWork
{
    partial class MyForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnShowDialog = new Button();
            btnOk = new Button();
            lblDateTime = new Label();
            timeDebug = new timeDebug(components);
            paswdHide = new PaswdHide();
            SuspendLayout();
            // 
            // btnShowDialog
            // 
            btnShowDialog.Location = new Point(12, 124);
            btnShowDialog.Name = "btnShowDialog";
            btnShowDialog.Size = new Size(89, 48);
            btnShowDialog.TabIndex = 1;
            btnShowDialog.Text = "Открыть новое окно";
            btnShowDialog.UseVisualStyleBackColor = true;
            btnShowDialog.Click += btnShowDialog_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(208, 124);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(89, 48);
            btnOk.TabIndex = 2;
            btnOk.Text = "Закрыть окно";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Location = new Point(12, 83);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(0, 15);
            lblDateTime.TabIndex = 3;
            // 
            // paswdHide
            // 
            paswdHide.Label = "";
            paswdHide.Location = new Point(12, 12);
            paswdHide.MaximumSize = new Size(0, 50);
            paswdHide.MinimumSize = new Size(149, 50);
            paswdHide.Name = "paswdHide";
            paswdHide.Password = "";
            paswdHide.Size = new Size(149, 50);
            paswdHide.TabIndex = 4;
            // 
            // MyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 184);
            Controls.Add(paswdHide);
            Controls.Add(lblDateTime);
            Controls.Add(btnOk);
            Controls.Add(btnShowDialog);
            Name = "MyForm";
            Text = "My Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnShowDialog;
        private Button btnOk;
        private Label lblDateTime;
        private timeDebug timeDebug;
        private PaswdHide paswdHide;
    }
}