using Chesss.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chesss.Models
{
    public class Board
    {
        public Piece[][] Pieces { get; set; }

        public IEnumerable<Piece> WhitePieces => Pieces.SelectMany(q => q.Where(w => w != null && w.Color == Color.White));
        public IEnumerable<Piece> BlackPieces => Pieces.SelectMany(q => q.Where(w => w != null && w.Color == Color.Black));

        public Piece this[Coordinate x]
        {
            get => Pieces[x.Y][x.X];
            set => Pieces[x.Y][x.X] = value;
        }

        public bool Move(Coordinate from, Coordinate to)
        {
            return this[from].Move(to, this);
        }

        public IEnumerable<Coordinate> GetValidCoordinates(Color color)
        {
            IEnumerable<Coordinate> result = new List<Coordinate>();

            foreach (var item in Pieces)
            {
                var pieces = item.Where(q => q != null && q.Color == color);
                foreach (var piece in pieces)
                {
                    var cur =  piece.GetValidMoves(this);
                    result = result.Concat(cur);
                }
            }

            return result;
        }
    }
}
