using System.Data.SqlTypes;
using System.Windows.Forms.Design.Behavior;

namespace firstWork
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
            timeDebug.Tick += TimeDebug_Tick;
        }

        private void TimeDebug_Tick(object? sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString();
        }

        private void btnShowDialog_Click(object sender, EventArgs e)
        {
            var dialogForm = new MyForm();
            dialogForm.ShowDialog();

            MessageBox.Show($"Статус закрытия окна: \n{dialogForm.DialogResult}");

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            MessageBox.Show($"Пароль: \n{paswdHide.Password}");
            this.Close();
        }
    }
}
