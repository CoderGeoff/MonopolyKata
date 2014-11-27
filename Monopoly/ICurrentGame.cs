using System.Collections.Generic;

namespace Monopoly
{
    public interface ICurrentGame
    {
        ICurrentGame TakeNextTurn(IDice dice);
        IPlayer NextPlayer { get; }
        IEnumerable<IPlayer> Players { get; }
    }
}