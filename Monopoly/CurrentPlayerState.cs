namespace Monopoly
{
    public class CurrentPlayerState : ICurrentPlayerState
    {
        public CurrentPlayerState(BoardSquare currentSquare)
        {
            CurrentSquare = currentSquare;
        }

        public BoardSquare CurrentSquare { get; private set; }
    }
}