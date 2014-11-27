using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    internal class CurrentGame : ICurrentGame
    {
        private readonly Queue<IPlayer> m_Players = new Queue<IPlayer>();
        private static readonly string[] s_Pieces = {"Dog", "Ship", "Top hat", "Racing car", "Iron", "Wheelbarrow"};

        public CurrentGame(int playerCount)
        {
            if (playerCount < 2 || playerCount > 6)
                throw new ArgumentOutOfRangeException("playerCount", "should be between 2 and 6");

            var pieces = new Queue<string>(s_Pieces);
            while (--playerCount >= 0)
            {
                var player = new Player(pieces.Dequeue());
                m_Players.Enqueue(player);
            }
        }

        public ICurrentGame TakeNextTurn(IDice dice)
        {
            throw new NotImplementedException();
        }

        public IPlayer NextPlayer { get { return m_Players.Peek(); } }
        public IEnumerable<IPlayer> Players { get { return m_Players; } }
    }
}