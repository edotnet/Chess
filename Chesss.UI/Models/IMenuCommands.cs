using System.Windows.Input;

namespace Chesss.UI.Models
{
    public interface IMenuCommands
    {
        ICommand Close { get; set; }
    }
}
