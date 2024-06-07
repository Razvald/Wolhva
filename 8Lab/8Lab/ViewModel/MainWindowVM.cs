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
            LoadRootCommand = new RelayCommand(async _ => await LoadDirectory(string.Empty));
            BackCommand = new RelayCommand(Back);
        }

        // Метод для загрузки содержимого папки по заданному пути
        private async Task LoadDirectory(string path)
        {
            CurrentFolderPath = path;
            Items.Clear();
            var directoryItems = await ListFolderAsync(path);
            foreach (var item in directoryItems)
            {
                Items.Add(item);
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
            /// Этот метод возвращает ObservableCollection<DropboxFile>, 
            /// представляющую коллекцию файлов и папок в указанном пути. 
            /// Метод является асинхронным, поэтому использует ключевое слово async.
        {
            var items = new ObservableCollection<DropboxFile>();
            /// Создается пустая коллекция ObservableCollection<DropboxFile>, 
            /// в которую будут добавляться файлы и папки.
            using (var httpClient = new HttpClient())
            /// Создаётся экземпляр HttpClient, который будет 
            /// использоваться для выполнения HTTP-запроса к Dropbox API.
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                /// Устанавливается заголовок авторизации с типом Bearer и значением 
                /// _accessToken. Это необходимо для аутентификации запроса с 
                /// использованием токена доступа к Dropbox.
                var content = new StringContent(
                    $"{{\"path\": \"{path}\", \"recursive\": false}}",
                    Encoding.UTF8, "application/json");
                /// Создается объект StringContent, представляющий тело 
                /// запроса в формате JSON. Тело запроса содержит путь path 
                /// к каталогу, который нужно просмотреть, и параметр recursive, 
                /// установленный в false. Это означает, что содержимое будет 
                /// запрашиваться только для указанного каталога, без рекурсивного 
                /// просмотра вложенных папок.
                var response = await httpClient.PostAsync("https://api.dropboxapi.com/2/files/list_folder", content);
                /// Асинхронно отправляется POST-запрос к Dropbox 
                /// API по адресу https://api.dropboxapi.com/2/files/list_folder 
                /// с ранее созданным содержимым. Метод await используется 
                /// для ожидания завершения запроса без блокировки потока.
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(responseContent);
                    /// Если статус ответа указывает на успех 
                    /// (IsSuccessStatusCode равно true), содержимое 
                    /// ответа читается как строка и парсится в объект 
                    /// JObject для дальнейшей обработки.
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
                    /// Проходит итерация по всем элементам в массиве entries 
                    /// внутри JSON-ответа. Для каждого элемента создается 
                    /// объект DropboxFile, заполняются его свойства (имя, путь, тип), 
                    /// и этот объект добавляется в коллекцию items.
                }
                else
                {
                    // Обработка ошибок
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorMessage}");
                }
                /// Если статус ответа указывает на ошибку, содержимое 
                /// ответа читается как строка, и выбрасывается исключение 
                /// HttpRequestException с сообщением об ошибке, 
                /// включающим статусный код и содержимое ответа.
            }
            return items; // Возвращается заполненная коллекция ObservableCollection<DropboxFile>.
        }
    }
}
