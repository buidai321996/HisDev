using Datas.Models;
using DeveloperModules.Datas;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows;

namespace DeveloperModules.ViewModels
{
    public class PatientInformationPopUpViewModel : BindableBase
    {
        private List<Student> _personList;
        private readonly IStudentService _studentService;
        private Student _student;
        private ICommand CommandGridDoubleClick { get; set; }
        public PatientInformationPopUpViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            //PersonList = _studentService.FindAll();
            CommandGridDoubleClick = new DelegateCommand(GridDoubleClick);
        }

        private void GridDoubleClick()
        {
            var a = Student;
        }

        public List<Student> PersonList
        {
            get { return _personList; }
            set
            {
                SetProperty(ref _personList, value);
                RaisePropertyChanged();
            }
        }
        public Student Student
        {
            get { return _student; }
            set
            {
                SetProperty(ref _student, value);
                RaisePropertyChanged();
            }
        }
    }
}
