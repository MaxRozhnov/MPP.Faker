using System;
using System.Collections.Generic;
using Interfaces;
using Generators;

namespace Plugins
{
    public class DatePlugin : IPlugin
    {
        private readonly Dictionary<Type, IGenerator> _extensionGenerators;

        public DatePlugin()
        {
            _extensionGenerators = new Dictionary<Type, IGenerator>
            {
                {typeof(DateTime), new DateTimeGenerator()}
            };
        }
        
        public Dictionary<Type, IGenerator> GetExtensionalGenerators()
        {
            return _extensionGenerators;
        }
    }
}