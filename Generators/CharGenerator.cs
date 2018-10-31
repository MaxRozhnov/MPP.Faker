using System;
using Interfaces;

namespace Generators
{
    public class CharGenerator : IGenerator
    {
        private Random _random;

        public CharGenerator()
        {
            _random = new Random();
        }
        public object Generate()
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var index = _random.Next(alphabet.Length);
            return alphabet[index];
        }
    }
}