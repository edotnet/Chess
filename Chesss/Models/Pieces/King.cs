using Chesss.Enums;
using System;
using System.Linq;

namespace Chesss.Models.Pieces
{
    public class King : Piece
    {
        public bool CanCastle { get; private set; } = true;

        public override PieceType PieceType => PieceType.King;

        public King(Color color, Coordinate coordinate) : base(color, coordinate)
        {
        }

        public override bool IsValidMove(Coordinate to, Board board)
        {
            if (CanCastle && board[to] == null && Math.Abs(Coordinate.X - to.X) == 2 && Math.Abs(Coordinate.Y - to.Y) == 0)
            {
                return true;
            }

            if (!(Math.Abs(Coordinate.X - to.X) <= 1 && Math.Abs(Coordinate.Y - to.Y) <= 1) ||
                board[to]?.Color == Color || !IsInBoard(to)) return false;

            return true;
        }

        public override bool Move(Coordinate to, Board board)
        {
            if (to == Coordinate || !IsValidMove(to, board)) return false;

            if (Math.Abs(Coordinate.X - to.X) == 2)
                if (to.X - Coordinate.X > 0)
                {
                    if (board.Pieces[to.Y][7] is Rook rook && rook.CanCastle)
                        rook.Move(new Coordinate(4, to.Y), board);
                }
                else
                {
                    if (board.Pieces[to.Y][0] is Rook rook && rook.CanCastle)
                        rook.Move(new Coordinate(2, to.Y), board);
                }

            var tempCoordinate = Coordinate;
            var temp = board.Pieces[to.Y][to.X];
            board.Pieces[to.Y][to.X] = this;
            board.Pieces[Coordinate.Y][Coordinate.X] = null;
            Coordinate = to;

            if (IsInCheck(board))
            {
                board.Pieces[to.Y][to.X] = temp;
                Coordinate = tempCoordinate;
                board.Pieces[Coordinate.Y][Coordinate.X] = this;
                return false;
            }

            CanCastle = false;
            return true;
        }
    }
}
