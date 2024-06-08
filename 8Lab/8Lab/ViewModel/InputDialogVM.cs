using System.Windows;
using System.Windows.Input;

namespace _8Lab.ViewModel
{
    public class InputDialogVM : ViewModelBase
    {
        private string _responseText;
        public string ResponseText
        {
            get => _responseText;
            set
            {
                _responseText = value;
                OnPropertyChanged(nameof(ResponseText));
            }
        }

        public ICommand CancelCommand { get; }
        public ICommand ConfirmCommand { get; }

        public InputDialogVM()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Confirm(object? parameters)
        {
            if (parameters is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        private void Cancel(object? parameters)
        {
            if (parameters is Window window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
