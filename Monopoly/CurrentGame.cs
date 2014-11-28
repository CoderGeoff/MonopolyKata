using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    internal class CurrentGame : ICurrentGame
    {
        private readonly Tuple<IPlayer, ICurrentPlayerState>[] m_PlayerStates;
        private static readonly string[] s_Pieces = {"Dog", "Ship", "Top hat", "Racing car", "Iron", "Wheelbarrow"};
        private readonly IPlayer m_NextPlayer;

        public CurrentGame(int playerCount)
        {
            if (playerCount < 2 || playerCount > 6)
                throw new ArgumentOutOfRangeException("playerCount", "should be between 2 and 6");

            m_PlayerStates = new Tuple<IPlayer, ICurrentPlayerState>[playerCount];
            var pieces = new Queue<string>(s_Pieces);
            for (int i = 0; i < playerCount; ++i)
            {
                var player = new Player(pieces.Dequeue());
                var playerState = new CurrentPlayerState(Board.TheBoard["Go"]);
                m_PlayerStates[i] = new Tuple<IPlayer, ICurrentPlayerState>(player, playerState);
                m_NextPlayer = m_NextPlayer ?? player;
            }
        }

        private CurrentGame(IPlayer nextPlayer, Tuple<IPlayer, ICurrentPlayerState>[] gameState)
        {
            m_NextPlayer = nextPlayer;
            m_PlayerStates = gameState;

        }

        public ICurrentGame TakeTurn(IDice dice)
        {
            var currentPlayer = m_NextPlayer;
            ICurrentPlayerState playerStateBeforeMove = GetCurrentState(currentPlayer);
            BoardSquare newSquare = Board.MoveFrom(playerStateBeforeMove.CurrentSquare, dice.Throw());
            var playerStateAfterMove = new CurrentPlayerState(newSquare);

            var gameStateAfterMove = CloneNewGameState(currentPlayer, playerStateAfterMove);
            IPlayer nextPlayer = GetPlayerAfter(currentPlayer);
            return new CurrentGame(nextPlayer, gameStateAfterMove);
        }

        private IPlayer GetPlayerAfter(IPlayer currentPlayer)
        {
            int nextIndex = m_PlayerStates.ToList().FindIndex(entry => entry.Item1 == currentPlayer) + 1;
            nextIndex = nextIndex == m_PlayerStates.Length ? 0 : nextIndex;
            return m_PlayerStates[nextIndex].Item1;
        }

        private Tuple<IPlayer, ICurrentPlayerState>[] CloneNewGameState(IPlayer changedPlayer, CurrentPlayerState changedState)
        {
            return m_PlayerStates.Select(ClonePlayerState(changedPlayer, changedState)).ToArray();
        }

        private static Func<Tuple<IPlayer, ICurrentPlayerState>, Tuple<IPlayer, ICurrentPlayerState>> ClonePlayerState(IPlayer changedPlayer, CurrentPlayerState changedState)
        {
            return entry => entry.Item1 == changedPlayer
                ? new Tuple<IPlayer, ICurrentPlayerState>(entry.Item1, changedState)
                : entry;
        }

        public ICurrentPlayerState GetCurrentState(IPlayer player)
        {
            return m_PlayerStates.First(entry => entry.Item1 == player).Item2;
        }

        public IPlayer NextPlayer { get { return m_NextPlayer; } }

        public IEnumerable<IPlayer> Players { get { return m_PlayerStates.Select(item => item.Item1); } }
    }
}