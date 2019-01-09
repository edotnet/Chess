using Chesss.Enums;
using Chesss.Models;
using Chesss.Models.Pieces;

namespace Chesss.Infrastructure
{
    internal class StandardChessBuilder : IChessBuilder
    {
        public StandardChessBuilder() { }

        private Chess chess;

        public Chess Build()
        {
            return chess;
        }

        public void BuildBoard()
        {
            chess.Board = new Board()
            {
                Pieces = new Piece[][] {
                    new Piece[]
                    {
                        new Rook(Color.White,new Coordinate(0,0)), new Knight(Color.White,new Coordinate(1,0)),
                        new Bishop(Color.White,new Coordinate(2,0)), new King(Color.White,new Coordinate(3,0)),
                        new Queen(Color.White,new Coordinate(4,0)), new Bishop(Color.White,new Coordinate(5,0)),
                        new Knight(Color.White,new Coordinate(6,0)), new Rook(Color.White,new Coordinate(7,0))
                    },
                    new Piece[]
                    {
                        new Pawn(Color.White,new Coordinate(0,1)), new Pawn(Color.White,new Coordinate(1,1)),
                        new Pawn(Color.White,new Coordinate(2,1)), new Pawn(Color.White,new Coordinate(3,1)),
                        new Pawn(Color.White,new Coordinate(4,1)), new Pawn(Color.White,new Coordinate(5,1)),
                        new Pawn(Color.White,new Coordinate(6,1)), new Pawn(Color.White,new Coordinate(7,1))
                    },
                    new Piece[]
                    {
                        null,null,null,null,null,null,null,null
                    },
                    new Piece[]
                    {
                        null,null,null,null,null,null,null,null
                    },
                    new Piece[]
                    {
                        null,null,null,null,null,null,null,null
                    },
                    new Piece[]
                    {
                        null,null,null,null,null,null,null,null
                    },
                    new Piece[]
                    {
                        new Pawn(Color.Black,new Coordinate(0,6)), new Pawn(Color.Black,new Coordinate(1,6)),
                        new Pawn(Color.Black,new Coordinate(2,6)), new Pawn(Color.Black,new Coordinate(3,6)),
                        new Pawn(Color.Black,new Coordinate(4,6)), new Pawn(Color.Black,new Coordinate(5,6)),
                        new Pawn(Color.Black,new Coordinate(6,6)), new Pawn(Color.Black,new Coordinate(7,6))
                    },
                    new Piece[]
                    {
                        new Rook(Color.Black,new Coordinate(0,7)), new Knight(Color.Black,new Coordinate(1,7)),
                        new Bishop(Color.Black,new Coordinate(2,7)),new King(Color.Black,new Coordinate(3,7)),
                        new Queen(Color.Black,new Coordinate(4,7)), new Bishop(Color.Black,new Coordinate(5,7)),
                        new Knight(Color.Black,new Coordinate(6,7)), new Rook(Color.Black,new Coordinate(7,7))
                    }
                }
            };
        }

        public void CreateChess()
        {
            chess = new Chess();
        }
    }
}
