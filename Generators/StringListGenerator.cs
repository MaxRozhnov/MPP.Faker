using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class StringListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<string>();
            var stringGenerator = new StringGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((string) stringGenerator.Generate());
            }

            return returnValue;
        }
    }
}