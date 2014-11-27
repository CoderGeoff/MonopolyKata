using System.IO;

namespace Monopoly
{
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
}