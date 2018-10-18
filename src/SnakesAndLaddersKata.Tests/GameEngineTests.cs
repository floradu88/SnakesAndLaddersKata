using NUnit.Framework;
using SnakesAndLaddersKata.Engine;
using SnakesAndLaddersKata.Interfaces;

namespace SnakesAndLaddersKata.Tests
{
    [TestFixture]
    public class GameEngineTests
    {
        [Test]
        public void Should_be_able_to_create_a_game_engine()
        {
            IGameEngine gameEngine = new GameEngine();

            Assert.IsNotNull(gameEngine);
            Assert.IsInstanceOf<GameEngine>(gameEngine);
        }

        [Test]
        public void Should_be_able_to_start_a_game()
        {
            IGameEngine gameEngine = new GameEngine();

            Assert.True(gameEngine.Start());

            Assert.True(gameEngine.Started);
        }

        [Test]
        public void Should_be_able_to_check_game_isnt_started()
        {
            IGameEngine gameEngine = new GameEngine();

            Assert.False(gameEngine.Started);
        }
    }
}
