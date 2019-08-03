using Datas;
using Datas.Models;
using DeveloperModules.Datas;
using DeveloperModules.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DeveloperModules
{
    public class DeveloperModulesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainContentRegion2", typeof(Views.UCContent));
            regionManager.RegisterViewWithRegion("MainContentRegion1", typeof(Views.UC9));
            regionManager.RegisterViewWithRegion("MainContentRegion3", typeof(Views.UC3));
            regionManager.RegisterViewWithRegion("MainContentRegion4", typeof(Views.UC4));
            regionManager.RegisterViewWithRegion("MainContentRegion5", typeof(Views.Grid1));
            regionManager.RegisterViewWithRegion("MainContentRegion6", typeof(Views.UC6));
            regionManager.RegisterViewWithRegion("MainContentRegion7", typeof(Views.UC7));
            
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            

        }
    }
}