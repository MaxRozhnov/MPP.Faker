using Interfaces;

namespace Generators
{
    public class ByteGenerator : IGenerator
    {
        public object Generate()
        {
            const byte returnValue = 42;
            return returnValue;
        }
    }
}