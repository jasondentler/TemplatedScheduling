using System.Linq;
using ISIS.Scheduling;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Config.Ninject;
using Ncqrs.Eventing.Storage;
using Ninject;
using Ninject.Modules;
using TechTalk.SpecFlow;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Schedule
{
    [Binding]
    public class Bootstrapper
    {

        [BeforeScenario("domain")]
        public void SetupDomain()
        {
            if (NcqrsEnvironment.IsConfigured)
                NcqrsEnvironment.Deconfigure();

            var kernel = new StandardKernel(new NcqrsModule(), new CommandMappingModule());
            var cfg = new NinjectConfiguration(kernel);
            NcqrsEnvironment.Configure(cfg);
        }

        private class NcqrsModule : NinjectModule 
        {
            public override void Load()
            {
                var commandService = new CommandService();

                commandService.RegisterExecutorsInAssembly(typeof (CreateCourse).Assembly);

                Kernel.Bind<ICommandService>()
                    .ToConstant(commandService);

                Kernel.Bind<CommandService>()
                    .ToConstant(commandService);

                Kernel.Bind<IEventStore>()
                    .ToConstant(new InMemoryEventStore());
            }
        }

        private class CommandMappingModule : NinjectModule
        {
            public override void Load()
            {
                var mappingAsm = typeof (IMapping).Assembly;
                var mappingTypes = mappingAsm.GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract &&
                                typeof (IMapping).IsAssignableFrom(t))
                    .ToArray();


                foreach (var mappingType in mappingTypes)
                    Kernel.Bind<IMapping>().To(mappingType);

                foreach (var mapping in Kernel.GetAll<IMapping>())
                    mapping.Register();

                return;
            }
        }

    }
}
