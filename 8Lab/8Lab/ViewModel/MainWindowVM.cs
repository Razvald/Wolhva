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
            "Gft8miTzhnFP-oM9D-cmPOjdQfcLFiSOyOngQX9RGUcRlvejUxYH3Cv-zFq0p21N";
        private DropboxFile _selectedItem;

        public ObservableCollection<DropboxFile> Items { get; set; }

        public DropboxFile SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                if (_selectedItem != null && _selectedItem.IsDirectory)
                {
                    LoadDirectory(_selectedItem.Path);
                }
            }
        }

        public ICommand LoadRootCommand { get; }

        public MainWindowVM()
        {
            Items = new ObservableCollection<DropboxFile>();
            LoadRootCommand = new RelayCommand(async _ => await LoadRoot());
        }

        private async Task LoadRoot()
        {
            Items.Clear();
            var rootItems = await ListFolderAsync(string.Empty);
            foreach (var item in rootItems)
            {
                Items.Add(item);
            }
        }

        private async Task LoadDirectory(string path)
        {
            Items.Clear();
            var directoryItems = await ListFolderAsync(path);
            foreach (var item in directoryItems)
            {
                Items.Add(item);
            }
        }

        private async Task<ObservableCollection<DropboxFile>> ListFolderAsync(string path)
        {
            var items = new ObservableCollection<DropboxFile>();
            
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
                
                var content = new StringContent(
                    $"{{\"path\": \"{path}\", \"recursive\": false}}"
                    , Encoding.UTF8, "application/json");
                
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











        /*

        private readonly string _accessToken = "sl.B2QvT5h17uMtla71pPE-0gWYTw" +
            "nckCy0tQyscpCBWw1vNL4K_AhLcyDPcJOaKVJRhg5mjPVpjKFRZGnGJ16xQ3DDR7" +
            "tyPrXCzcIF4FVC8iox_tCIsOdfyx-vMKbxDq2WGXoxTUGOGjic";
        private readonly DropboxClient _dropboxClient;

        public ObservableCollection<DropboxFile> Files { get; set; }
        public DropboxFile SelectedFile { get; set; }

        public ICommand LoadCommand { get; }
        public ICommand OpenFolderCommand { get; }
        public ICommand BackCommand { get; }

        private string _currentFolderPath;
        public string CurrentFolderPath
        {
            get => _currentFolderPath;
            set
            {
                _currentFolderPath = value;
                OnPropertyChanged(nameof(CurrentFolderPath));
            }
        }

        public string DisplayCurrentFolderPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentFolderPath))
                {
                    return "/";
                }
                else
                {
                    return CurrentFolderPath;
                }
            }
        }

        public MainWindowVM()
        {
            Files = new ObservableCollection<DropboxFile>();
            _dropboxClient = new DropboxClient(_accessToken);
            LoadCommand = new RelayCommand(async _ => await LoadFilesAsync());
            OpenFolderCommand = new RelayCommand(_ => OpenFolderAsync());
            BackCommand = new RelayCommand(_ => GoBack());
        }

        private async Task LoadFilesAsync(string path = "")
        {
            try
            {
                CurrentFolderPath = path; // Устанавливаем новый путь
                Files.Clear(); // Очищаем список файлов
                var list = await _dropboxClient.Files.ListFolderAsync(path);

                foreach (var item in list.Entries)
                {
                    Files.Add(new DropboxFile
                    {
                        Name = item.Name,
                        IsFolder = item.IsFolder,
                        PathLower = item.PathLower
                    });
                }

                OnPropertyChanged(nameof(Files)); // Уведомляем об изменении списка файлов
                OnPropertyChanged(nameof(DisplayCurrentFolderPath)); // Уведомляем об изменении отображаемого пути
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading files: {ex.Message}");
            }
        }


        private async Task OpenFolderAsync()
        {
            try
            {
                if (SelectedFile != null && SelectedFile.IsFolder)
                {
                    await LoadFilesAsync(SelectedFile.PathLower);
                }
                else
                {
                    MessageBox.Show("Please select a folder to open.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening folder: {ex.Message}");
            }
        }

        private void GoBack()
        {
            if (string.IsNullOrEmpty(CurrentFolderPath))
            {
                return;
            }

            string[] parts = CurrentFolderPath.Split('/');

            if (parts.Length <= 1)
            {
                CurrentFolderPath = "";
            }
            else
            {
                // Собираем путь, исключая последнюю часть
                CurrentFolderPath = string.Join("/", parts.Take(parts.Length - 1));
            }

            LoadFilesAsync(CurrentFolderPath);
            OnPropertyChanged(nameof(DisplayCurrentFolderPath));
        }*/
    }
}
