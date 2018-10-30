using System;
using System.Collections.Generic;
using Generators;

namespace Plugins
{
    public class Plugin : IPlugin
    {
        private Dictionary<Type, IGenerator> _extensionMethods;

        public Plugin()
        {
            _extensionMethods = new Dictionary<Type, IGenerator>();
            
        }
        
        public Dictionary<Type, IGenerator> GetExtensionGenerators()
        {
            return _extensionMethods;
        }
        
    }
}