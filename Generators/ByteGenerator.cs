using Interfaces;

namespace Generators
{
    public class ByteGenerator : IGenerator
    {
        public object Generate()
        {
            var intGenerator = new IntGenerator();
            return (byte) intGenerator.Generate();
        }
    }
}