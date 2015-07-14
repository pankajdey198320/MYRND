namespace BuildTask
{
    using Infrastructure.Interface;
    using Integration.Infrastructure.Deployment;
    using Integration.Infrastructure.SourceControl;

    public class BaseBuildTask : ITask
    {
        private IBuildService _BulidService;
        private IRepositoryService _sourceService;
        public BaseBuildTask(IBuildService bulidService, IRepositoryService sourceService)
        {
            _BulidService = bulidService;
            _sourceService = sourceService;
        }
        public void Run()
        {
            _sourceService.SyncToUpdate(new Integration.Infrastructure.DataContract.SourceContext());

            _BulidService.Build(new Integration.Infrastructure.DataContract.BuildContext());

        }
    }
}
