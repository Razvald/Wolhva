using _4Lab.FormData;
using _4Lab.Services;
using System.Windows;

namespace _4Lab.Forms
{
    public partial class ProductsDataGrid : Window
    {
        public ProductsDataGrid(IDataService dataService)
        {
            InitializeComponent();
            DataContext = new ProductsGrid(dataService);
        }
    }
}
