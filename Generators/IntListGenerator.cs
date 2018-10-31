using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class IntListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<int>();
            var intGenerator = new IntGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((int) intGenerator.Generate());
            }

            return returnValue;
        }
    }
}