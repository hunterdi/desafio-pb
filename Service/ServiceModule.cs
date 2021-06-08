using Architecture;
using Autofac;
using Domain;
using System;

namespace Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<NodeService>().As<INodeService>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<NodeService>().As<IServiceBase<Node>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}
