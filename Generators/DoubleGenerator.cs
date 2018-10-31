using System;
using Interfaces;

namespace Generators
{
    public class DoubleGenerator : IGenerator
    {
        public  object Generate()
        {
            const int minValue = -100;
            const int maxValue = 100;
            var random = new Random();
            return random.NextDouble() * (maxValue - minValue) + maxValue;   
        }
    }
}