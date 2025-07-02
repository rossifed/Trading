using Microsoft.Extensions.Configuration;

using Quantaventis.Trading.Shared.Abstractions.Modules;
using System.Reflection;
namespace Quantaventis.Trading.Shared.Infrastructure.Modules
{
    public static class ModuleLoader
    {

        public static IList<Assembly> LoadAssemblies(IConfiguration configuration)
        {
            const string ModulePart = "Quantaventis.Trading.Modules.";
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var locations = assemblies.Where(assembly => !assembly.IsDynamic).Select(assembly => assembly.Location).ToArray();
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Where(file => !locations.Contains(file, StringComparer.InvariantCultureIgnoreCase))
                .ToList();
            
            var diabledModules = new List<string>();
            foreach (var file in files) {
                if (!file.Contains(ModulePart)) {
                    continue;
                }
                var moduleName = file.Split(ModulePart)[1].Split(".")[0].ToLowerInvariant();
                var enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");
                if (!enabled) {

                    diabledModules.Add(moduleName);
                }
            }

            foreach (var disabledModule in diabledModules) {
                files.Remove(disabledModule);
            }
            files.ForEach(file => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(file))));

            return assemblies;
        }

        public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
            => assemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(@type => typeof(IModule).IsAssignableFrom(@type) && !@type.IsInterface)
                .OrderBy(@type => type.Name)
                .Select(Activator.CreateInstance)
                .Cast<IModule>()
                .ToList();
        public static IList<IModuleGuiConnector> LoadModuleGuiConnector(IEnumerable<Assembly> assemblies)
              => assemblies.SelectMany(assembly => assembly.GetTypes())
                  .Where(@type => typeof(IModuleGuiConnector).IsAssignableFrom(@type) && !@type.IsInterface)
                  .OrderBy(@type => type.Name)
                  .Select(Activator.CreateInstance)
                  .Cast<IModuleGuiConnector>()
                  .ToList();

    }
}
