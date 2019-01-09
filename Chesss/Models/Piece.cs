using Chesss.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chesss.Models
{
    public abstract class Piece : INotifyPropertyChanged
    {
        private Coordinate coordinate;

        public Coordinate Coordinate
        {
            get { return coordinate; }
            set {
                coordinate = value;
                OnPropertyChanged(nameof(Coordinate));
            }
        }

        public Color Color { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract PieceType PieceType { get; }
        public abstract bool IsValidMove(Coordinate to, Board board);

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Piece(Color color, Coordinate coordinate)
        {
            Color = color;
            Coordinate = coordinate;
        }

        public IEnumerable<Coordinate> GetValidMoves(Board board)
        {
            var result = new List<Coordinate>();
            Coordinate temp = new Coordinate();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    temp.X = i;
                    temp.Y = j;
                    if (IsValidMove(temp, board) && !IsInCheck(board))
                    {
                        result.Add(temp);
                    }
                }
            }

            return result;
        }

        public virtual bool Move(Coordinate to, Board board)
        {
            if (to == Coordinate || !IsValidMove(to, board))
                return false;

            var temp = board.Pieces[to.Y][to.X]?.MemberwiseClone();
            board.Pieces[to.Y][to.X] = this;
            board.Pieces[Coordinate.Y][Coordinate.X] = null;

            if(IsInCheck(board))
            {
                board.Pieces[to.Y][to.X] = (Piece)temp;
                board.Pieces[Coordinate.Y][Coordinate.X] = this;
                return false;
            }

            Coordinate = to;

            return true;
        }

        public bool IsInBoard(Coordinate position)
        {
            return position.X >= 0 && position.X <= 8 && position.Y >= 0 && position.Y <= 8;
        }

        public virtual bool IsInCheck(Board board)
        {
            Piece king = null;
            foreach (var item in board.Pieces)
            {
                king = item.FirstOrDefault(q => q != null && q.PieceType == PieceType.King && q.Color == Color);
                if (king != null) break;
            }

            Color temp = Color.ReverseColor();

            foreach (var item in board.Pieces)
            {
                var fig = item.FirstOrDefault(q => q != null && q.Color == temp && q.PieceType != PieceType.King && q.IsValidMove(king.Coordinate, board));
                if (fig != null)  return true;
            }

            return false;
        }
    }
}
