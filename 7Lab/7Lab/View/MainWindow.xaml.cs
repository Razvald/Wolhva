using _7Lab.Model.Database;
using _7Lab.ViewModel;
using System.Windows;

namespace _7Lab.View
{
    public partial class MainWindow : Window
    {
        public MainWindow(AppDbContext dbContext)
        {
            InitializeComponent();
            DataContext = new MainVM(dbContext);
        }
    }
}