namespace Monopoly
{
    internal class Player : IPlayer
    {
        public Player(string piece)
        {
            Name = piece;
        }

        public string Name { get; private set; }
    }
}