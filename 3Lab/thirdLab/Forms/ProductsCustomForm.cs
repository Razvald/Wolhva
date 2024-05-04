using thirdLab.Controls;
using thirdLab.Database.Entites;
using thirdLab.Services.Interfaces;

namespace thirdLab.Forms
{
    internal partial class ProductsCustomForm : Form
    {
        private readonly IDbWorker _db;
        private int _selectedMaterialId; // Идентификатор выбранного материала

        public ProductsCustomForm(IDbWorker db)
        {
            InitializeComponent();
            _db = db;
        }

        // Обработчик события нажатия на кнопку сохранения
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Обновляем информацию о продуктах
            foreach (var control in panel.Controls)
            {
                if (control is ProductsView productView)
                {
                    var product = _db.Products.FirstOrDefault(p => p.Id == productView.ProductId);
                    if (product != null)
                    {
                        // Обновляем только измененные продукты
                        if (product.Id != productView.ProductId || 
                            product.Name != productView.ProductName || 
                            product.Price != productView.ProductPrice || 
                            product.Material.Name != productView.SelectedMaterial)
                        {
                            product.Id = productView.ProductId;
                            product.Name = productView.ProductName;
                            product.Price = productView.ProductPrice;
                            product.Material.Name = productView.SelectedMaterial;
                        }
                    }
                }
            }

            _db.SaveChanges();
        }

        // Обработчик события загрузки формы
        private void ProductsCustomForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        // Метод для загрузки списка продуктов
        private void LoadProducts()
        {
            IEnumerable<Product> filteredProducts;

            int top = 0;

            // Если materialId не передан, отображаем все продукты
            if (_selectedMaterialId == 0)
            {
                filteredProducts = _db.Products;
            }
            else
            {
                // Фильтруем продукты по выбранному материалу
                filteredProducts = _db.Products.Where(p => p.MaterialId == _selectedMaterialId);
            }

            foreach (var product in filteredProducts)
            {
                var productView = new ProductsView
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price
                };

                // Загрузка материалов в combobox
                productView.LoadMaterials(_db.Materials.Select(m => m.Name));

                // Выбор соответствующего материала в combobox
                productView.SelectedMaterial = _db.Materials.FirstOrDefault(m => m.Id == product.MaterialId).Name;

                productView.Top = top;
                panel.Controls.Add(productView);

                top += productView.Height + 5;
            }
        }

        // Метод для установки выбранного материала
        public void SetSelectedMaterial(int materialId)
        {
            _selectedMaterialId = materialId;
            LoadProducts(); // Перезагрузка продуктов с учетом выбранного материала
        }
    }
}
