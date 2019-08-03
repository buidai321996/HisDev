using StudentModules.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using DataDev;
using StudentModules.Models;
using StudentModules.Datas;

namespace StudentModules
{
    public class StudentModulesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainContentRegion", typeof(Views.StudentViewModules));
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRepository<Developer>, StudentRepository>();
            containerRegistry.RegisterSingleton<IRepository<DeliveryUnit>, DeliveryUnitRepository>();
            containerRegistry.RegisterSingleton<IDeveloperService, DeveloperService>();
        }

        //public void RegisterTypes(IContainerRegistry containerRegistry)
        //{
        //    containerRegistry.RegisterForNavigation<StudentViewModules>();
        //}

    }
}