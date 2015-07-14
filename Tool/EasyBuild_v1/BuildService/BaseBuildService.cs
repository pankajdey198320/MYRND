
namespace BuildService
{
    using System.Collections.Generic;
    using Integration.Infrastructure.DataContract;
    using Integration.Infrastructure.Deployment;
    using Microsoft.Build.Evaluation;
    using Microsoft.Build.Execution;
    using System.Linq;
    public class BaseBuildService : IBuildService
    {
        public Integration.Infrastructure.DataContract.BuildServiceResult Build(BuildContext context)
        {
            var GlobalProperties = context.BuildProperties.Where(p => p.Type == BuildContext.BuilConfiguration.BuildConfigurationType.GlobalProperties).ToDictionary(p => p.Key, i => i.Value);

            //GlobalProperties.Add("Configuration", "Release");
            //GlobalProperties.Add("VisualStudioVersion", "14.0");
            //GlobalProperties.Add("DeployOnBuild", "true");
            //GlobalProperties.Add("PublishProfile", @"Z:\cl\OurClysar\BuildScripts\PublishProfile\QA-Build.pubxml");

            //Microsoft.Build.Evaluation.Project p = new Microsoft.Build.Evaluation.Project(@"Z:\cl\OurClysar\ClysarWeb\Clysar\Clysar.csproj", GlobalProperties,"12.0");
            //p.Build("Build",new List<ILogger>() {  new ConsoleLogger()});
            //var res = p.Build();


            string projectFileName = context.SourceLocation;// @"Z:\cl\OurClysar\ClysarWeb\Clysar.WinServices\Clysar.WinServices.csproj";//  @"Z:\cl\OurClysar\ClysarWeb\Clysar\Clysar.csproj";
            //@"Z:\cl\OurClysar\ClysarWeb\Clysar.WinServices\Clysar.WinServices.csproj";// 
            ProjectCollection pc = new ProjectCollection();




            BuildRequestData BuidlRequest = new BuildRequestData(projectFileName, GlobalProperties, null, new string[] { "Build" }, null);



            BuildResult buildResult = BuildManager.DefaultBuildManager.Build(new BuildParameters(pc)
            {

            }, BuidlRequest);
            return null;
        }

        public void RunBuild()
		{
			Dictionary<string, string> GlobalProperties = new Dictionary<string, string>();
			GlobalProperties.Add("Configuration", "Release");
			GlobalProperties.Add("VisualStudioVersion", "14.0");
			GlobalProperties.Add("DeployOnBuild", "true");
			GlobalProperties.Add("PublishProfile", @"Z:\cl\OurClysar\BuildScripts\PublishProfile\QA-Build.pubxml");

            //Microsoft.Build.Evaluation.Project p = new Microsoft.Build.Evaluation.Project(@"Z:\cl\OurClysar\ClysarWeb\Clysar\Clysar.csproj", GlobalProperties,"12.0");
            //p.Build("Build",new List<ILogger>() {  new ConsoleLogger()});
            //var res = p.Build();


            string projectFileName = @"Z:\cl\OurClysar\ClysarWeb\Clysar.WinServices\Clysar.WinServices.csproj";//  @"Z:\cl\OurClysar\ClysarWeb\Clysar\Clysar.csproj";
            //@"Z:\cl\OurClysar\ClysarWeb\Clysar.WinServices\Clysar.WinServices.csproj";// 
            ProjectCollection pc = new ProjectCollection();

			


			BuildRequestData BuidlRequest = new BuildRequestData(projectFileName, GlobalProperties, null, new string[] { "Build" }, null);



            BuildResult buildResult = BuildManager.DefaultBuildManager.Build(new BuildParameters(pc) {
				
			}, BuidlRequest);
		}
	}
}
