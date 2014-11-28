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
    }
}