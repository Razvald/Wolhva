using _4Lab.FormData;
using System.Windows;
using System.Windows.Controls;

namespace _4Lab.Controls
{
    public partial class MaterialView : UserControl
    {
        public MaterialView()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(MaterialView), new PropertyMetadata(0));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MaterialView), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(MaterialCustomControl), typeof(MaterialView), new PropertyMetadata(null));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        
        public MaterialCustomControl DataContext
        {
            get { return (MaterialCustomControl)GetValue(DataContextProperty); }
            set { SetValue(DataContextProperty, value); }
        }
    }
}
