using Datas.Events;
using Datas.Models;
using DeveloperModules.Datas;
using DevExpress.Mvvm;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using DelegateCommand = Prism.Commands.DelegateCommand;
using BindableBase = Prism.Mvvm.BindableBase;
using System.Linq;

namespace DeveloperModules.ViewModels
{
    public class RegistrationViewViewModel : BindableBase
    {
        protected INotificationService _CustomtNotificationService;
        private readonly IStudentService _studentService;
        private Student _student;
        public DelegateCommand UpdateDelegateCommand { get; set; }
        public  Student StudentData
        {
            get { return _student; }
            set { SetProperty(ref _student, value);
                RaisePropertyChanged();
                }
        }
        public RegistrationViewViewModel(Student StudentData,IStudentService studentService, INotificationService CustomtNotificationService)
        {
            _CustomtNotificationService = CustomtNotificationService;
            _studentService = studentService;
            this.StudentData = StudentData;
            UpdateDelegateCommand = new DelegateCommand(UpdateStudent);
            //_ev = ev;
            //_ev.GetEvent<EventAggrator>().Subscribe(GetStudent);

        }

        private void UpdateStudent()
        {
            _studentService.AddOrUpdate(StudentData);
            var vm = new NotifyShowViewModel()
            {
                Caption = "Sửa thành công!",
                Content = $"Đã sửa phẩn tử ID: {StudentData.Id} trong danh sách."
            };

            INotification notification = _CustomtNotificationService.CreateCustomNotification(vm);
            notification.ShowAsync();

        }

       

      

        public static Student UserName { get;  set; }

       
    }
}
