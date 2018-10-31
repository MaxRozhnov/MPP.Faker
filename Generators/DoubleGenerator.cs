using System;
using Interfaces;

namespace Generators
{
    public class DoubleGenerator : IGenerator
    {
        private Random _random;

        public DoubleGenerator()
        {
            _random = new Random();
        }
        public  object Generate()
        {
            const int minValue = -100;
            const int maxValue = 100;
            //var _random = new Random();
            return _random.NextDouble() * (maxValue - minValue) + maxValue;   
        }
    }
}