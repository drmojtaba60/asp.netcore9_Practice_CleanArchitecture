/*namespace MyPractice.Config;

using Autofac;
using System;
using System.Linq;
using ACL.BscOkr_Evaluation.service;
using ACL.Evaluation_Base.service;
using ACL.Evaluation_Notification;
using Evaluation.Application.Contract.Factory;
using Evaluation.Application.Contract.Interface;
using Evaluation.Application.Contract.Interface.Form.Evaluation;
using Evaluation.Application.Service;
using Evaluation.Persistence.EF;
using Evaluation.Persistence.EF.UnitOfWork;
using Framework.Core.Interface;
using Framework.Utility.Extentions;


namespace Evaluation.Config
{
    public static class Bootstrapper
    {
        public static void WireUp(ContainerBuilder builder)
        {

            builder.RegisterType<AclCodingIntervalService>()
                .As<IAclCodingIntervalService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AclNotifyService>()
                .As<IAclNotifyService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AclBaseItemService>()
                .As<IAclBaseItemService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AclKeyResultService>()
                .As<IAclKeyResultService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AclFileManagerService>()
                .As<IAclFileManagerService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<AclOrganizationService>()
                .As<IAclOrganizationService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EvaluationFactory>().As<IEvaluationFactory>().InstancePerLifetimeScope();

            
            builder.RegisterType<PeriodService>().As<IPeriodService>()
                .InstancePerLifetimeScope();            
            builder.RegisterContext<EvaluationDbContext>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            loadedAssemblies
                .SelectMany(x => x.GetReferencedAssemblies())
                .Distinct()
                .Where(y => loadedAssemblies.Any((a) => a.FullName.StartsWith(typeof(Bootstrapper).FullName.Split('.')[0])) == false)
                .ToList()
                .ForEach(x => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(x)));

            var assemblies = loadedAssemblies
                .Where(x => x.FullName.StartsWith(typeof(Bootstrapper).FullName.Split('.')[0]));

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .Where(t => t.IsClass == true && t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IRepository))))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .Where(t => t.IsClass == true && t.FullName.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .Where(t => t.IsClass == true && t.FullName.EndsWith("Evaluation"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblies.ToArray())
                .Where(t => t.IsClass == true && t.FullName.EndsWith("Controller"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


        }
    }
}
*/