using NUnit.Framework;

namespace Monopoly
{
    public class BoardTests
    {
        [Test]
        public void FistSquareShouldBeGo()
        {
            Assert.That(new Board()[0].Name, Is.EqualTo("Go"));
        }

        [Test]
        public void GoShouldBeFirstSquare()
        {
            Assert.That(new Board()["Go"], Is.EqualTo(new Board()[0]));
        }

        [Test]
        public void MoveFourFromGoShouldGetToIncomeTax()
        {
            Assert.That(Board.MoveFrom(new Board()["Go"], 4).Name, Is.EqualTo("Income Tax"));
            
        }
    }
}