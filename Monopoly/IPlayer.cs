namespace Monopoly
{
    public interface IPlayer
    {
        BoardSquare CurrentSquare { get; }
        string Name { get; }
    }
}