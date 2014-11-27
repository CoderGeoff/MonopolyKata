using NUnit.Framework;

namespace Monopoly
{
    public class BoardTests
    {
        [Test]
        public void GoShouldBeFirstSquare()
        {
            Assert.That(new Board()[0].Name, Is.EqualTo("Go"));
        }
    }
}