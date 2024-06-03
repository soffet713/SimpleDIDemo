using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomDIDemo
{
    internal class DiContainer
    {
        private Dictionary<Type, Type> _types = new Dictionary<Type, Type>();

        public void Register<TInterface, TType>()
        {
            if (_types.ContainsKey(typeof(TInterface)))
            {
                throw new Exception("Type already registered.");
            }
            _types.Add(typeof(TInterface), typeof(TType));
        }

        public TInterface Resolve<TInterface>()
        { 
            return (TInterface) GetImplementation(typeof(TInterface));
        }

        private object GetImplementation(Type type)
        {
            if (!_types.ContainsKey(type))
            {
                throw new Exception("Type does not exist");
            }
            Type implementation = _types.GetValueOrDefault(type);
            ConstructorInfo constructorInfo = implementation.GetConstructors()[0];
            var constructorParamTypes = constructorInfo.GetParameters();
            List<object> constructorParamImplementations = new List<object>();
            foreach (var param in constructorParamTypes)
            { 
                constructorParamImplementations.Add(GetImplementation(param.ParameterType));
            }
            return constructorInfo.Invoke(constructorParamImplementations.ToArray());
        }
    }
}
