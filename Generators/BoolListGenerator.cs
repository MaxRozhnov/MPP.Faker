using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class BoolListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<bool>();
            var boolGenerator = new BoolGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((bool) boolGenerator.Generate());
            }

            return returnValue;
        }
    }
}