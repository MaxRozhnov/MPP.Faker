using System;
using System.Reflection;
using Interfaces;

namespace Program
{
    public class PluginLoader
    {
        public static IPlugin Load(string path)
        {
            var assembly = Assembly.LoadFrom(path);
            foreach (var type in assembly.GetTypes())
            {
                if (type.GetInterface("IPlugin") != null)
                {
                    return (IPlugin) Activator.CreateInstance(type);
                }
            }

            return null;
        }
    }
}