using _4Lab.FormData;
using _4Lab.Services;
using System.Windows;

namespace _4Lab.Forms
{
    public partial class ProductsCustom : Window
    {
        public ProductsCustom(IDataService dataService, int materialId = 0)
        {
            InitializeComponent();
            DataContext = new ProductsCustomControl(dataService, materialId);
        }
    }
}
