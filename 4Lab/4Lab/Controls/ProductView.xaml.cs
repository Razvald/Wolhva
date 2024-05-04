using _4Lab.Database;
using _4Lab.FormData;
using System.Windows;
using System.Windows.Controls;

namespace _4Lab.Controls
{
    public partial class ProductView : UserControl
    {
        public ProductView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(ProductView), new PropertyMetadata(0));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ProductView), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(int), typeof(ProductView), new PropertyMetadata(0));
        public static readonly DependencyProperty MaterialIdProperty =
            DependencyProperty.Register("MaterialId", typeof(int), typeof(ProductView), new PropertyMetadata(0));
        public static readonly DependencyProperty MaterialProperty =
            DependencyProperty.Register("Material", typeof(Material), typeof(ProductView), new PropertyMetadata(null));
        public static readonly DependencyProperty MaterialTextProperty =
            DependencyProperty.Register("MaterialText", typeof(string), typeof(ProductView), new PropertyMetadata(string.Empty));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public int MaterialId
        {
            get { return (int)GetValue(MaterialIdProperty); }
            set { SetValue(MaterialIdProperty, value); }
        }

        public Material Material
        {
            get { return (Material)GetValue(MaterialProperty); }
            set { SetValue(MaterialProperty, value); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            MaterialComboBox.Text = Material.Title;
        }

        private void MaterialComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is Material selectedMaterial)
            {
                if (DataContext is Product product)
                {
                    product.MaterialId = selectedMaterial.Id;
                }
            }
        }
    }
}
