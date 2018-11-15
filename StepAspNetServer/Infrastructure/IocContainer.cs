using System;
using System.Collections.Generic;
using System.Text;

namespace StepAspNetServer.Infrastructure
{
    public class IocContainer
    {
        Dictionary<Type, object> objects = new Dictionary<Type, object>();

        public IocContainer(Dictionary<Type, object> objects)
        {
            this.objects = objects;
        }

        public T Resolve<T>() where T : class
        {
            return objects[typeof(T)] as T;
        }

        public object Resolve(Type type)
        {
            return objects[type];
        }
    }
}
