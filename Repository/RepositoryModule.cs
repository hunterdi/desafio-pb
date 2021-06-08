using Architecture;
using Autofac;
using Domain;
using System;

namespace Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<NodeRepository>().As<INodeRepository>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<NodeRepository>().As<IRepositoryBase<Node>>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
        }
    }
}
