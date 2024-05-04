using _4Lab.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace _4Lab.Forms
{
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _service;
        private readonly IDataService serviceIData;

        public MainWindow(IServiceProvider service)
        {
            InitializeComponent();
            _service = service;
            serviceIData = _service.GetRequiredService<IDataService>();
        }

        private void BtnMaterials_Click(object sender, RoutedEventArgs e)
        {
            MaterialsDataGrid materialsWindow = new(serviceIData);
            materialsWindow.Show();
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid productsWindow = new(serviceIData);
            productsWindow.Show();
        }

        private void BtnProductsControl_Click(object sender, RoutedEventArgs e)
        {
            ProductsCustom productsCustom = new(serviceIData);
            productsCustom.Show();
        }

        private void BtnMaterialsControl_Click(object sender, RoutedEventArgs e)
        {
            MaterialsCustom materialsCustom = new(serviceIData);
            materialsCustom.Show();
        }
    }
}