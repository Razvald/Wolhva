namespace thirdLab.Forms
{
    partial class ProductsCustomForm
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
            btnSave = new Button();
            panel = new Panel();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(102, 62);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Location = new Point(12, 80);
            panel.Name = "panel";
            panel.Size = new Size(648, 358);
            panel.TabIndex = 3;
            // 
            // ProductsCustomForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 450);
            Controls.Add(panel);
            Controls.Add(btnSave);
            Name = "ProductsCustomForm";
            Text = "ThirdForm";
            Load += ProductsCustomForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnSave;
        private Panel panel;
    }
}