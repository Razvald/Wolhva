using _6Lab.Models;
using _6Lab.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace _6Lab.ViewModels
{
    public class PeopleViewModelMVVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<PersonModelMVVM> _people =
        [
            new() { Id = 1, Name = "Asd", Description = "qwerty", DateOfBirth = new DateOnly(2000, 1, 2) },
            new() { Id = 2, Name = "Dsa", Description = "ytrewq", DateOfBirth = new DateOnly(2000, 2, 1) }
        ];
        private PersonModelMVVM _selectedPerson;

        public ObservableCollection<PersonModelMVVM> People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged();
            }
        }

        public PersonModelMVVM SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowWindowCommand => new RelayCommand(ShowWindow);
        public ICommand ChangeItemCommand => new RelayCommand(ChangeItem);
        public ICommand PushNewItemCommand => new RelayCommand(PushNewItem);
        public ICommand PopLastItemCommand => new RelayCommand(PopLastItem);
        public ICommand ResetProcessCommand => new RelayCommand(ResetProcess);
        public ICommand BeginProcessCommand => new RelayCommand(BeginProcess);
        public ICommand StopProcessCommand => new RelayCommand(StopProcess);

        private void ShowWindow(object parameter)
        {
            MainWindow mainWindow = new()
            {
                DataContext = this
            };
            mainWindow.Show();
        }

        private void ChangeItem(object parameter)
        {
            // Вообще нет необходимости, так как данные обновляются напрямую,
            // конечно только если не делать все через еще одну переменную, чтобы обновлялась
            // только временная, а данные изначальные были в исходном, которые только после
            // нажатия кнопки бы изменяли исходную, но это слишком
        }

        private void PushNewItem(object parameter)
        {
            PersonModelMVVM newPerson = new();
            People.Add(newPerson);
            SelectedPerson = newPerson;
        }

        private void PopLastItem(object parameter)
        {
            if (People.Count > 0)
            {
                var lastPerson = People[People.Count - 1];
                People.Remove(lastPerson);
            }
        }

        private void BeginProcess(object parameter)
        {
            SelectedPerson?.BeginProcess();
        }

        private void ResetProcess(object parameter)
        {
            SelectedPerson?.ResetProcessAsync();
        }

        private void StopProcess(object parameter)
        {
            SelectedPerson?.StopProcess();
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
