using Chesss.UI.Models;
using Chesss.UI.Views;
using System.Windows;
using System.Windows.Input;

namespace Chesss.UI.ViewModels
{
    public class StartViewModel
    {
        private ICommand _newGame;
        public ICommand NewGame
        {
            get
            {
                if (_newGame == null) _newGame = new RelayCommand(Execute, (param) => true);

                return _newGame;
            }
            set => _newGame = value;
        }

        private void Execute(object parameter)
        {
            Application.Current.MainWindow.Hide();
            new ChessWindow().Show();
        }
    }
}
