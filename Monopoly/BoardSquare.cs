using System.Collections.Generic;

namespace Monopoly
{
    public class BoardSquare 
    {
        public BoardSquare(string name) { Name = name; }
        public string Name { get; private set; }
    }
}
