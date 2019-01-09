using Chesss.Enums;
using Chesss.Infrastructure;
using Chesss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesss
{
    public class Chess
    {
        private Piece whiteKing;
        private Piece blackKing;
        private Piece currentKing => Turn == Color.White ? blackKing : whiteKing;
        private Piece kingOnTurn => Turn == Color.White ? whiteKing : blackKing;
        private Color nextTurn => Turn == Color.White ? Color.Black : Color.White;
        private int moveCounter = 0;

        public Dictionary<int, Tuple<string, string>> Moves { get; set; } = new Dictionary<int, Tuple<string, string>>();
        public Board Board { get; internal set; }
        public Color Turn { get; set; }
        public GameState State { get; internal set; } = GameState.None;

        public Chess(Board board = null)
        {
            Board = board;

            if (board != null)
                foreach (var item in board.Pieces)
                {
                    whiteKing = item.FirstOrDefault(q => q != null && q.PieceType == PieceType.King && q.Color == Color.White);
                    blackKing = item.FirstOrDefault(q => q != null && q.PieceType == PieceType.King && q.Color == Color.Black);
                }
        }

        private string MoveName(Coordinate from, Coordinate to)
        {
            return (Board[to].PieceType.ToString()[0] + ((char)('a' + from.X)) + from.Y + ((char)('a' + from.Y))).ToString();
        }

        public bool Move(Coordinate from, Coordinate to)
        {
            if (Board[from].Color != Turn) return false;
            if (Board.Move(from, to))
            {
                Turn = nextTurn;
                if (nextTurn == Color.White) Moves.Add(moveCounter, new Tuple<string, string>(MoveName(from, to), null));
                else Moves[moveCounter] = new Tuple<string, string>(Moves[moveCounter++].Item1, MoveName(from, to));

                if (Board.GetValidCoordinates(Turn).Count() == 0)
                {
                    if (Turn == Color.White) State = GameState.WhiteWins;
                    else State = GameState.BlackWins;

                }

                else if (currentKing.IsInCheck(Board))
                {
                    if (Turn == Color.White) State = GameState.BlackChecked;
                    else State = GameState.WhiteChecked;
                }

                return true;
            }
            return false;
        }

        public static Chess CreateChess(IChessBuilder builder)
        {
            Chess result;

            builder.CreateChess();
            builder.BuildBoard();
            result = builder.Build();

            foreach (var item in result.Board.Pieces)
            {
                if (result.whiteKing == null) result.whiteKing = item.FirstOrDefault(q => q != null && q.PieceType == PieceType.King && q.Color == Color.White);
                if (result.blackKing == null) result.blackKing = item.FirstOrDefault(q => q != null && q.PieceType == PieceType.King && q.Color == Color.Black);
            }

            return result;
        }

        public static Chess CreateChess()
        {
            var builder = new StandardChessBuilder();
            Chess result;

            builder.CreateChess();
            builder.BuildBoard();
            result = builder.Build();

            foreach (var item in result.Board.Pieces)
            {
                if (result.whiteKing == null) result.whiteKing = item.FirstOrDefault(q => q != null && q.PieceType == PieceType.King && q.Color == Color.White);
                if (result.blackKing == null) result.blackKing = item.FirstOrDefault(q => q != null && q.PieceType == PieceType.King && q.Color == Color.Black);
            }

            return result;
        }
    }
}
