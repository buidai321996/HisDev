using Datas;
using Datas.Models;
using DeveloperModules;
using DeveloperModules.Datas;
using DeveloperModules.ViewModels;
using DeveloperModules.Views;
using DeveloperProduct.Views;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using Oracle.ManagedDataAccess.Client;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Data.Common;
using System.Windows;
using Until;

namespace DeveloperProduct
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var ten = new NotificationService()
            {
                UseWin8NotificationsIfAvailable = true,
                ApplicationId = "Hospital Information System",
                CustomNotificationPosition = NotificationPosition.TopRight,
                PredefinedNotificationTemplate = NotificationTemplate.ShortHeaderAndTwoTextFields,
                CustomNotificationVisibleMaxCount = 3,
                CustomNotificationTemplate = new DataTemplate
                {
                    DataType = typeof(NotifyShowViewModel),
                    VisualTree = new FrameworkElementFactory(typeof(NotifyShow))
                }
            };
            containerRegistry.RegisterInstance<INotificationService>(ten);

            containerRegistry.RegisterInstance<IDialogService>(new DialogService
            {
                DialogWindowStartupLocation= WindowStartupLocation.CenterScreen,
                DialogStyle = new Style()
                {
                    Setters = { new Setter(FrameworkElement.WidthProperty, 600d), new Setter(FrameworkElement.HeightProperty, 600d) }
                },
                Title = "aloso",
                ViewTemplate = new DataTemplate
                {
                    DataType = typeof(RegistrationViewViewModel),
                    VisualTree = new FrameworkElementFactory(typeof(RegistrationView))
                }

            });
            //containerRegistry.RegisterSingleton<IRepository<Student>, Repository<Student>>();
            //containerRegistry.RegisterSingleton<IStudentService, StudentService>();
            //GetDbConnection(containerRegistry);
            containerRegistry.RegisterSingleton<IRepository<Student>, StudentRepository>();
            containerRegistry.RegisterSingleton<IStudentService, StudentService>();
            containerRegistry.RegisterSingleton<IAppCompositeCommand, AppCompositeCommand>();
            //containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
            RegisterDatabaseProviderConnection(DatabaseProviderName.ORACLE, containerRegistry);



            containerRegistry.RegisterInstance(new UCContent());


        }
        protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        {

            base.RegisterRequiredTypes(containerRegistry);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type moduleStudent = typeof(DeveloperModulesModule);

            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleStudent.Name,
                ModuleType = moduleStudent.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
            base.ConfigureModuleCatalog(moduleCatalog);
        }

        private void RegisterDatabaseProviderConnection(DatabaseProviderName databaseProviderName,
             IContainerRegistry containerRegistry)
        {
            var databaseFactory = new DatabaseProvider.DatabaseFactory();
            var dbConnection = databaseFactory.GetDatabaseProviderConnection(databaseProviderName);
            //dbConnection.Open();
            containerRegistry.RegisterInstance(dbConnection);
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            var dbConnection = Container.Resolve<DbConnection>();
            dbConnection.Close();
        }
    }
}
