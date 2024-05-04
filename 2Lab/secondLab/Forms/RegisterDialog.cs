using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using secondLab.Services.Interfaces;

namespace secondLab.Forms
{
    public partial class RegisterDialog : Form
    {
        private readonly IDbWorker _dbWorker;

        public RegisterDialog(IDbWorker dbWorker)
        {
            InitializeComponent();
            _dbWorker = dbWorker;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var login = txbLogin.Text;
            var password = txbPassword.Text;
            var passwordAgain = txbPasswordAgain.Text;

            if (password != passwordAgain)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }

            if (_dbWorker.IsLoginAlreadyTaken(login))
            {
                MessageBox.Show("Такой логин уже занят!");
                return;
            }

            _dbWorker.RegisterNewUser(login, password);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
