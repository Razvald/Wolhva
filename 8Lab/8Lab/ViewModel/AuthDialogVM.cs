using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;

namespace _8Lab.ViewModel
{
    public class AuthDialogVM : ViewModelBase
    {
        private const string ClientId = "6gk00pajd0rfcq6";
        private const string ClientSecret = "vzouu8wc0dlyjic";

        private string _authorizationCode;

        public string AuthorizationCode
        {
            get => _authorizationCode;
            set
            {
                _authorizationCode = value;
                OnPropertyChanged(nameof(AuthorizationCode));
            }
        }

        public ICommand OpenAuthPageCommand { get; }
        public ICommand SubmitCommand { get; }

        public AuthDialogVM()
        {
            OpenAuthPageCommand = new RelayCommand(_ => OpenAuthorizationPage());
            SubmitCommand = new RelayCommand(async _ => await Submit(_));
        }

        public void OpenAuthorizationPage()
        {
            string authorizationUrl =
                $"https://www.dropbox.com/oauth2/authorize?" +
                $"client_id={ClientId}&response_type=code";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = authorizationUrl,
                UseShellExecute = true
            });
        }

        private async Task Submit(object? parameter)
        {
            if (!(parameter is Window window))
                return;

            var accessToken = await GetAccessTokenAsync(AuthorizationCode);
            if (!string.IsNullOrEmpty(accessToken))
            {
                AccessToken = accessToken;
                MessageBox.Show("Authorization successful!");
                window.DialogResult = true;
                window.Close();
            }
            else
            {
                MessageBox.Show("Authorization failed. Please try again.");
                window.DialogResult = true;
            }
        }

        private async Task<string> GetAccessTokenAsync(string authorizationCode)
        {
            using var httpClient = new HttpClient();
            var requestContent = new List<KeyValuePair<string, string>>
            {
                new("code", authorizationCode),
                new("grant_type", "authorization_code"),
                new("client_id", ClientId),
                new("client_secret", ClientSecret)
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://api.dropboxapi.com/oauth2/token")
            {
                Content = new FormUrlEncodedContent(requestContent)
            };

            var response = await httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadFromJsonAsync<OAuthTokenResponse>();
                return jsonResponse?.AccessToken ?? string.Empty;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {errorMessage}");
                return string.Empty;
            }
        }

        private class OAuthTokenResponse
        {
            public string AccessToken { get; set; }
        }

        public static string AccessToken { get; private set; } = string.Empty;
    }
}
