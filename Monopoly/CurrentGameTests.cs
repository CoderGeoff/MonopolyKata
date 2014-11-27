using System;
using System.Linq;
using NUnit.Framework;

namespace Monopoly
{
    public class CurrentGameTests
    {
        [Test]
        public void AllPlayersShouldStartOnGo()
        {
            var game = new CurrentGame(playerCount: 3);
            var playerSquares = game.Players.Select(player => player.CurrentSquare.Name).Distinct();
            Assert.That(playerSquares, Is.EquivalentTo(new[]{"Go"}));
        }

        [Test]
        public void AllPlayersShouldHaveADistinctName()
        {
            const int maxPlayers = 6;
            var game = new CurrentGame(playerCount: maxPlayers);
            var playerNames = game.Players.Select(player => player.Name).Distinct();
            Assert.That(playerNames.Count(), Is.EqualTo(maxPlayers));
        }


        [Test]
        public void NoPlayersShouldHaveABlankName()
        {
            const int maxPlayers = 6;
            var game = new CurrentGame(playerCount: maxPlayers);
            var playerNames = game.Players.Select(player => player.Name).Where(string.IsNullOrWhiteSpace);
            Assert.That(playerNames.Count(), Is.EqualTo(0));
        }

        [Test]
        [TestCase(1)]
        [TestCase(7)]
        public void ShouldThrowWithInvalidNumberOfPlayers(int invalidNumberOfPlayers)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CurrentGame(invalidNumberOfPlayers));
        }

        [Test]
        public void ThrowingShouldMovePlayerAroundBoard()
        {
            const int maxPlayers = 6;
            var game = new CurrentGame(playerCount: maxPlayers);
            var player = game.NextPlayer;
            game.TakeNextTurn(new TestDice(4));
            Assert.That(player.CurrentSquare == new Board()[4]);
        }


        class TestDice : IDice
        {
            private readonly int m_Throw;

            public TestDice(int @throw)
            {
                m_Throw = @throw;
            }
            public int Throw()
            {
                return m_Throw;
            }
        }
    }
}
