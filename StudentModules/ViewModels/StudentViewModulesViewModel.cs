using Prism.Commands;
using Prism.Mvvm;
using StudentModules.Datas;
using StudentModules.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentModules.ViewModels
{
    public class StudentViewModulesViewModel : BindableBase
    {
        private List<Developer> _developers;
        private readonly IDeveloperService _developerService;
        public List<Developer> Developers
            
        {
            get { return _developers; }
            set
            {
                SetProperty(ref _developers, value);
                RaisePropertyChanged();
            }
        }
        public StudentViewModulesViewModel(IDeveloperService developerService)
        {

            _developerService = developerService;
            _developers = _developerService.GetDevelopers();

        }

    }
}
