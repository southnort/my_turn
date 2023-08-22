using System.Linq;
using VContainer;

namespace Game.DI
{
    internal static class ObjectResolverExtensions
    {
        public static T CreateInstance<T>(this IObjectResolver objectResolver)
        {
            var type = typeof(T);
            var constructor = type.GetConstructors().FirstOrDefault();

            if (constructor is null)
            {
                throw new VContainerException(type, "Failed to find suitable constructor!");
            }

            var parameterInfos = constructor.GetParameters();
            var parameters = new object[parameterInfos.Length];

            for (var i = 0; i < parameterInfos.Length; ++i)
            {
                parameters[i] = objectResolver.Resolve(parameterInfos[i].ParameterType);
            }

            var instance = (T)constructor.Invoke(parameters);
            objectResolver.Inject(instance);

            return instance;
        }
    }
}