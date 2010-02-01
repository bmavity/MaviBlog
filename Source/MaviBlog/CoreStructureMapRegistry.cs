using StructureMap.Configuration.DSL;

namespace MaviBlog
{
    public class CoreStructureMapRegistry : Registry
    {
        public CoreStructureMapRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}