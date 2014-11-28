using NUnit.Framework;

namespace Monopoly
{
    public class BoardTests
    {
        [Test]
        public void FistSquareShouldBeGo()
        {
            Assert.That(Board.TheBoard[0].Name, Is.EqualTo("Go"));
        }

        [Test]
        public void GoShouldBeFirstSquare()
        {
            Assert.That(Board.TheBoard["Go"], Is.EqualTo(Board.TheBoard[0]));
        }

        [Test]
        public void MoveFourFromGoShouldGetToIncomeTax()
        {
            Assert.That(Board.MoveFrom(Board.TheBoard["Go"], 4).Name, Is.EqualTo("Income Tax"));
            
        }
    }
}