using Application.Profiles;
using AutoMapper;
using System.Reflection;

namespace Api.Profiles
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            // Apply all mappers from the current assembly
            ApplyMappingProfiles(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingProfiles(Assembly assembly)
        {
            // Get all types that implement ICreateMapper<TSource>
            var types = assembly.GetExportedTypes()
                                .Where(t => t.GetInterfaces().Any(i =>
                                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICreateMapper<>)))
                                .ToList();

            // For each type that implements ICreateMapper<TSource>
            foreach (var type in types)
            {
                // Create an instance of the type
                var model = Activator.CreateInstance(type);

                // Get the Map method from the class or from the interface
                var methodInfo = type.GetMethod("Map") // Get method from the class
                                     ?? type.GetInterface("ICreateMapper`1").GetMethod("Map"); // If not found, get from the interface

                // If the method exists, invoke it
                if (model != null && methodInfo != null)
                {
                    try
                    {
                        // Invoke the 'Map' method
                        methodInfo.Invoke(model, new object[] { this }); // 'this' refers to the Profile instance
                    }
                    catch (Exception ex)
                    {
                        // Log the exception or handle it as needed
                        Console.WriteLine($"Error invoking Map method on {type.Name}: {ex.Message}");
                        // Optionally, you could log the stack trace to help diagnose the issue:
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
        }
    }
}
