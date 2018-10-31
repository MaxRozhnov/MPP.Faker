using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class CharListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<char>();
            var charGenerator = new CharGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((char) charGenerator.Generate());
            }

            return returnValue;
        }
    }
}