using _6Lab.Models;
using _6Lab.Views;
using System.Windows;
using System.Windows.Input;

namespace _6Lab.ViewModels
{
    public class PeopleViewModelSimple
    {
        private List<PersonModelSimple> _people;
        private PersonModelSimple _selectedPerson;

        public PersonModelSimple SelectedPerson { get; set; }
        public List<PersonModelSimple> People
        {
            get => _people;
            set => _people = value;
        }

        public PeopleViewModelSimple()
        {
            _people =
            [
                new() { Id = 1, Name = "Asd", Description = "qwerty", DateOfBirth = new DateOnly(2000, 1, 2) },
                new() { Id = 2, Name = "Dsa", Description = "ytrewq", DateOfBirth = new DateOnly(2000, 2, 1) }
            ];
        }

        public ICommand ShowWindowCommand => new RelayCommand(ShowWindow);
        public ICommand ChangeItemCommand => new RelayCommand(ChangeItem);
        public ICommand PushNewItemCommand => new RelayCommand(PushNewItem);
        public ICommand PopLastItemCommand => new RelayCommand(PopLastItem);

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
            if (_selectedPerson != null)
            {
                var obj = _people.FirstOrDefault(x => x.Id == _selectedPerson.Id);
                if (obj != null
                    && obj.Name != _selectedPerson.Name
                    && obj.DateOfBirth != _selectedPerson.DateOfBirth
                    && obj.Description != _selectedPerson.Description)
                {
                    obj.Name = _selectedPerson.Name;
                    obj.DateOfBirth = _selectedPerson.DateOfBirth;
                    obj.Description = _selectedPerson.Description;
                    MessageBox.Show("Success");
                    return;
                }

                MessageBox.Show("Fail to update"); // Вот вроде бы я понял задание,
                                                   // однако при OneWay данные не приходят
                                                   // в _selectedPerson, а если будет TwoWay,
                                                   // то данные автоматически сохранятся...
            }
        }

        private void PushNewItem(object parameter)
        {
            PersonModelSimple newPerson = new();
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
    }
}
