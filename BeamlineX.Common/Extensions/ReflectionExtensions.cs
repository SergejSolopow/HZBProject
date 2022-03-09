using System.Reflection;

namespace BeamlineX.Common.Extensions
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<T> GetAssemblyObjects<T>(this Assembly assembly, params object[] constructorArgs)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), "Parameter darf nicht NULL sein");
            }

            return assembly
                .GetAssemblyTypes<T>()
                .Select(t => (T)Activator.CreateInstance(t, constructorArgs));
        }

        public static IEnumerable<Type> GetAssemblyTypes<T>(this Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), "Parameter darf nicht NULL sein");
            }

            try
            {
                return assembly
                    .GetTypes()
                    .Where(p => typeof(T).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract && p.IsClass);
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (Exception exception in e.LoaderExceptions)
                {
                    Console.WriteLine(exception.Message + exception.InnerException.Message);
                }

                throw;
            }
        }
    }
}
