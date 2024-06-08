﻿using _8Lab.Model;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;

namespace _8Lab.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly string _accessToken = "sl.B2v3r9aVBrI2Stk_CivJnpDbNyiu74zCQcxujBp" +
            "detp9IWeEZe9ttlXE7YArFV-wGvXBwjGZlpImpK0nQlKg1i0MGBsgy2kzGp7M5VatTJ5kRhY08vcu" +
            "KU2uuLzhMvArvdPclONfbrMD6_kbkHymvhM";
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
        public ICommand DeleteSelectedFileCommand { get; }
        public ICommand UploadFileCommand { get; }

        public MainWindowVM()
        {
            Items = new ObservableCollection<DropboxFile>();
            LoadRootCommand = new RelayCommand(async _ => await LoadDirectory(string.Empty));
            BackCommand = new RelayCommand(Back);
            DeleteSelectedFileCommand = new RelayCommand(async _ => await DeleteSelectedFile());
            UploadFileCommand = new RelayCommand(async _ => await UploadFile());
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

        private async Task UploadFile()
        {

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var responseJson = await httpClient.PostAsJsonAsync(
                requestUri: "https://content.dropboxapi.com/2/files/upload",
                value: new
                {
                    autorename = true,
                    path = _currentFolderPath
                }
            );
        }

        private async Task DeleteSelectedFile()
        {
            var result = MessageBox.Show($"Вы уверены, что хотите удалить файл: {SelectedItem.Name}?",
                                         "Подтверждение удаления",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

                var responseJson = await httpClient.PostAsJsonAsync(
                    requestUri: "https://api.dropboxapi.com/2/files/delete_v2",
                    value: new
                    {
                        path = SelectedItem.Path.ToString()
                    }
                );

                if (responseJson.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseJson.Content.ReadAsStringAsync();
                    MessageBox.Show($"{jsonResponse}\n");
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
                        path,
                        recursive = false
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
