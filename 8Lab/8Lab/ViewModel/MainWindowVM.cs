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
        private readonly string _accessToken = "sl.B2uJUjysrHW-Y7L5bhdC" +
            "gqkVvjszYeqwvPc9DT89GS8KQ2dXos6cPIy2dBpwwCQsxmqN-2amoyl_Cj" +
            "HHK_4z3tF-Bst7DHkt_G5YXFQ_HojpI4MYgXbvOoV2xHp6w1Yf5vzLGKj_" +
            "hfXCJBdmgXYSs6g";
        private DropboxFile _selectedItem;
        private string _currentFolderPath;

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

        public string CurrentFolderPath
        {
            get => _currentFolderPath;
            set
            {
                _currentFolderPath = value;
                OnPropertyChanged(nameof(CurrentFolderPath));
                OnPropertyChanged(nameof(DisplayCurrentFolderPath));
            }
        }

        public string DisplayCurrentFolderPath => $"Текущий путь: //Gidsik.CiNsu.Razvald{_currentFolderPath}";

        public ICommand LoadRootCommand { get; }
        public ICommand BackCommand { get; }
        //public ICommand DeleteSelectedFileCommand { get; }

        public MainWindowVM()
        {
            Items = new ObservableCollection<DropboxFile>();
            LoadRootCommand = new RelayCommand(async _ => await LoadDirectory(string.Empty));
            BackCommand = new RelayCommand(Back);
            //DeleteSelectedFileCommand = new RelayCommand(async _ => await );
        }

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

        private void Back(object? parameters)
        {
            if (string.IsNullOrEmpty(CurrentFolderPath) || CurrentFolderPath == "/")
            {
                return;
            }

            var parts = CurrentFolderPath.Split('/');
            if (parts.Length <= 1)
            {
                CurrentFolderPath = string.Empty;
            }
            else
            {
                CurrentFolderPath = string.Join("/", parts.Take(parts.Length - 1));
            }

            _ = LoadDirectory(CurrentFolderPath);
        }

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
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorMessage}");
                }

            }
            return items;
        }
    }
}
