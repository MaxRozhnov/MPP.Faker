using System;

namespace Generators
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            const int minValue = -100;
            const int maxValue = 100;
            var random = new Random();
            return random.Next(minValue, maxValue + 1);   
        }
    }
}