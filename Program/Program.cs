using System;
using System.Threading;
using Faker_Lib;
using Generators;


namespace Program
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Faker faker = new Faker();
            Console.WriteLine( faker.Create<BasicDTO1>());

        }
    }

    class BasicDTO1
    {
        public int foo { get; set; }
        public int bar{ get; set; }
        public int baz{ get; set; }
        public BasicDTO2 oleg{ get; set; }
        
        //public int bamboo;
    }

    class BasicDTO2
    {
        public int foo { get; set; }

    }
}