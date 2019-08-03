using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DeveloperModules.ViewModels
{
    public class UC3ViewModel : BindableBase
    {
        
        private string _mail;
        private string _age;

        public UC3ViewModel()
        {

        }
       
        public string Mail
        {
            get { return _mail; }
            set
            {
                SetProperty(ref _mail, value);
                RaisePropertyChanged();
            }
        }
        public string Age
        {
            get { return _age; }
            set
            {
                SetProperty(ref _age, value);
                RaisePropertyChanged();
            }
        }



    }
}
