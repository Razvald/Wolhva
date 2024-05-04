namespace thirdLab
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProductGrid = new Button();
            btnMaterialGrid = new Button();
            btnProductCustom = new Button();
            btnMaterialCustom = new Button();
            SuspendLayout();
            // 
            // btnProductGrid
            // 
            btnProductGrid.Location = new Point(12, 12);
            btnProductGrid.Name = "btnProductGrid";
            btnProductGrid.Size = new Size(108, 89);
            btnProductGrid.TabIndex = 0;
            btnProductGrid.Text = "Product Grid";
            btnProductGrid.UseVisualStyleBackColor = true;
            btnProductGrid.Click += btnProductGrid_Click;
            // 
            // btnMaterialGrid
            // 
            btnMaterialGrid.Location = new Point(127, 12);
            btnMaterialGrid.Name = "btnMaterialGrid";
            btnMaterialGrid.Size = new Size(108, 89);
            btnMaterialGrid.TabIndex = 1;
            btnMaterialGrid.Text = "Material Grid";
            btnMaterialGrid.UseVisualStyleBackColor = true;
            btnMaterialGrid.Click += btnMaterialGrid_Click;
            // 
            // btnProductCustom
            // 
            btnProductCustom.Location = new Point(12, 107);
            btnProductCustom.Name = "btnProductCustom";
            btnProductCustom.Size = new Size(108, 89);
            btnProductCustom.TabIndex = 2;
            btnProductCustom.Text = "Custom Product";
            btnProductCustom.UseVisualStyleBackColor = true;
            btnProductCustom.Click += btnProductCustom_Click;
            // 
            // btnMaterialCustom
            // 
            btnMaterialCustom.Location = new Point(127, 107);
            btnMaterialCustom.Name = "btnMaterialCustom";
            btnMaterialCustom.Size = new Size(108, 89);
            btnMaterialCustom.TabIndex = 3;
            btnMaterialCustom.Text = "Custom Material";
            btnMaterialCustom.UseVisualStyleBackColor = true;
            btnMaterialCustom.Click += btnMaterialCustom_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 208);
            Controls.Add(btnMaterialCustom);
            Controls.Add(btnProductCustom);
            Controls.Add(btnMaterialGrid);
            Controls.Add(btnProductGrid);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnProductGrid;
        private Button btnMaterialGrid;
        private Button btnProductCustom;
        private Button btnMaterialCustom;
    }
}
