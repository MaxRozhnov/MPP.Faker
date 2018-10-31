using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class FloatListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<float>();
            var floatGenerator = new FloatGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((float) floatGenerator.Generate());
            }

            return returnValue;
        }
    }
}