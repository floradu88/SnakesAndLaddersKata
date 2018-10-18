using SnakesAndLaddersKata.Interfaces;

namespace SnakesAndLaddersKata.Engine
{
    public class GameEngine : IGameEngine
    {
        public bool Started { get; private set; }

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
