namespace Localwire.Graphinder.Algorithms.WorkerApi
{
    using System.Reflection;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Service.Configuration;
    using Service.Configuration.Base;
    using Service.CurrentWork;
    using Service.CurrentWork.Base;

    public static class DependencyRegistration
    {
        public static ContainerBuilder WithControllersRegistered(this ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            return builder;
        }

        public static ContainerBuilder WithServicesRegistered(this ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionTester>().As<IConnectionTester>();
            builder.RegisterType<EntityFrameworkConnectionBuilder>().As<IConnectionStringBuilder>();

            builder.RegisterType<WorkerConfiguration>().As<IWorkerConfiguration>().SingleInstance();
            builder.RegisterType<WorkerScheduler>().As<IWorkerScheduler>().SingleInstance();
            return builder;
        }
    }
}