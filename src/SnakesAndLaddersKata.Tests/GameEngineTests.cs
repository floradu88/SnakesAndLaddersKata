using System;
using Moq;
using NUnit.Framework;
using SnakesAndLaddersKata.Engine;
using SnakesAndLaddersKata.Generators;
using SnakesAndLaddersKata.Interfaces;

namespace SnakesAndLaddersKata.Tests
{
    [TestFixture]
    public class GameEngineTests
    {
        [Test]
        public void Should_be_able_to_create_a_game_engine()
        {
            IRandomGenerator generator = new RandomGenerator();
            IGameEngine gameEngine = new GameEngine(generator);

            Assert.IsNotNull(gameEngine);
            Assert.IsInstanceOf<GameEngine>(gameEngine);
        }

        [Test]
        public void Should_be_able_to_start_a_game()
        {
            IRandomGenerator generator = new RandomGenerator();
            IGameEngine gameEngine = new GameEngine(generator);

            Assert.True(gameEngine.Start());

            Assert.True(gameEngine.Started);
        }

        [Test]
        public void Should_be_able_to_check_game_isnt_started()
        {
            IRandomGenerator generator = new RandomGenerator();
            IGameEngine gameEngine = new GameEngine(generator);

            Assert.False(gameEngine.Started);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void Should_be_able_to_add_players_to_the_game(int noPlayers)
        {
            IRandomGenerator generator = new RandomGenerator();
            IGameEngine gameEngine = new GameEngine(generator, noPlayers);

            Assert.AreEqual(noPlayers, gameEngine.PlayerNumber);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Should_not_be_able_to_add_invalid_players_to_the_game(int noPlayers)
        {
            IRandomGenerator generator = new RandomGenerator();
            Assert.Throws<InvalidOperationException>(() => new GameEngine(generator, noPlayers));
        }

        [Test]
        public void Should_be_able_to_roll_dice_for_current_player()
        {
            // Given the game is started
            // When the player rolls a die
            // Then the result should be between 1-6 inclusive
            IRandomGenerator generator = new RandomGenerator();
            IGameEngine gameEngine = new GameEngine(generator);

            int rollDice = gameEngine.RollDice();

            Assert.LessOrEqual(rollDice, 6);
            Assert.GreaterOrEqual(rollDice, 1);
        }

        [Test]
        [TestCase(4)]
        [TestCase(3)]
        public void Should_be_able_to_roll_dice_and_move_pawn_for_current_player(int expectedRollDice)
        {
            // Given the player rolls a 4
            // When they move their token
            // Then the token should move 4 spaces
            var randomGenerator = new Mock<IRandomGenerator>();
            randomGenerator.Setup(x => x.Generate()).Returns(expectedRollDice);

            IGameEngine gameEngine = new GameEngine(randomGenerator.Object);

            gameEngine.RollDice();

            Assert.AreEqual(gameEngine.GetPlayerProgress(1), expectedRollDice);
        }
    }
}
