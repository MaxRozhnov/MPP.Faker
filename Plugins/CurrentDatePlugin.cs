using System;
using System.Collections.Generic;
using Interfaces;
using Generators;

namespace Plugins
{
    public class CurrentDatePlugin : IPlugin
    {
        private readonly Dictionary<Type, IGenerator> _extensionGenerators;

        public CurrentDatePlugin()
        {
            _extensionGenerators = new Dictionary<Type, IGenerator>
            {
                {typeof(DateTime), new CurrentDateTimeGenerator()}
            };
        }
        
        public Dictionary<Type, IGenerator> GetExtensionalGenerators()
        {
            return _extensionGenerators;
        }
    }
}