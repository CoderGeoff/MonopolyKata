using System.Collections.Generic;
using System.IO;

namespace Monopoly
{
    public interface ICurrentGame
    {
        ICurrentGame TakeNextTurn(IDice dice);
        IPlayer NextPlayer { get; }
        IEnumerable<IPlayer> Players { get; }
    }

    public interface IDice
    {
        int Throw();
    }

    public interface IPlayer
    {
        BoardSquare CurrentSquare { get; }
        string Name { get; }
    }

    public class BoardState
    {

    }

    public class CurrentGameWriter
    {
        private readonly StreamWriter m_Writer;

        public CurrentGameWriter(StreamWriter writer)
        {
            m_Writer = writer;
        }

        void Write(ICurrentGame game)
        {
            foreach (IPlayer player in game.Players)
            {
                var nextPlayerText = player == game.NextPlayer ? " and their go is next" : "";
                m_Writer.WriteLine("Player {0} is on {1} {2}", player.Name, player.CurrentSquare.Name, nextPlayerText);
            }
        }
    }

    public static class Board
    {
        public static IEnumerable<BoardSquare> Squares { get; private set; }

        static Board()
        {
            Squares = new BoardSquare[]
            {
                new BoardSquare("Go"),
                new BoardSquare("Old Kent Road"),
                new BoardSquare("Community Chest"),
                new BoardSquare("Whitechapel Road"),
                new BoardSquare("Income Tax"),
                new BoardSquare("King's Cross Station"),
                new BoardSquare("The Angel Islington"),
                new BoardSquare("Chance"),
                new BoardSquare("Euston Road"),
                new BoardSquare("Pentonville Road"),
                new BoardSquare("In Gaol | Just visiting"),
                new BoardSquare("Pall Mall"),
                new BoardSquare("Electric Company"),
                new BoardSquare("Whitehall"),
                new BoardSquare("Northumberland Avenue"),
                new BoardSquare("Marylebone Station"),
                new BoardSquare("Bow Street"),
                new BoardSquare("Community Chest"),
                new BoardSquare("Marlborough Street"),
                new BoardSquare("Vine Street"),
                new BoardSquare("Free parking"),
                new BoardSquare("Strand"),
                new BoardSquare("Fleet Street"),
                new BoardSquare("Chance"),
                new BoardSquare("Trafalgar Square"),
                new BoardSquare("Fenchurch Street Station"),
                new BoardSquare("Leicester Square"),
                new BoardSquare("Water Works"),
                new BoardSquare("Piccadilly"),
                new BoardSquare("Go to gaol"),
                new BoardSquare("Oxford Street"),
                new BoardSquare("Regent Street"),
                new BoardSquare("Community Chest"),
                new BoardSquare("Bond Street"),
                new BoardSquare("Liverpool Street Station"),
                new BoardSquare("Chance"),
                new BoardSquare("Park Lane"),
                new BoardSquare("Super Tax"),
                new BoardSquare("Mayfair")
            };
        }
    }

    public class BoardSquare
    {
        public BoardSquare(string name) { Name = name; }
        public string Name { get; private set; }
    }
}
