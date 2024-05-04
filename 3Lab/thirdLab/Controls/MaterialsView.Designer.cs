namespace thirdLab.Controls
{
    partial class MaterialsView
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtMaterialId = new TextBox();
            txtMaterialName = new TextBox();
            btnProducts = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(14, 13);
            label1.Name = "label1";
            label1.Size = new Size(29, 21);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(74, 13);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 1;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(556, 13);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 2;
            label3.Text = "Products";
            // 
            // txtMaterialId
            // 
            txtMaterialId.Font = new Font("Times New Roman", 14.25F);
            txtMaterialId.Location = new Point(14, 37);
            txtMaterialId.Name = "txtMaterialId";
            txtMaterialId.Size = new Size(29, 29);
            txtMaterialId.TabIndex = 3;
            // 
            // txtMaterialName
            // 
            txtMaterialName.Font = new Font("Times New Roman", 14.25F);
            txtMaterialName.Location = new Point(74, 37);
            txtMaterialName.Name = "txtMaterialName";
            txtMaterialName.Size = new Size(162, 29);
            txtMaterialName.TabIndex = 4;
            // 
            // btnProducts
            // 
            btnProducts.Font = new Font("Times New Roman", 14.25F);
            btnProducts.Location = new Point(556, 37);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(78, 29);
            btnProducts.TabIndex = 5;
            btnProducts.Text = "See";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // MaterialsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnProducts);
            Controls.Add(txtMaterialName);
            Controls.Add(txtMaterialId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MaterialsView";
            Size = new Size(648, 80);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnProducts;
        public TextBox txtMaterialId;
        public TextBox txtMaterialName;
    }
}
