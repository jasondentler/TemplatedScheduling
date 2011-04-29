using System;
using ISIS.Commands;
using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Config.Ninject;
using Ncqrs.Eventing.Storage;
using Ninject;
using Ninject.Modules;
using TechTalk.SpecFlow;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace ISIS.Domain.Tests
{
    [Binding]
    public class Bootstrapper
    {

        [BeforeScenario("domain")]
        public void SetupDomain()
        {
            if (NcqrsEnvironment.IsConfigured)
                NcqrsEnvironment.Deconfigure();

            var kernel = new StandardKernel(new NcqrsModule());
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

                Kernel.Bind<IEventStore>()
                    .ToConstant(new InMemoryEventStore());
            }
        }

    }
}
