// ViewModels/MainWindowVM.cs
using _8Lab.Model;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;

namespace _8Lab.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly string _accessToken = "sl.B2siDtH93JFDGiGn86P" +
            "iW6Qt9Jg7kcyVSWqpDgv2L6IVu1j-yGIR6s9S9PGaZoEkoqzx7D4G4I6h" +
            "Gft8miTzhnFP-oM9D-cmPOjdQfcLFiSOyOngQX9RGUcRlvejUxYH3Cv-zFq0p21N"; // Токен доступа к Dropbox API
        private DropboxFile _selectedItem; // Текущий выбранный элемент (файл или папка)
        private string _currentFolderPath; // Текущий путь к папке

        // Коллекция файлов и папок для отображения в списке
        public ObservableCollection<DropboxFile> Items { get; set; }

        // Свойство для выбранного элемента в списке
        public DropboxFile SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (_selectedItem != null && _selectedItem.IsDirectory)
                {
                    LoadDirectory(_selectedItem.Path); // Загрузка содержимого папки при выборе папки
                }
            }
        }

        // Текущий путь к папке
        public string CurrentFolderPath
        {
            get => _currentFolderPath;
            set
            {
                _currentFolderPath = value;
                OnPropertyChanged(nameof(CurrentFolderPath));
                OnPropertyChanged(nameof(DisplayCurrentFolderPath)); // Обновление отображаемого пути
            }
        }

        // Отображаемый текущий путь в формате "Gidsik.CiNsu.Razvald/.../название_папки"
        public string DisplayCurrentFolderPath => $"Gidsik.CiNsu.Razvald{_currentFolderPath}";

        // Команды для загрузки корневой папки и перехода назад
        public ICommand LoadRootCommand { get; }
        public ICommand BackCommand { get; }

        // Конструктор
        public MainWindowVM()
        {
            Items = new ObservableCollection<DropboxFile>();
            LoadRootCommand = new RelayCommand(async _ => await LoadRoot());
            BackCommand = new RelayCommand(Back);
        }

        // Метод для загрузки корневой папки
        private async Task LoadRoot()
        {
            CurrentFolderPath = string.Empty; // Установка пути как корневого
            Items.Clear(); // Очистка текущего списка элементов
            var rootItems = await ListFolderAsync(string.Empty); // Получение списка элементов корневой папки
            foreach (var item in rootItems)
            {
                Items.Add(item); // Добавление элементов в коллекцию для отображения
            }
        }

        // Метод для загрузки содержимого папки по заданному пути
        private async Task LoadDirectory(string path)
        {
            Items.Clear(); // Очистка текущего списка элементов
            var directoryItems = await ListFolderAsync(path); // Получение списка элементов папки
            foreach (var item in directoryItems)
            {
                Items.Add(item); // Добавление элементов в коллекцию для отображения
            }
        }

        // Метод для перехода назад по пути
        private void Back(object? parameters)
        {
            if (string.IsNullOrEmpty(CurrentFolderPath) || CurrentFolderPath == "/")
            {
                return; // Если путь пустой или корневой, выход из метода
            }

            var parts = CurrentFolderPath.Split('/'); // Разделение пути на части
            if (parts.Length <= 1)
            {
                CurrentFolderPath = string.Empty; // Если в пути только один элемент, установка его как корневого
            }
            else
            {
                CurrentFolderPath = string.Join("/", parts.Take(parts.Length - 1)); // Установка пути без последнего элемента
            }

            _ = LoadDirectory(CurrentFolderPath); // Загрузка содержимого папки по новому пути
        }

        // Метод для получения списка элементов папки из Dropbox API
        private async Task<ObservableCollection<DropboxFile>> ListFolderAsync(string path)
        {
            var items = new ObservableCollection<DropboxFile>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var content = new StringContent(
                    $"{{\"path\": \"{path}\", \"recursive\": false}}",
                    Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://api.dropboxapi.com/2/files/list_folder", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseContent);

                    foreach (var entry in json["entries"])
                    {
                        var item = new DropboxFile
                        {
                            Name = entry["name"].ToString(),
                            Path = entry["path_lower"].ToString(),
                            IsDirectory = entry[".tag"].ToString() == "folder"
                        };
                        items.Add(item);
                    }
                }
                else
                {
                    // Обработка ошибок
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorMessage}");
                }
            }
            return items;
        }
    }
}