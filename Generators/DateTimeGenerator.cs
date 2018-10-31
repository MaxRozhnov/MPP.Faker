using System;
using Interfaces;

namespace Generators
{
    public class DateTimeGenerator : IGenerator 
    {
        private Random _random;

        public DateTimeGenerator()
        {
            _random = new Random();
        }
        public object Generate()
        {

            return new DateTime(_random.Next(1,9999), _random.Next(1,12), _random.Next(1,27));
        }
    }
}