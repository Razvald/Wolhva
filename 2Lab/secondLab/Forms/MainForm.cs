using Microsoft.Extensions.DependencyInjection;
using secondLab.Forms;

namespace secondLab
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var dialog = _serviceProvider.GetRequiredService<RegisterDialog>();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Регистрация прошла успешно.");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var dialog = _serviceProvider.GetRequiredService<LoginDialog>();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Вход выполнен.");
            }
        }
    }
}
