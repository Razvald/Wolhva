using Microsoft.Extensions.DependencyInjection;
using thirdLab.Forms;

namespace thirdLab
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _service;
        public MainForm(IServiceProvider service)
        {
            InitializeComponent();

            _service = service;
        }

        private void btnProductGrid_Click(object sender, EventArgs e)
        {
            ProductsDataGridForm productsGrid = _service.GetRequiredService<ProductsDataGridForm>();
            productsGrid.Show();
        }

        private void btnMaterialGrid_Click(object sender, EventArgs e)
        {
            MaterialsDataGridForm materialsGrid = _service.GetRequiredService<MaterialsDataGridForm>();
            materialsGrid.Show();
        }

        private void btnProductCustom_Click(object sender, EventArgs e)
        {
            ProductsCustomForm productsCustom = _service.GetRequiredService<ProductsCustomForm>();
            productsCustom.Show();
        }

        private void btnMaterialCustom_Click(object sender, EventArgs e)
        {
            MaterialsCustomForm materialsCustom = _service.GetRequiredService<MaterialsCustomForm>();
            materialsCustom.Show();
        }
    }
}
