using Chesss.Enums;
using System;

namespace Chesss.Models.Pieces
{
    public class Pawn : Piece
    {
        private bool isFirstMove = true;
        private int startLeftEnemyY, startRightEnemyY, finalLeftEnemyY, finalRightEnemyY;


        public Pawn(Color color, Coordinate coordinate) : base(color, coordinate)
        {
            if (coordinate.X == 0)
            {

            }
        }

        public override PieceType PieceType => PieceType.Pawn;

        public override bool Move(Coordinate to, Board board)
        {
            var res = base.Move(to,board);
            if(res) isFirstMove = false;

            return res;
        }

        private bool AvailableDiagonalMoves(Coordinate to, Board board)
        {
            if (board[to]?.Color == Color.ReverseColor()) return true;
            return false;
        }

        public override bool IsValidMove(Coordinate to, Board board)
        {
            if (to.X != Coordinate.X)
            {
                var xDif = Math.Abs(to.X - Coordinate.X) == 1;
                if (xDif && Color == Color.Black && to.Y == Coordinate.Y - 1) return AvailableDiagonalMoves(to, board);
                else if (xDif && Color == Color.White && to.Y == Coordinate.Y + 1) return AvailableDiagonalMoves(to, board);
            }

            if (board[to] != null) return false;

            if (isFirstMove)
            {
                if (Color == Color.Black)
                    return to.X == Coordinate.X && to.Y < Coordinate.Y && Coordinate.Y - to.Y <= 2;

                return to.X == Coordinate.X && to.Y > Coordinate.Y && to.Y - Coordinate.Y <= 2;
            }

            if (Color == Color.Black)
                return to.X == Coordinate.X && to.Y < Coordinate.Y && Coordinate.Y - to.Y == 1;

            return to.X == Coordinate.X && to.Y > Coordinate.Y && to.Y - Coordinate.Y == 1;
        }

        public T Promotion<T>(T piece) where T : Piece
        {
            return Activator.CreateInstance(typeof(T), new { piece.Color, piece.Coordinate }) as T;
        }
    }
}
