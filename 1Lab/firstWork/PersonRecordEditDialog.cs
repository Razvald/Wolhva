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
    public partial class PersonRecordEditDialog : Form
    {
        public PersonRecordEditDialog()
        {
            InitializeComponent();
        }

        public void SetPersonData(string firstName, string secondName, string thirdName, string age)
        {
            tbxFirName.Text = firstName;
            tbxSecName.Text = secondName;
            tbxThiName.Text = thirdName;
            tbxAge.Text = age;
        }

        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string ThirdName { get; private set; }
        public string Age { get; private set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FirstName = tbxFirName.Text;
            SecondName = tbxSecName.Text;
            ThirdName = tbxThiName.Text;
            Age = tbxAge.Text;

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
