using System.Collections.Generic;

namespace Monopoly
{
    public interface ICurrentGame
    {
        ICurrentGame TakeTurn(IDice dice);
        IPlayer NextPlayer { get; }
        IEnumerable<IPlayer> Players { get; }
        ICurrentPlayerState GetCurrentState(IPlayer player);
    }
}