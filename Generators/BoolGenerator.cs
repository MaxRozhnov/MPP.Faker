using Interfaces;

namespace Generators
{
    public class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            var intGenerator = new IntGenerator();
            return ((int)intGenerator.Generate() >= 0) ? true : false;
        }
    }
}