using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class ByteListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<byte>();
            var byteGenerator = new ByteGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((byte) byteGenerator.Generate());
            }

            return returnValue;
        }
    }
}