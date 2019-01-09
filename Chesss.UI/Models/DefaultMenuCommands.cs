using System.Windows;
using System.Windows.Input;

namespace Chesss.UI.Models
{
    public class DefaultMenuCommands : IMenuCommands
    {
        private ICommand _close;

        public ICommand Close
        {
            get
            {
                if (_close == null) _close = new RelayCommand(ExecuteClose, (param) => true);

                return _close;
            }
            set => _close = value;
        }

        private void ExecuteClose(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
