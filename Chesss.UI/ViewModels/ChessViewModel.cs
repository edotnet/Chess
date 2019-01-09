using Chesss.Models;
using Chesss.UI.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Chesss.UI.ViewModels
{
    public class ChessViewModel
    {
        private static Chess chess = Chess.CreateChess();
        private Piece _selectedPiece;

        public ObservableCollection<Piece> Bindings { get; set; }
        public ICommand Move { get; private set; }
        public IMenuCommands Menu { get; set; } = new DefaultMenuCommands();
        public string PieceSet { get; set; } = "Default";

        #region Pieces for bindings
        private Piece WhiteLeftRook;
        private Piece WhiteLeftKnight;
        private Piece WhiteLeftBishop;
        private Piece WhiteKing;
        private Piece WhiteQueen;
        private Piece WhiteRightBishop;
        private Piece WhiteRightKnight;
        private Piece WhiteRightRook;
        private Piece WhitePawn1;
        private Piece WhitePawn2;
        private Piece WhitePawn3;
        private Piece WhitePawn4;
        private Piece WhitePawn5;
        private Piece WhitePawn6;
        private Piece WhitePawn7;
        private Piece WhitePawn8;

        private Piece BlackLeftRook;
        private Piece BlackLeftKnight;
        private Piece BlackLeftBishop;
        private Piece BlackKing;
        private Piece BlackQueen;
        private Piece BlackRightBishop;
        private Piece BlackRightKnight;
        private Piece BlackRightRook;
        private Piece BlackPawn1;
        private Piece BlackPawn2;
        private Piece BlackPawn3;
        private Piece BlackPawn4;
        private Piece BlackPawn5;
        private Piece BlackPawn6;
        private Piece BlackPawn7;
        private Piece BlackPawn8;
        #endregion

        public ChessViewModel()
        {

            #region White Pieces Initialization
            WhiteLeftRook = chess.Board.WhitePieces.ToArray()[0];
            WhiteLeftKnight = chess.Board.Pieces[0][1];
            WhiteLeftBishop = chess.Board.Pieces[0][2];
            WhiteKing = chess.Board.Pieces[0][3];
            WhiteQueen = chess.Board.Pieces[0][4];
            WhiteRightBishop = chess.Board.Pieces[0][5];
            WhiteRightKnight = chess.Board.Pieces[0][6];
            WhiteRightRook = chess.Board.Pieces[0][7];
            WhitePawn1 = chess.Board.Pieces[1][0];
            WhitePawn2 = chess.Board.Pieces[1][1];
            WhitePawn3 = chess.Board.Pieces[1][2];
            WhitePawn4 = chess.Board.Pieces[1][3];
            WhitePawn5 = chess.Board.Pieces[1][4];
            WhitePawn6 = chess.Board.Pieces[1][5];
            WhitePawn7 = chess.Board.Pieces[1][6];
            WhitePawn8 = chess.Board.Pieces[1][7];
            #endregion
            #region Black Pieces Initialization
            BlackLeftRook = chess.Board.Pieces[7][0];
            BlackLeftKnight = chess.Board.Pieces[7][1];
            BlackLeftBishop = chess.Board.Pieces[7][2];
            BlackKing = chess.Board.Pieces[7][3];
            BlackQueen = chess.Board.Pieces[7][4];
            BlackRightBishop = chess.Board.Pieces[7][5];
            BlackRightKnight = chess.Board.Pieces[7][6];
            BlackRightRook = chess.Board.Pieces[7][7];
            BlackPawn1 = chess.Board.Pieces[6][0];
            BlackPawn2 = chess.Board.Pieces[6][1];
            BlackPawn3 = chess.Board.Pieces[6][2];
            BlackPawn4 = chess.Board.Pieces[6][3];
            BlackPawn5 = chess.Board.Pieces[6][4];
            BlackPawn6 = chess.Board.Pieces[6][5];
            BlackPawn7 = chess.Board.Pieces[6][6];
            BlackPawn8 = chess.Board.Pieces[6][7];
            #endregion

            Bindings = new ObservableCollection<Piece>()
            {
                WhiteLeftRook,WhiteLeftKnight,WhiteLeftBishop,WhiteKing,WhiteQueen,WhiteRightBishop,WhiteRightKnight,WhiteRightRook,
                WhitePawn1,WhitePawn2,WhitePawn3,WhitePawn4,WhitePawn5,WhitePawn6,WhitePawn7,WhitePawn8,
                BlackLeftRook,BlackLeftKnight,BlackLeftBishop,BlackKing,BlackQueen,BlackRightBishop,BlackRightKnight,BlackRightRook,
                BlackPawn1,BlackPawn2,BlackPawn3,BlackPawn4,BlackPawn5,BlackPawn6,BlackPawn7,BlackPawn8
            };

            Move = new RelayCommand(Execute, CanExecute);
        }

        public bool CanExecute(object parameter)
        {
            Coordinate coordinate = (Coordinate)parameter;
            Piece piece = null;

            foreach (var item in chess.Board.Pieces)
            {
                piece = item.FirstOrDefault(q => q != null && q.Coordinate == coordinate);
                if (piece != null) break;
            }

            if (_selectedPiece == null)
            {
                _selectedPiece = piece;
                if (_selectedPiece != null) _selectedPiece = _selectedPiece.Color == chess.Turn ? _selectedPiece : null;

                return false;
            }

            return true;
        }

        public void Execute(object parameter)
        {
            Coordinate c = (Coordinate)parameter;

            if (chess.Move(_selectedPiece.Coordinate, c))
            {
                Bindings.Remove(Bindings.FirstOrDefault(q => q.Color == chess.Turn && q.Coordinate == c));
            }

            _selectedPiece = null;
        }
    }
}