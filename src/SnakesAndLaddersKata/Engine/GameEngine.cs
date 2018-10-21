using System;
using SnakesAndLaddersKata.Interfaces;

namespace SnakesAndLaddersKata.Engine
{
    public class GameEngine : IGameEngine
    {
        public bool Started { get; private set; }
        public int PlayerNumber { get; }

        public GameEngine(int playerNumber = 2)
        {
            if (playerNumber < 2)
                throw  new InvalidOperationException("Invalid Number of players");
            PlayerNumber = playerNumber;
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
    }
}
