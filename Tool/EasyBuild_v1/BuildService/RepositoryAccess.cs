using System;
using NGit.Api;
using NGit.Transport;

namespace BuildService
{
    public class RepositoryAccess
	{
		public void Pull()
		{
			var credentials = new UsernamePasswordCredentialsProvider("mfsipankajd", "Surajit@20");

			var repository = Git.Open(@"Z:\cl\OurClysar");
            
			var re=repository.Reset().Call();
			//var res = repository.Fetch().SetRefSpecs(new List<RefSpec>() { new RefSpec() }).SetCredentialsProvider(credentials).Call();
			var resl = repository.Pull().SetCredentialsProvider(credentials).Call();
            if (resl.IsSuccessful()) {
                Console.WriteLine(resl.GetMergeResult().GetMergeStatus());
            }
        }
	}
}
