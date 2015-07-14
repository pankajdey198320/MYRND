using System;
using System.Configuration.Install;
using System.ServiceProcess;

namespace BuildService
{
    public class Installer
    {
        public void Install() {
            ServiceProcessInstaller ProcesServiceInstaller = new ServiceProcessInstaller();
            ProcesServiceInstaller.Account = ServiceAccount.User;
         //   ProcesServiceInstaller.Username = "<<username>>";
          //  ProcesServiceInstaller.Password = "<<password>>";

            ServiceInstaller ServiceInstallerObj = new ServiceInstaller();
            InstallContext Context = new System.Configuration.Install.InstallContext();
            String path = String.Format("/assemblypath={0}", @"Z:\cl\OurClysar\ClysarWeb\Clysar.WinServices\bin\Debug\Clysar.WinServices.exe");
            String[] cmdline = { path };

            Context = new InstallContext("", cmdline);
            ServiceInstallerObj.Context = Context;
            ServiceInstallerObj.DisplayName = "MiddleWare";
            ServiceInstallerObj.Description = "Middleware installer test";
            ServiceInstallerObj.ServiceName = "Middleware";
            ServiceInstallerObj.StartType = ServiceStartMode.Automatic;
            ServiceInstallerObj.Parent = ProcesServiceInstaller;

            System.Collections.Specialized.ListDictionary state = new System.Collections.Specialized.ListDictionary();
           ServiceInstallerObj.Uninstall(null);// 
          // ServiceInstallerObj.Install(state); 
        }
    }
}
