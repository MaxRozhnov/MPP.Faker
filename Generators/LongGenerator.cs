using Interfaces;

namespace Generators
{
    public class LongGenerator : IGenerator
    {
        public object Generate()
        {
            var intGenerator = new IntGenerator();
            return (long)intGenerator.Generate();
        }
    }
}