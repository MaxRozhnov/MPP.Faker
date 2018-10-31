using System;
using System.Collections.Generic;
using System.Reflection;
using Interfaces;

namespace Program
{
    public class PluginLoader
    {
        public static List<IPlugin> Load(string path)
        {
            var result = new List<IPlugin>();
            var assembly = Assembly.LoadFrom(path);
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetInterface("IPlugin") != null)
                {
                    result.Add( (IPlugin) Activator.CreateInstance(type));
                }
            }

            return result;
        }
    }
}