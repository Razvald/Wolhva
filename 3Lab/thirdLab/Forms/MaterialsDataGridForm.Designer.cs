namespace thirdLab
{
    partial class MaterialsDataGridForm
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
            dgvMaterials = new DataGridView();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
            SuspendLayout();
            // 
            // dgvMaterials
            // 
            dgvMaterials.AllowUserToOrderColumns = true;
            dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterials.Location = new Point(12, 80);
            dgvMaterials.Name = "dgvMaterials";
            dgvMaterials.Size = new Size(648, 358);
            dgvMaterials.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(102, 62);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // MaterialsDataGridForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 450);
            Controls.Add(btnSave);
            Controls.Add(dgvMaterials);
            Name = "MaterialsDataGridForm";
            Text = "SecondForm";
            Load += MaterialsDataGridForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMaterials;
        private Button btnSave;
    }
}