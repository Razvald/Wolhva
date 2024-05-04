namespace thirdLab.Controls
{
    public partial class MaterialsView : UserControl
    {
        // Событие, возникающее при нажатии на кнопку продуктов
        public event EventHandler<int> ProductsButtonClicked;

        public MaterialsView()
        {
            InitializeComponent();
        }

        // Свойство для получения и установки идентификатора материала
        public int MaterialId
        {
            get { return int.Parse(txtMaterialId.Text); }
            set { txtMaterialId.Text = value.ToString(); }
        }

        // Свойство для получения и установки названия материала
        public string MaterialName
        {
            get { return txtMaterialName.Text; }
            set { txtMaterialName.Text = value; }
        }

        // Обработчик события нажатия на кнопку продуктов
        private void btnProducts_Click(object sender, EventArgs e)
        {
            // Получаем идентификатор материала
            int materialId = int.Parse(txtMaterialId.Text);

            // Вызываем событие ProductsButtonClicked и передаем идентификатор материала
            ProductsButtonClicked?.Invoke(this, materialId);
        }
    }
}
