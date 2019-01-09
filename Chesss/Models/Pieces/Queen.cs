using System;
using System.Linq;
using Chesss.Enums;

namespace Chesss.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Coordinate coordinate) : base(color, coordinate)
        {
        }

        public override PieceType PieceType => PieceType.Queen;

        public override bool IsValidMove(Coordinate to, Board board)
        {
            bool isCrossMove = Coordinate.X == to.X || Coordinate.Y == to.Y;
            bool isDiagonalMove = Math.Abs(Coordinate.X - to.X) == Math.Abs(Coordinate.Y - to.Y);

            if (!isCrossMove && !isDiagonalMove || board[to]?.Color == Color || !IsInBoard(to)) return false;

            if (isCrossMove)
            {
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
            }
            else if (isDiagonalMove)
            {
                var tempArr = new[] { Coordinate, to }.OrderBy(q => q.Y).ToArray();
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
            }

            return true;
        }
    }
}
