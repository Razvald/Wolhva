using _8Lab.Model;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;

namespace _8Lab.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly string _accessToken;
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

        public string DisplayCurrentFolderPath => $"Текущий путь: {CurrentFolderPath}";

        public ICommand BackCommand { get; }
        public ICommand ForwardCommand { get; }
        public ICommand DeleteSelectedFileCommand { get; }
        public ICommand DownloadFileCommand { get; }
        public ICommand UploadFileCommand { get; }

        public MainWindowVM(string accessToken)
        {
            _accessToken = accessToken;
            Items = [];
            LoadDirectory(string.Empty);
            BackCommand = new RelayCommand(Back);
            ForwardCommand = new RelayCommand(Forward);
            DeleteSelectedFileCommand = new RelayCommand(async _ => await DeleteSelectedFile());
            DownloadFileCommand = new RelayCommand(async _ => await DownloadFile());
            UploadFileCommand = new RelayCommand(async _ => await UploadFile());

            _currentFolderPath = "";
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

        private Stack<string> _backStack = new Stack<string>();
        private Stack<string> _forwardStack = new Stack<string>();

        private void Back(object? parameter)
        {
            if (string.IsNullOrEmpty(CurrentFolderPath) || CurrentFolderPath == "/")
            {
                return;
            }

            _forwardStack.Push(CurrentFolderPath);
            var parts = CurrentFolderPath.Split('/');
            if (parts.Length <= 1)
            {
                CurrentFolderPath = string.Empty;
            }
            else
            {
                CurrentFolderPath = string.Join("/", parts.Take(parts.Length - 1));
            }

            _backStack.Push(CurrentFolderPath);
            _ = LoadDirectory(CurrentFolderPath);
        }

        private void Forward(object? parameter)
        {
            if (_forwardStack.Count == 0) return;

            var nextPath = _forwardStack.Pop();
            _backStack.Push(CurrentFolderPath);
            CurrentFolderPath = nextPath;
            _ = LoadDirectory(CurrentFolderPath);
        }

        //private async Task UploadFile()
        //{
        //    var inputDialog = new InputDialog
        //    {
        //        DataContext = new InputDialogVM()
        //    };

        //    if (inputDialog.ShowDialog() == true)
        //    {
        //        var inputDialogVM = (InputDialogVM)inputDialog.DataContext;
        //        string fileName = inputDialogVM.ResponseText;

        //        using var httpClient = new HttpClient();
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

        //        var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes("Пример содержимого файла"));
        //        fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

        //        var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/upload")
        //        {
        //            Headers =
        //            {
        //                { "Dropbox-API-Arg",
        //                    $"{{\"path\": \"{_currentFolderPath}/{fileName}\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}}" }
        //            },
        //            Content = fileContent
        //        };

        //        var response = await httpClient.SendAsync(request);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonResponse = await response.Content.ReadAsStringAsync();
        //            MessageBox.Show($"{jsonResponse}\n");
        //            _ = LoadDirectory(CurrentFolderPath); // Refresh the directory after upload
        //        }
        //        else
        //        {
        //            var errorMessage = await response.Content.ReadAsStringAsync();
        //            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorMessage}");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Загрузка отменена.");
        //    }
        //}

        private async Task DownloadFile()
        {
            if (SelectedItem != null && !SelectedItem.IsDirectory)
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var downloadPath = SelectedItem.Path;
                var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/download")
                {
                    Headers =
                    {
                        { "Dropbox-API-Arg", $"{{\"path\":\"{downloadPath}\"}}" }
                    }
                };

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    // Чтение потока содержимого файла
                    var contentStream = await response.Content.ReadAsStreamAsync();

                    // Получение имени файла из пути (используется как предложение для сохранения файла)
                    var fileName = Path.GetFileName(downloadPath);

                    // Диалоговое окно для сохранения файла
                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        FileName = fileName,
                        Filter = "All Files (*.*)|*.*",
                        Title = "Сохранить файл"
                    };

                    // Открытие диалогового окна сохранения файла и сохранение, если пользователь согласен
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        // Открытие потока для записи содержимого файла
                        using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                        {
                            await contentStream.CopyToAsync(fileStream);
                        }
                        MessageBox.Show("Файл успешно сохранен.");
                    }
                    else
                    {
                        // Если пользователь отменил операцию сохранения
                        MessageBox.Show("Скачивание файла отменено.");
                    }
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка при скачивании файла: {errorMessage}");
                }
            }
        }

        private async Task DeleteSelectedFile()
        {
            if (SelectedItem != null)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить файл: {SelectedItem.Name}?",
                                             "Подтверждение удаления",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using var httpClient = new HttpClient();
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", _accessToken);

                    var responseJson = await httpClient.PostAsJsonAsync(
                        requestUri: "https://api.dropboxapi.com/2/files/delete_v2",
                        value: new
                        {
                            path = SelectedItem.Path.ToString()
                        }
                    );

                    if (responseJson.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Файл {SelectedItem.Name} удален.");
                        _ = LoadDirectory(CurrentFolderPath);
                    }
                    else
                    {
                        var errorMessage = await responseJson.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Request failed with status code {responseJson.StatusCode}: {errorMessage}");
                    }
                }
                else
                {
                    MessageBox.Show("Удаление отменено.");
                }
            }
        }

        private async Task UploadFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Выберите файл для загрузки",
                Filter = "All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var fileContent = new ByteArrayContent(File.ReadAllBytes(openFileDialog.FileName));
                var fileName = Path.GetFileName(openFileDialog.FileName);

                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/upload")
                {
                    Headers =
                {
                    { "Dropbox-API-Arg", $"{{\"path\": \"{CurrentFolderPath}/{fileName}\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}}" }
                },
                    Content = fileContent
                };

                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Файл успешно загружен на Dropbox.");
                    _ = LoadDirectory(CurrentFolderPath); // Обновление содержимого текущей папки
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка при загрузке файла на Dropbox: {errorMessage}");
                }
            }
        }

        private async Task<ObservableCollection<DropboxFile>> ListFolderAsync(string path)
        {
            var items = new ObservableCollection<DropboxFile>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var response = await httpClient
                    .PostAsJsonAsync(
                    requestUri: "https://api.dropboxapi.com/2/files/list_folder",
                    value: new
                    {
                        path
                    }
                );

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

                        if (!item.IsDirectory)
                        {
                            item.Size = entry["size"].Value<long>();
                            item.ModifiedDate = entry["client_modified"].Value<DateTime>();
                        }
                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}
