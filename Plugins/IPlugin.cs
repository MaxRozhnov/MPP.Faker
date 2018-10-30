using System;
using System.Collections.Generic;
using Generators;

namespace Plugins
{
    public interface IPlugin
    {
        Dictionary<Type, IGenerator> GetExtensionGenerators();
    }
}