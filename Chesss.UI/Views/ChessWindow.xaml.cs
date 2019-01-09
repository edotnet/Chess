using Chesss.Models;
using Chesss.UI.ViewModels;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace Chesss.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для ChessWindow.xaml
    /// </summary>
    public partial class ChessWindow : Window
    {
        public ChessViewModel ViewModel { get; set; }
        private int clickCounter = 0;
        private Timer timer = new Timer(1000);

        public ChessWindow()
        {
            ViewModel = new ChessViewModel();
            DataContext = ViewModel;
            InitializeComponent();
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            clickCounter = 0;
        }

        private void Board_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (clickCounter > 3) return;

            Coordinate coord = GetCoordinate(e);

            if (ViewModel.Move.CanExecute(coord))
                ViewModel.Move.Execute(coord);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (clickCounter > 3) return;

            Coordinate coord = GetCoordinate(e);

            if (ViewModel.Move.CanExecute(coord))
                ViewModel.Move.Execute(coord);
        }

        private Coordinate GetCoordinate(MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(this);
            Coordinate coord = new Coordinate();

            Point p = board_grid.TranslatePoint(new Point(), Main);

            coord.Y = (int)((pos.Y - p.Y) / board_grid.ActualHeight * 8);
            coord.X = (int)((pos.X - p.X) / board_grid.ActualWidth * 8);

            return coord;
        }
    }
}
