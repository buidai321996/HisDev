using Datas;
using DeveloperModules.Views;
using DevExpress.Xpf.Core;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DeveloperProduct.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IAppCompositeCommand _applicationCommands;
        public IAppCompositeCommand AppCompositeCommand
        {
            get { return _applicationCommands; }
            set
            {
                SetProperty(ref _applicationCommands, value);
                RaisePropertyChanged();

            }
        }
        public DelegateCommand<string> AddTabCommand { get; set; }
        public ObservableCollection<DXTabItem> DocPanelList { get; set; }
        private UCContent _content { get; set; }
        public MainWindowViewModel(IAppCompositeCommand applicationCommands, UCContent content)
        {
            _applicationCommands = applicationCommands;
            AddTabCommand = new DelegateCommand<string>(GetTabStudent);
            DocPanelList = new ObservableCollection<DXTabItem>();
            _applicationCommands.CompositeCommandSave.RegisterCommand(AddTabCommand);
            _content = content;
        }

        private void GetTabStudent(string obj)
        {



            Task.Run(async () =>
            {
                if (obj == "Student")
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var documentPanel = new DXTabItem
                        {
                           Header="Student",
                            AllowHide = DevExpress.Utils.DefaultBoolean.True,
                            Content = _content
                        };
                        DocPanelList.Add(documentPanel);
                        //documentPanel.Content = ;
                    });

                }
                
                await Task.CompletedTask;
            });
        }

       
    }
}
