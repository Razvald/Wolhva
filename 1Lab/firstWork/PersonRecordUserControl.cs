using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace firstWork
{
    public partial class PersonRecordUserControl : UserControl
    {
        private MainForm mainForm;
        public FlowLayoutPanel FlPanel { get; set; }

        public PersonRecordUserControl(MainForm form)
        {
            InitializeComponent();

            mainForm = form;
        }

        public int Age
        {
            get
            {
                int age;
                if ((int.TryParse(tbxAge.Text, out age)) && age >= 0)
                {
                    return age;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void SetPersonData(int id)
        {
            tbxID.Text = id.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PersonRecordEditDialog editDialog = new();
            editDialog.SetPersonData(tbxFirName.Text, tbxSecName.Text, tbxThiName.Text, tbxAge.Text);
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                tbxFirName.Text = editDialog.FirstName;
                tbxSecName.Text = editDialog.SecondName;
                tbxThiName.Text = editDialog.ThirdName;
                tbxAge.Text = editDialog.Age;

                mainForm.UpdateStatistics();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (FlPanel != null)
            {
                int index = FlPanel.Controls.IndexOf(this);
                FlPanel.Controls.Remove(this);
                RefreshPersonIds(index);

                mainForm.UpdateStatistics();
            }
            else
            {
                mainForm.lblTotalAge.Text = "Ошибка удаления запись";
            }
        }

        private void RefreshPersonIds(int startIndex)
        {
            if (FlPanel != null)
            {
                for (int i = startIndex; i < FlPanel.Controls.Count; i++)
                {
                    PersonRecordUserControl personRecord = FlPanel.Controls[i] as PersonRecordUserControl;
                    if (personRecord != null)
                    {
                        personRecord.SetPersonData(i + 1);
                    }
                }
            }
        }
    }
}
