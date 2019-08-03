using Datas.Models;
using DeveloperModules.Datas;
using System.Data.Entity;
using System.Windows;

namespace DeveloperProduct.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DeveloperContext>());
           
                InitializeComponent();
        }
    }
}
