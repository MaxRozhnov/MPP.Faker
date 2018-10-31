using System;
using Interfaces;

namespace Generators
{
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            var mantissa = (random.NextDouble() * 2.0) - 1.0;
            var exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
    }
}