using System;
using Interfaces;

namespace Generators
{
    public class StringGenerator : IGenerator
    {
        public object Generate()
        {
            const int maxLength = 42;
            const string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                
            var random = new Random();
            var length = random.Next(0, maxLength + 1);
            var result = "";
            for (var i = 0; i < length; i++)
            {
                var characterNumber = random.Next(0, allowedCharacters.Length);
                result += allowedCharacters[characterNumber];

            }

            return result;
        }
    }
}