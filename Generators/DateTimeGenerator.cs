using System;
using Interfaces;

namespace Generators
{
    public class CurrentDateTimeGenerator : IGenerator 
    {
        public object Generate()
        {
            var dateTime = DateTime.Now;
            return dateTime;
        }
    }
}