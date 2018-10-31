using System;
using Interfaces;

namespace Generators
{
    public class FloatGenerator : IGenerator
    {
        private Random _random;

        public FloatGenerator()
        {
            _random = new Random();
        }
        public object Generate()
        {
            //var random = new Random();
            var mantissa = (_random.NextDouble() * 2.0) - 1.0;
            var exponent = Math.Pow(2.0, _random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
    }
}