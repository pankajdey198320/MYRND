namespace Integration.Infrastructure.SourceControl
{
    using Integration.Infrastructure.DataContract;

    public interface IRepositoryService
    {
        SyncResult SyncToUpdate(SourceContext context);
    }
}
