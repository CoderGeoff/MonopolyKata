using System;
using System.Linq;

namespace Monopoly
{
    public class Board
    {
        #region Singleton
        private static readonly Board s_TheBoard = new Board();
        public static Board TheBoard { get { return s_TheBoard; } }
        private Board() { }
        #endregion

        private static readonly BoardSquare[] s_Squares;

        public BoardSquare this[string name] { get { return s_Squares.First(square => square.Name == name); } }
        public BoardSquare this[int index] { get { return s_Squares[index]; } }

        static Board()
        {
            s_Squares = new BoardSquare[]
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

        public static BoardSquare MoveFrom(BoardSquare origin, int distance)
        {
            int newIndex = FindIndexOf(origin) + distance;
            if (newIndex < 0) newIndex += s_Squares.Length;
            if (newIndex >= s_Squares.Length) newIndex -= s_Squares.Length;
            return s_Squares[newIndex];
        }

        private static int FindIndexOf(BoardSquare origin)
        {
            for (int i = 0; i < s_Squares.Length; ++i)
            {
                if (origin == s_Squares[i]) return i;
            }
            throw new ArgumentException("Not found", "origin");
        }
    }
}