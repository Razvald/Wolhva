using Microsoft.Extensions.DependencyInjection;
using thirdLab.Controls;
using thirdLab.Services.Interfaces;

namespace thirdLab.Forms
{
    internal partial class MaterialsCustomForm : Form
    {
        private readonly IDbWorker _db;
        private readonly IServiceProvider _service;

        public MaterialsCustomForm(IDbWorker db, IServiceProvider service)
        {
            InitializeComponent();
            _db = db;
            _service = service;
        }

        // Обработчик события нажатия на кнопку сохранения
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Обновляем информацию о материалах
            foreach (var control in panel.Controls)
            {
                if (control is MaterialsView materialView)
                {
                    var material = _db.Materials.FirstOrDefault(m => m.Id == materialView.MaterialId);
                    if (material != null)
                    {
                        // Обновляем только измененные материалы
                        if (material.Name != materialView.MaterialName || material.Id != materialView.MaterialId)
                        {
                            material.Id = materialView.MaterialId;
                            material.Name = materialView.MaterialName;
                        }
                    }
                }
            }

            _db.SaveChanges();
        }

        // Обработчик события загрузки формы
        private void MaterialsCustomForm_Load(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        // Метод для загрузки списка материалов
        private void LoadMaterials()
        {
            int top = 0; // Начальная позиция Y для первого контроллера
            foreach (var material in _db.Materials)
            {
                var materialView = new MaterialsView();
                materialView.MaterialId = material.Id;
                materialView.MaterialName = material.Name;

                // Подписываемся на событие ProductsButtonClicked
                materialView.ProductsButtonClicked += MaterialView_ProductsButtonClicked;

                materialView.Top = top; // Устанавливаем позицию контроллера
                panel.Controls.Add(materialView); // Добавляем контроллер на панель

                top += materialView.Height + 5; // Увеличиваем позицию для следующего контроллера
            }
        }

        // Обработчик события нажатия на кнопку продуктов
        private void MaterialView_ProductsButtonClicked(object sender, int materialId)
        {
            // Находим материал по его Id
            var selectedMaterial = _db.Materials.FirstOrDefault(m => m.Id == materialId);
            if (selectedMaterial != null)
            {
                // Открываем форму ProductsCustomForm и передаем выбранный материал
                ProductsCustomForm customProductForm = _service.GetRequiredService<ProductsCustomForm>();
                customProductForm.SetSelectedMaterial(selectedMaterial.Id); // Передаем ID выбранного материала
                customProductForm.ShowDialog();
            }
        }
    }
}
