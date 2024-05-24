using System.Windows;

namespace _7Lab.Services.Interfaces
{
    public interface IViewsManager
    {
        Window Current { get; }
        void Open<TView>(object? dataContext = null) where TView : Window;
    }
}
