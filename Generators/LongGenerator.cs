using Interfaces;

namespace Generators
{
    public class LongGenerator : IGenerator
    {
        public object Generate()
        {
            const long returnValue = 1234567890;
            return returnValue;
        }
    }
}