using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Generators;
using Interfaces;

namespace Faker_Lib
{
    public class Faker
    {
        private readonly List<Type> _simpleTypes;
        private readonly List<Type> _simpleLists;
        private readonly Stack<Type> _typesMet;
        private readonly Dictionary<Type, IGenerator> _generators;
        private readonly List<Dictionary<Type, IGenerator>> _extensionalDictionaries;

        public Faker()
        {
            _simpleTypes = new List<Type> 
            {
                typeof(int), 
                typeof(long),                                            
                typeof(float),                                           
                typeof(double),                                            
                typeof(string),               
                typeof(bool),
                typeof(char),
                typeof(byte)
               
            };
            
            _simpleLists = new List<Type>
            {
                typeof(List<int>),    
                typeof(List<long>),
                typeof(List<float>),
                typeof(List<double>),
                typeof(List<string>),
                typeof(List<bool>),
                typeof(List<char>),
                typeof(List<byte>)
            };

            _generators = new Dictionary<Type, IGenerator>
            {
                {typeof(int), new IntGenerator()},
                {typeof(long), new LongGenerator()},
                {typeof(string), new StringGenerator()},
                {typeof(float), new FloatGenerator()},
                {typeof(double), new DoubleGenerator()},
                {typeof(byte), new ByteGenerator()},
                {typeof(char), new CharGenerator()},
                {typeof(bool), new BoolGenerator()},
                
                {typeof(List<int>), new IntListGenerator()},
                {typeof(List<long>), new LongListGenerator()},
                {typeof(List<string>), new StringListGenerator()},
                {typeof(List<float>), new FloatListGenerator()},
                {typeof(List<double>), new DoubleListGenerator()},
                {typeof(List<byte>), new ByteListGenerator()},
                {typeof(List<char>), new CharListGenerator()},
            };

            _typesMet = new Stack<Type>();
            _extensionalDictionaries = new List<Dictionary<Type, IGenerator>>();
        }

        public T Create<T>()
        {
            if (IsDto(typeof(T)))
            {
                var result = (T)GenerateDto(typeof(T));
                return result == null ? default(T) : result; 
            }
            else
            {
                throw new Exception("Passed type is not a DTO");
            }

        }

        private bool IsDto(Type objectType)
        {            
            foreach (var type in _typesMet)
            {
                if (objectType == type)
                {
                    return false;
                }
            }
            
            _typesMet.Push(objectType);
            
            const BindingFlags bindingFlags = BindingFlags.Instance |
                                              BindingFlags.NonPublic |
                                              BindingFlags.Public;
            
            var fields = objectType.GetFields(bindingFlags);
            
            foreach (var field in fields)
            {
                if (!IsSimpleTypeOrList(field.FieldType))
                {
                    if (!IsExtensionalItem(field.FieldType))
                    {
                        if (!IsDto(field.FieldType))
                        {
                            return false;
                        }
                    }
                }
            }

            _typesMet.Pop();
            return true;
        }

        private bool IsSimpleTypeOrList(Type type)
        {
            foreach (var simpleType in _simpleTypes)
            {
                if (type == simpleType)
                {
                    return true;
                }
            }

            foreach (var simpleType in _simpleLists)
            {
                if (type == simpleType)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsExtensionalItem(Type type)
        {
            foreach (var extensionalDictionary in _extensionalDictionaries)
            {
                foreach (var keyValuePair in extensionalDictionary)
                {
                    if (keyValuePair.Key == type)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private object CreateUsingConstructor(ConstructorInfo constructor)
        {
            var parametersInfo = constructor.GetParameters();
            var actualParameters = new object[parametersInfo.Length];
            for (var i = 0; i < parametersInfo.Length; i++)
            {
                actualParameters[i] = Generate(parametersInfo[i].ParameterType);
            }
            return constructor.Invoke(actualParameters);
        }

        private object Generate(Type objectType)
        {
            try
            {
                foreach (var extensionalDictionary in _extensionalDictionaries)
                {
                    if (extensionalDictionary.ContainsKey(objectType))
                    {
                        return extensionalDictionary[objectType].Generate();
                    }
                }
                
                return _generators.ContainsKey(objectType) ? _generators[objectType].Generate() : GenerateDto(objectType);
            }
            catch
            {
                throw new Exception("Could not generate value for given type");
            }
        }

        private object GenerateDto(Type objectType)
        {
            var dtoConstructors = (objectType.GetConstructors().OrderByDescending(x => x.GetParameters().Length)).ToArray();
            var createdSuccessfully = false;
            var currentConstructor = 0;
            object result = null;
            while (!createdSuccessfully && currentConstructor < dtoConstructors.Length)
            {
                try
                {
                    var constructorToTry = dtoConstructors[currentConstructor];
                    result = CreateUsingConstructor(constructorToTry);   
                    createdSuccessfully = true;
                }
                catch
                {
                    currentConstructor++;
                    createdSuccessfully = false;
                }
            }

            if (createdSuccessfully)
            {
                FillProperties(ref result);
            }

            return result;
        }

        private void FillProperties<T>(ref T result)
        {
            var properties = result.GetType().GetProperties().Where(property => property?.SetMethod?.IsPublic != null);
            foreach (var property in properties)
            {
                SetProperty(ref result, property);
            }
        }
       
        private void SetProperty<T>(ref T result, PropertyInfo property)
        {
            var propertyType = property.PropertyType;
            object[] setMethodParameters = null;
            foreach (var extensionalDictionary in _extensionalDictionaries)
            {
                if (extensionalDictionary.ContainsKey(propertyType))
                {
                    setMethodParameters = new object[]{extensionalDictionary[propertyType].Generate()};
                } 
            }

            if (setMethodParameters == null)
            {
                setMethodParameters = _generators.ContainsKey(propertyType) ? new object[] { _generators[propertyType].Generate() } : new object[]{ GenerateDto(propertyType)};
            }

            property.SetMethod.Invoke(result, setMethodParameters);
        }

        public void AddExtensionalDictionary(Dictionary<Type, IGenerator> extensionalDictionary)
        {
            _extensionalDictionaries.Add(extensionalDictionary);
        }

        public void RemoveExtensionalDictionary(Dictionary<Type, IGenerator> extensionalDictionary)
        {
            _extensionalDictionaries.Remove(extensionalDictionary);
        }

    }
}