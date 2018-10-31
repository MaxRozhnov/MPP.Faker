using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class DoubleListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<double>();
            var doubleGenerator = new DoubleGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((double) doubleGenerator.Generate());
            }

            return returnValue;
        }
    }
}