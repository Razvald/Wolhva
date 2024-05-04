namespace thirdLab.Controls
{
    partial class ProductsView
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
            txtProductId = new TextBox();
            label1 = new Label();
            txtProductName = new TextBox();
            label2 = new Label();
            txtProductPrice = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cmbMaterial = new ComboBox();
            SuspendLayout();
            // 
            // txtProductId
            // 
            txtProductId.Font = new Font("Times New Roman", 14.25F);
            txtProductId.Location = new Point(14, 37);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(29, 29);
            txtProductId.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(14, 13);
            label1.Name = "label1";
            label1.Size = new Size(29, 21);
            label1.TabIndex = 4;
            label1.Text = "ID";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Times New Roman", 14.25F);
            txtProductName.Location = new Point(74, 37);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(162, 29);
            txtProductName.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(74, 13);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 6;
            label2.Text = "Name";
            // 
            // txtProductPrice
            // 
            txtProductPrice.Font = new Font("Times New Roman", 14.25F);
            txtProductPrice.Location = new Point(271, 37);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(91, 29);
            txtProductPrice.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(271, 13);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 8;
            label3.Text = "Price";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(533, 13);
            label4.Name = "label4";
            label4.Size = new Size(69, 21);
            label4.TabIndex = 10;
            label4.Text = "Material";
            // 
            // cmbMaterial
            // 
            cmbMaterial.Font = new Font("Times New Roman", 14.25F);
            cmbMaterial.FormattingEnabled = true;
            cmbMaterial.Location = new Point(481, 37);
            cmbMaterial.Name = "cmbMaterial";
            cmbMaterial.Size = new Size(121, 29);
            cmbMaterial.TabIndex = 11;
            // 
            // ProductsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbMaterial);
            Controls.Add(label4);
            Controls.Add(txtProductPrice);
            Controls.Add(label3);
            Controls.Add(txtProductName);
            Controls.Add(label2);
            Controls.Add(txtProductId);
            Controls.Add(label1);
            Name = "ProductsView";
            Size = new Size(616, 80);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public TextBox txtProductId;
        public TextBox txtProductName;
        public TextBox txtProductPrice;
        public ComboBox cmbMaterial;
    }
}
