namespace Chesss.Infrastructure
{
    public interface IChessBuilder
    {
        void CreateChess();
        void BuildBoard();
        Chess Build();
    }
}
