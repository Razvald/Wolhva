using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstWork
{
    public partial class PaswdHide : UserControl
    {
        [Category("Behavior")]
        public string Label
        {
            get => lblPassword.Text;
            set => lblPassword.Text = value;
        }
        [Category("Behavior")]
        [Browsable(false)]
        public string Password
        {
            get => tbPassword.Text;
            set => tbPassword.Text = value;
        }

        public PaswdHide()
        {
            InitializeComponent();

            tbPassword.PasswordChar = '*';
        }

        private void btnShowPswd_Click(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar == '\0')
            {
                tbPassword.PasswordChar = '*';
            }
            else
            {
                tbPassword.PasswordChar = '\0';
            }
        }
    }
}
