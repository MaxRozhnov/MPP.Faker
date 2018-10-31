using System;
using System.Collections.Generic;
using Interfaces;

namespace Generators
{
    public class DateTimeListGenerator : IGenerator
    {
        public object Generate()
        {
            var returnValue = new List<DateTime>();
            var dateTimeGenerator = new DateTimeGenerator();
            const int amount = 5;

            for (var i = 0; i < amount; i++)
            {
                returnValue.Add((DateTime) dateTimeGenerator.Generate());
            }

            return (List<DateTime>)returnValue;
        }
    }
}