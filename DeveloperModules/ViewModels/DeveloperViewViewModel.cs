using Datas.Models;
using DeveloperModules.Datas;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperModules.ViewModels
{
    public class DeveloperViewViewModel : BindableBase
    {
        private IStudentService _studentService;
        private List<Student> _developers;
        public List<Student> Developers
        {
            get => _developers;
            set
            {
                SetProperty(ref _developers, value);
                RaisePropertyChanged();
            }
        }
        public DeveloperViewViewModel(IStudentService studentService )
        {
            _studentService = studentService;
            _developers = _studentService.FindAll();
        }
    }
}
