using System;
using System.Linq;
using Chesss.Enums;

namespace Chesss.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Coordinate coordinate) : base(color, coordinate)
        {
        }

        public override PieceType PieceType => PieceType.Bishop;

        public override bool IsValidMove(Coordinate to, Board board)
        {
            if (!(Math.Abs(Coordinate.X - to.X) == Math.Abs(Coordinate.Y - to.Y)) || board[to]?.Color == Color || !IsInBoard(to)) return false;

            var tempArr = new[] { Coordinate, to }.OrderBy(q=>q.Y).ToArray();
            var min = tempArr.Min(q => q.Y);
            var max = tempArr.Max(q => q.Y);

            if (tempArr[0].X < tempArr[1].X)
            {
                for (int i = min + 1, temp = tempArr[0].X + 1; i < max; i++, temp++)
                    if (board.Pieces[i][temp] != null) return false;
            }

            else
            {
                for (int i = min + 1, temp = tempArr[0].X - 1; i < max; i++, temp--)
                    if (board.Pieces[i][temp] != null) return false;
            }

            return true;
        }
    }
}
