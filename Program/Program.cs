using System;
using System.Collections.Generic;
using Faker_Lib;


namespace Program
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var faker = new Faker();
            var plugins =
                PluginLoader.Load("C:\\Users\\Max\\RiderProjects\\Lab Task 2\\Plugins\\bin\\Debug\\netstandard2.0\\Plugins.dll");
            
            foreach (var plugin in plugins)
            {
                faker.AddExtensionalDictionary(plugin.GetExtensionalGenerators());
            }
            
            Console.WriteLine( faker.Create<BasicDTO1>());

        }
    }

    class BasicDTO1
    {
        public int foo { get; set; }
        public int bar{ get; set; }
        public int baz{ get; set; }
        public List<int> fooBar { get; set; }
        public DateTime today { get; set; }
        public BasicDTO2 oleg{ get; set; }
        public char umm { get; set; }
        public string name { get; set; }
        
        //public int bamboo;
    }

    class BasicDTO2
    {
        public int foo { get; set; }

    }
}