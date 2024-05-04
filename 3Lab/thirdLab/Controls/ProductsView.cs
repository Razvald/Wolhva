namespace thirdLab.Controls
{
    internal partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
        }

        // Свойство для получения и установки идентификатора продукта
        public int ProductId
        {
            get { return int.Parse(txtProductId.Text); }
            set { txtProductId.Text = value.ToString(); }
        }

        // Свойство для получения и установки названия продукта
        public string ProductName
        {
            get { return txtProductName.Text; }
            set { txtProductName.Text = value; }
        }

        // Свойство для получения и установки цены продукта
        public int ProductPrice
        {
            get { return int.Parse(txtProductPrice.Text); }
            set { txtProductPrice.Text = value.ToString(); }
        }

        // Свойство для получения и установки выбранного материала продукта
        public string SelectedMaterial
        {
            get { return cmbMaterial.SelectedItem.ToString(); }
            set { cmbMaterial.SelectedItem = value; }
        }

        // Метод для загрузки списка материалов в combobox
        public void LoadMaterials(IEnumerable<string> materials)
        {
            cmbMaterial.Items.Clear();
            foreach (var material in materials)
            {
                cmbMaterial.Items.Add(material);
            }
        }
    }
}
