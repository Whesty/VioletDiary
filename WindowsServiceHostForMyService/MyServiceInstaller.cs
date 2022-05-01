using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace WindowsServiceHostForMyService
{
    [RunInstaller(true)]
    public partial class MyServiceInstaller : System.Configuration.Install.Installer
    {
        public MyServiceInstaller()
        {
            // InitializeComponent();
            serviceProcessInstaller1 = new ServiceProcessInstaller();
            serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
            serviceInstaller1 = new ServiceInstaller();
            serviceInstaller1.ServiceName = "WindowsServiceHostForMyService";
            serviceInstaller1.DisplayName = "WindowsServiceHostForMyService";
            serviceInstaller1.Description = "WCF Service Hosted by Windows NT Service";
            serviceInstaller1.StartType = ServiceStartMode.Automatic;
            Installers.Add(serviceProcessInstaller1);
            Installers.Add(serviceInstaller1);
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
