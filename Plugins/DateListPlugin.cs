using System;
using System.Collections.Generic;
using Generators;
using Interfaces;

namespace Plugins
{
    public class DateListPlugin : IPlugin
    {
        private readonly Dictionary<Type, IGenerator> _extensionGenerators;

        public DateListPlugin()
        {
            _extensionGenerators = new Dictionary<Type, IGenerator>()
            {
                {typeof(List<DateTime>), new DateTimeListGenerator()}
            };
        }
        public Dictionary<Type, IGenerator> GetExtensionalGenerators()
        {
            return _extensionGenerators;
        }
    }
}