namespace firstWork
{
    partial class PersonRecordEditDialog
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
            tbxAge = new TextBox();
            tbxThiName = new TextBox();
            tbxFirName = new TextBox();
            tbxSecName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // tbxAge
            // 
            tbxAge.Location = new Point(12, 159);
            tbxAge.Name = "tbxAge";
            tbxAge.Size = new Size(42, 23);
            tbxAge.TabIndex = 21;
            // 
            // tbxThiName
            // 
            tbxThiName.Location = new Point(12, 115);
            tbxThiName.Name = "tbxThiName";
            tbxThiName.Size = new Size(100, 23);
            tbxThiName.TabIndex = 20;
            // 
            // tbxFirName
            // 
            tbxFirName.Location = new Point(12, 71);
            tbxFirName.Name = "tbxFirName";
            tbxFirName.Size = new Size(100, 23);
            tbxFirName.TabIndex = 19;
            // 
            // tbxSecName
            // 
            tbxSecName.Location = new Point(12, 27);
            tbxSecName.Name = "tbxSecName";
            tbxSecName.Size = new Size(100, 23);
            tbxSecName.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 141);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 16;
            label5.Text = "Возраст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 97);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 15;
            label4.Text = "Отчество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 53);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 14;
            label3.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 13;
            label2.Text = "Фамилия";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 207);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 36);
            btnSave.TabIndex = 22;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // PersonRecordEditDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 255);
            Controls.Add(btnSave);
            Controls.Add(tbxAge);
            Controls.Add(tbxThiName);
            Controls.Add(tbxFirName);
            Controls.Add(tbxSecName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "PersonRecordEditDialog";
            Text = "PersonRecordEditDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxAge;
        private TextBox tbxThiName;
        private TextBox tbxFirName;
        private TextBox tbxSecName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnSave;
    }
}