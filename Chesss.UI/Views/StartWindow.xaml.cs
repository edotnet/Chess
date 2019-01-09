using Chesss.UI.ViewModels;
using System.Windows;

namespace Chesss.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            DataContext = new StartViewModel();
            InitializeComponent();
        }
    }
}
