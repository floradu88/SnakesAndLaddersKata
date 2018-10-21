using System;
using SnakesAndLaddersKata.Interfaces;

namespace SnakesAndLaddersKata.Engine
{
    public class GameEngine : IGameEngine
    {
        private readonly IRandomGenerator _randomGenerator;
        private int _currentProgress;

        public bool Started { get; private set; }
        public int PlayerNumber { get; }

        public GameEngine(IRandomGenerator randomGenerator, int playerNumber = 2)
        {
            if (playerNumber < 2)
                throw new InvalidOperationException("Invalid Number of players");
            _randomGenerator = randomGenerator;
            PlayerNumber = playerNumber;
            _currentProgress = 0;
        }

        public bool Start()
        {
            if (!Started)
            {
                Started = true;
                return Started;
            }

            return false;
        }

        public int RollDice()
        {
            _currentProgress = _randomGenerator.Generate();
            return _currentProgress;
        }

        public double GetPlayerProgress(int playerNumber)
        {
            return _currentProgress;
        }
    }
}
