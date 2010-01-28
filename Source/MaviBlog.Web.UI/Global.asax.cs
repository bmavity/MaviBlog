using AutoMapper;
using FubuMVC.Core;
using FubuMVC.StructureMap.Bootstrap;
using FubuMVC.View.Spark;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace MaviBlog.Web.UI
{
    public class Global : FubuStructureMapApplication
    {
        public override FubuRegistry GetMyRegistry()
        {
            return new MaviBlogUiFubuRegistry();
        }

        public override void InitializeStructureMap(IInitializationExpression init)
        {
            init.AddRegistry<CoreStructureMapRegistry>();

            init.AddRegistry<AutoMapperStructureMapRegistry>();
        }
    }

    public class AutoMapperStructureMapRegistry : Registry
    {
        public AutoMapperStructureMapRegistry()
        {
            For<IMappingEngine>().Use(Mapper.Engine);
        }
    }

    public class MaviBlogUiFubuRegistry : FubuRegistry
    {
        public MaviBlogUiFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies.ToThisAssembly();

            Actions
                .IncludeTypesNamed(x => x.EndsWith("Controller"));

            Routes
                .IgnoreControllerNamespaceEntirely()
                .IgnoreMethodsNamed("index");

            Views
                .TryToAttach(x =>
                {
                    x.to_spark_view_by_action_namespace_and_name(GetType().Namespace);
                    x.by_ViewModel_and_Namespace_and_MethodName();
                    x.by_ViewModel_and_Namespace();
                    x.by_ViewModel();
                });
        }
    }
}