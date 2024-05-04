using _4Lab.FormData;
using _4Lab.Services;
using System.Windows;

namespace _4Lab.Forms
{
    public partial class MaterialsCustom : Window
    {
        public MaterialsCustom(IDataService dataService)
        {
            InitializeComponent();
            DataContext = new MaterialCustomControl(dataService);
        }
    }
}
