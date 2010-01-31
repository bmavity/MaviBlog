using System;
using System.Collections.Generic;
using AutoMapper;
using FubuMVC.Core;
using FubuMVC.StructureMap.Bootstrap;
using FubuMVC.View.Spark;
using MaviBlog.Web.Controllers.Home;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace MaviBlog.Web
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

            new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "GET", "POST", "PUT", "HEAD" }
                .Each(verb =>
                    Routes.ConstrainToHttpMethod(action => action.Method.Name.Equals(verb, StringComparison.InvariantCultureIgnoreCase),
                    verb));

            Routes
                .IgnoreControllerNamespaceEntirely()
                .IgnoreMethodsNamed("get")
                .IgnoreMethodsNamed("post");

            Views
                .TryToAttach(x =>
                {
                    x.to_spark_view_by_action_namespace_and_name(GetType().Namespace);
                    x.by_ViewModel_and_Namespace_and_MethodName();
                    x.by_ViewModel_and_Namespace();
                    x.by_ViewModel();
                });

            HomeIs<HomeController>(x => x.Index());
        }
    }
}