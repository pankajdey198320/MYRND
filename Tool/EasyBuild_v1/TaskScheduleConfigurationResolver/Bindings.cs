using BuildTask;
using Infrastructure.Interface;

namespace TaskScheduleConfigurationResolver
{
    class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<ITask>().To<BaseBuildTask>().Named("BuildTask");
            Bind<ITask>().To<ConsoleLogTask>().Named("ConsoleLogTask");
        }
    }
}
