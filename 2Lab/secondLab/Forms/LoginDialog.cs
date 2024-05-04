using secondLab.Services.Interfaces;

namespace secondLab.Forms
{
    public partial class LoginDialog : Form
    {
        private readonly IDbWorker _dbWorker;

        public LoginDialog(IDbWorker dbWorker)
        {
            InitializeComponent();
            _dbWorker = dbWorker;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = txbLogin.Text;
            var password = txbPassword.Text;

            var isSuccessful = _dbWorker.Authenticate(login, password);

            if (isSuccessful)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            MessageBox.Show("Ошибка выполнения входа.");
        }
    }
}
