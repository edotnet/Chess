using System.Linq;
using Chesss.Enums;

namespace Chesss.Models.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color color, Coordinate coordinate) : base(color, coordinate)
        {
        }

        public override bool Move(Coordinate to, Board board)
        {
            var res = base.Move(to, board);
            if (res) CanCastle = false;

            return res;
        }

        public bool CanCastle { get; private set; } = true;

        public override PieceType PieceType => PieceType.Rook;

        public override bool IsValidMove(Coordinate to, Board board)
        {
            if (!(Coordinate.X == to.X || Coordinate.Y == to.Y) || board[to]?.Color == Color || !IsInBoard(to)) return false;

            if (Coordinate.X == to.X)
            {
                var tempArr = new[] { Coordinate.Y, to.Y };
                var min = tempArr.Min();
                var max = tempArr.Max();

                for (int i = min + 1; i < max; i++)
                    if (board.Pieces[i][Coordinate.X] != null) return false;
            }
            else
            {
                var tempArr = new[] { Coordinate.X, to.X };
                var min = tempArr.Min();
                var max = tempArr.Max();

                for (int i = min + 1; i < max; i++)
                    if (board.Pieces[Coordinate.Y][i] != null) return false;
            }

            return true;
        }
    }
}
