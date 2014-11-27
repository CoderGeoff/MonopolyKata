using System.Collections.Generic;

namespace Monopoly
{
    internal class Player : IPlayer
    {
        public Player(string piece)
        {
            Name = piece;
            CurrentSquare = new Board()["Go"];
        }

        public IEnumerable<string> Piece { get; private set; }
        public BoardSquare CurrentSquare { get; private set; }
        public string Name { get; private set; }
    }
}