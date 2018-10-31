using System;
using System.Collections.Generic;
//using Generators.IGenerator;

namespace Interfaces
{
    public interface IPlugin
    {
        Dictionary<Type, IGenerator> GetExtensionalGenerators();
    }
}