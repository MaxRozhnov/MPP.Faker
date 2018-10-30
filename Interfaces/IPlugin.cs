using System;
using System.Collections.Generic;
using Generators;
//using Generators.IGenerator;

namespace Interfaces
{
    public interface IPlugin
    {
        Dictionary<Type, IGenerator> GetExtensionalGenerators();
    }
}