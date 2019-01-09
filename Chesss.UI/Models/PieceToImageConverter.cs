using Chesss.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Chesss.UI.Models
{
    public class PieceToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var p = value as Piece;
            if (p == null) return null;

            return new BitmapImage(new Uri($"pack://application:,,,/Content/Pieces/Default/{p.Color}/{p.PieceType.ToString().ToLower()}.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
