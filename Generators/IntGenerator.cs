using System;
using System.Threading;
using Interfaces;

namespace Generators
{
    public class IntGenerator : IGenerator
    {
        private readonly Random _random;

        public IntGenerator()
        {
            _random = new Random();
        }
        public object Generate()
        {
            const int minValue = -100;
            const int maxValue = 100;
            //var random = new Random();
            int returnValue = _random.Next(minValue, maxValue);
            return returnValue != 0? returnValue : 1;   
        }
    }
}