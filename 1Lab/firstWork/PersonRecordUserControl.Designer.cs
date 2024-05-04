namespace firstWork
{
    partial class PersonRecordUserControl
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
            btnDelete = new Button();
            btnEdit = new Button();
            lblID = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            tbxID = new TextBox();
            tbxSecName = new TextBox();
            tbxFirName = new TextBox();
            tbxThiName = new TextBox();
            tbxAge = new TextBox();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(447, 44);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(447, 13);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(28, 22);
            lblID.Name = "lblID";
            lblID.Size = new Size(17, 15);
            lblID.TabIndex = 2;
            lblID.Text = "id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 22);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 3;
            label2.Text = "Фамилия";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(205, 22);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 4;
            label3.Text = "Имя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(297, 22);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 5;
            label4.Text = "Отчество";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(377, 22);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 6;
            label5.Text = "Возраст";
            // 
            // tbxID
            // 
            tbxID.Location = new Point(15, 46);
            tbxID.Name = "tbxID";
            tbxID.ReadOnly = true;
            tbxID.Size = new Size(42, 23);
            tbxID.TabIndex = 7;
            // 
            // tbxSecName
            // 
            tbxSecName.Location = new Point(63, 46);
            tbxSecName.Name = "tbxSecName";
            tbxSecName.ReadOnly = true;
            tbxSecName.Size = new Size(100, 23);
            tbxSecName.TabIndex = 8;
            // 
            // tbxFirName
            // 
            tbxFirName.Location = new Point(169, 46);
            tbxFirName.Name = "tbxFirName";
            tbxFirName.ReadOnly = true;
            tbxFirName.Size = new Size(100, 23);
            tbxFirName.TabIndex = 9;
            // 
            // tbxThiName
            // 
            tbxThiName.Location = new Point(275, 45);
            tbxThiName.Name = "tbxThiName";
            tbxThiName.ReadOnly = true;
            tbxThiName.Size = new Size(100, 23);
            tbxThiName.TabIndex = 10;
            // 
            // tbxAge
            // 
            tbxAge.Location = new Point(381, 45);
            tbxAge.Name = "tbxAge";
            tbxAge.ReadOnly = true;
            tbxAge.Size = new Size(42, 23);
            tbxAge.TabIndex = 11;
            // 
            // PersonRecordUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbxAge);
            Controls.Add(tbxThiName);
            Controls.Add(tbxFirName);
            Controls.Add(tbxSecName);
            Controls.Add(tbxID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblID);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Name = "PersonRecordUserControl";
            Size = new Size(540, 80);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDelete;
        private Button btnEdit;
        private Label lblID;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox tbxID;
        private TextBox tbxSecName;
        private TextBox tbxFirName;
        private TextBox tbxThiName;
        private TextBox tbxAge;
    }
}
