using _8Lab.Model;
using Dropbox.Api;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace _8Lab.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
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
        }
    }
}
