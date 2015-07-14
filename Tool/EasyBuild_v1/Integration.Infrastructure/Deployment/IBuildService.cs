namespace Integration.Infrastructure.Deployment
{
    using Integration.Infrastructure.DataContract;
    public interface IBuildService
    {
        BuildServiceResult Build(BuildContext context);
    }
}
