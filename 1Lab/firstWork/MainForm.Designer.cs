namespace firstWork
{
    partial class MainForm
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
            flPanel = new FlowLayoutPanel();
            btnAdd = new Button();
            lblTotalRecords = new Label();
            lblTotalAge = new Label();
            SuspendLayout();
            // 
            // flPanel
            // 
            flPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flPanel.AutoScroll = true;
            flPanel.FlowDirection = FlowDirection.TopDown;
            flPanel.Location = new Point(12, 118);
            flPanel.Name = "flPanel";
            flPanel.RightToLeft = RightToLeft.No;
            flPanel.Size = new Size(560, 320);
            flPanel.TabIndex = 0;
            flPanel.WrapContents = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 32);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 54);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Location = new Point(229, 32);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new Size(91, 15);
            lblTotalRecords.TabIndex = 2;
            lblTotalRecords.Text = "Всего записей: ";
            // 
            // lblTotalAge
            // 
            lblTotalAge.AutoSize = true;
            lblTotalAge.Location = new Point(229, 71);
            lblTotalAge.Name = "lblTotalAge";
            lblTotalAge.Size = new Size(126, 15);
            lblTotalAge.TabIndex = 3;
            lblTotalAge.Text = "Суммарный возраст: ";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 450);
            Controls.Add(lblTotalAge);
            Controls.Add(lblTotalRecords);
            Controls.Add(btnAdd);
            Controls.Add(flPanel);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flPanel;
        private Button btnAdd;
        private Label lblTotalRecords;
        public Label lblTotalAge;
    }
}