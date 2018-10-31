using System;
using Interfaces;

namespace Generators
{
    public class StringGenerator : IGenerator
    {
        private Random _random;

        public StringGenerator()
        {
            _random = new Random();
        }
        
        public object Generate()
        {
            const int maxLength = 42;
               
            //var random = new Random();
            var length = _random.Next(0, maxLength + 1);
            var result = "";
            var charGenerator = new CharGenerator();
            for (var i = 0; i < length; i++)
            {
                var character = (char)charGenerator.Generate();
                result += character;
            }
            return result;
        }
    }
}