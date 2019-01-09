using System;
using Chesss.Enums;

namespace Chesss.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, Coordinate coordinate) : base(color, coordinate)
        {
        }

        public override PieceType PieceType => PieceType.Knight;

        public override bool IsValidMove(Coordinate to, Board board)
        {
            if (Math.Abs(Coordinate.X - to.X) + Math.Abs(Coordinate.Y - to.Y) != 3 || Coordinate.X == to.X || Coordinate.Y == to.Y ||
                 board[to]?.Color == Color || !IsInBoard(to)) return false;

            return true;
        }
    }
}
