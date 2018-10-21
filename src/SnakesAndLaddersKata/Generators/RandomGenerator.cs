using System;
using SnakesAndLaddersKata.Interfaces;

namespace SnakesAndLaddersKata.Generators
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _rand;

        public RandomGenerator()
        {
            _rand = new Random(DateTime.UtcNow.Second);
        }

        public int Generate()
        {
            return _rand.Next(1, 6);
        }
    }
}
