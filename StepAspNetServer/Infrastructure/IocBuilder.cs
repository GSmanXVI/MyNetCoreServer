using StepAspNetServer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StepAspNetServer.Infrastructure
{
    public class IocBuilder
    {
        private Stack<(Type from, Type to)> types = new Stack<(Type from, Type to)>();

        public IocBuilder Register<T>() where T : class
        {
            types.Push((typeof(T), typeof(T)));
            return this;
        }

        public void As<T>() where T : class
        {
            //types.Peek().to = typeof(T);

            var type = types.Pop();
            type.to = typeof(T);
            types.Push(type);
        }

        public IocContainer Build()
        {
            Dictionary<Type, object> objects = new Dictionary<Type, object>();

            foreach (var type in types)
            {
               objects.Add(type.to, Activator.CreateInstance(type.from));
            }

            foreach (var controllerType in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (controllerType.BaseType == typeof(Controller))
                {
                    var controllerParams = controllerType
                        .GetConstructors()
                        .FirstOrDefault()
                        .GetParameters();

                    var constructorArgs = new object[controllerParams.Length];
                    for (int i = 0; i < controllerParams.Length; i++)
                    {
                        constructorArgs[i] = objects[controllerParams[i].ParameterType];
                    }

                    var controller = Activator.CreateInstance(controllerType, constructorArgs);

                    objects.Add(controllerType, controller);
                }
            }

            return new IocContainer(objects);
        }
    }
}
