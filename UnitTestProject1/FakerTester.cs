using System;
using Faker_Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program;

namespace UnitTestProject1
{
    [TestClass]
    public class FakerTester
    {
        private Faker _faker;

        [TestMethod]
        public void TestIntGenerator()
        {
            TestDTO testDTO = _faker.Create<TestDTO>();
            Assert.AreNotEqual(0, testDTO.foo);
        }

        [TestMethod]
        public void TestRecursiveDto()
        {
            try
            {
                RecursiveDTO recursiveDTO = _faker.Create<RecursiveDTO>();
                Assert.Fail("Recursive DTO created successfully");
            }
            catch
            {
                
            }
        }

        [TestMethod]
        public void TestDeepRecursiveDto()
        {
            try
            {
                DeepRecursiveDTO1 recursiveDTO = _faker.Create<DeepRecursiveDTO1>();
                Assert.Fail("Deep recursive DTO created successfully");
            }
            catch
            {

            }
        }

        [TestMethod]
        public void TestListDateTimePlugin()
        { 
            var plugins = PluginLoader.Load("C:\\Users\\Max\\RiderProjects\\Lab Task 2\\Plugins\\bin\\Debug\\netstandard2.0\\Plugins.dll");

            foreach (var plugin in plugins)
            {
                _faker.AddExtensionalDictionary(plugin.GetExtensionalGenerators());
            }

            DateTimeListDTO dateTimeListDTO = _faker.Create<DateTimeListDTO>();
            Assert.IsNotNull(dateTimeListDTO.myFriendsBirthdays);
        }

        [TestMethod]
        public void TestDateTimePlugin()
        {
            var plugins = PluginLoader.Load("C:\\Users\\Max\\RiderProjects\\Lab Task 2\\Plugins\\bin\\Debug\\netstandard2.0\\Plugins.dll");
            foreach (var plugin in plugins)
            {
                _faker.AddExtensionalDictionary(plugin.GetExtensionalGenerators());
            }
            DateTimeDTO dateTimeDTO = _faker.Create<DateTimeDTO>();
            Assert.IsNotNull(dateTimeDTO.myBirthday);
        }

        [TestMethod]
        public void TestIntListGenerator()
        {
            var intListDTO = _faker.Create<IntListDTO>();
            if(intListDTO.randomNumbers == null)
            {
                Assert.Fail("Int list not created");
            }
            else
            {
                foreach(var number in intListDTO.randomNumbers)
                {
                    if(number == 0)
                    {
                        Assert.Fail("Number generated incorrectly");
                    }
                }
            }
        }

        [TestInitialize]
        public void Setup()
        {
            _faker = new Faker();
        }
    }

    class TestDTO
    {
        public int foo { get; set; }
    }

    class RecursiveDTO
    {
        public int foo { get; set; }
        public RecursiveDTO recursiveDTO { get; set; }
    }

    class DeepRecursiveDTO1
    {
        public DeepRecursiveDTO2 nope { get; set; }
    }

    class DeepRecursiveDTO2
    {
        public DeepRecursiveDTO3 nope { get; set; }
    }

    class DeepRecursiveDTO3
    {
        public DeepRecursiveDTO1 surprise { get; set; }
    }

    class DateTimeDTO
    {
        public DateTime myBirthday { get; set; }
    }

    class DateTimeListDTO
    {
        public System.Collections.Generic.List<DateTime> myFriendsBirthdays { get; set; }
    }
    
    class IntListDTO
    {
        public System.Collections.Generic.List<int> randomNumbers { get; set; }
    }

}
