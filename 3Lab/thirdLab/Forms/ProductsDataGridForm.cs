using thirdLab.Services.Interfaces;

namespace thirdLab.Forms
{
    internal partial class ProductsDataGridForm : Form
    {
        private readonly IDbWorker _db;

        public ProductsDataGridForm(IDbWorker db)
        {
            InitializeComponent();

            _db = db;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _db.SaveChanges();
        }

        private void ProductsDataGridForm_Load(object sender, EventArgs e)
        {
            dgvProducts.DataSource = _db.Products;
            dgvProducts.Columns["Material"].Visible = false;
        }
    }
}
