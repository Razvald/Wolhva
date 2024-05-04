using _4Lab.FormData;
using _4Lab.Services;
using System.Windows;

namespace _4Lab.Forms
{
    public partial class MaterialsDataGrid : Window
    {
        public MaterialsDataGrid(IDataService dataService)
        {
            InitializeComponent();
            var materialsGrid = new MaterialsGrid(dataService);
            DataContext = materialsGrid;
        }
    }
}
