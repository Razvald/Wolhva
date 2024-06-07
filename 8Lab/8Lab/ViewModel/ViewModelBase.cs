// ViewModels/ViewModelBase.cs
using System.ComponentModel;

namespace _8Lab.ViewModel
{
    // Базовый класс для всех моделей представления (ViewModel)
    public class ViewModelBase : INotifyPropertyChanged
    {
        // Событие, уведомляющее об изменении свойства
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для вызова события изменения свойства
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
