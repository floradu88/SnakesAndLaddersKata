using System;
using System.Collections.Generic;
using SnakesAndLaddersKata.Interfaces;

namespace SnakesAndLaddersKata.Engine
{
    public class GameEngine : IGameEngine
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly Dictionary<int, int> _currentProgress;
        private readonly int _currentPlayer;

        public bool Started { get; private set; }
        public int PlayerNumber { get; }
        public bool Finished { get; private set; }
        public int Winner { get; private set; }

        public GameEngine(IRandomGenerator randomGenerator, int playerNumber = 2)
        {
            if (playerNumber < 2)
                throw new InvalidOperationException("Invalid Number of players");
            _randomGenerator = randomGenerator;
            PlayerNumber = playerNumber;
            Finished = false;
            _currentProgress = new Dictionary<int, int>();

            for (int i = 1; i <= playerNumber; i++)
            {
                _currentProgress[i] = 1;
            }

            _currentPlayer = 1;
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
            var progress = _randomGenerator.Generate();
            
            if (_currentProgress[_currentPlayer] + progress == 100)
            {
                _currentProgress[_currentPlayer] += progress;
                Finished = true;
                Winner = _currentPlayer;
            }
            else if (_currentProgress[_currentPlayer] + progress < 100)
            {
                _currentProgress[_currentPlayer] += progress;
            }

            return progress;
        }

        public double GetPlayerProgress(int playerNumber)
        {
            return _currentProgress[playerNumber];
        }
    }
}
