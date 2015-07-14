namespace RepositoryService
{
    using Integration.Infrastructure.DataContract;
    using Integration.Infrastructure.SourceControl;
    using NGit.Api;
    using NGit.Transport;
    public class GitSourceAccessService : IRepositoryService
    {
        public SyncResult SyncToUpdate(SourceContext context)
        {
            var credentials = new UsernamePasswordCredentialsProvider(context.UserCredential.UseName,context.UserCredential.Password.ToString());// ("mfsipankajd", "Surajit@20");

            var repository = Git.Open(context.URL);//  (@"Z:\cl\OurClysar");

            var re = repository.Reset().Call();

            var resl = repository.Pull().SetCredentialsProvider(credentials).Call();
            var returnMsg = new SyncResult();
            if (resl.IsSuccessful())
            {
                returnMsg.IsSuccess = true;
                returnMsg.Message = resl.GetMergeResult().GetMergedCommits().ToString();
                
            }
            else
            {
                returnMsg.IsSuccess = false;
            }
            return returnMsg;
        }
    }
}
