using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class LongListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<long>();
            var longGenerator = new LongGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((long) longGenerator.Generate());
            }

            return returnValue;
        }
    }
}