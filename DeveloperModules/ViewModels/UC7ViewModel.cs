using Datas.Models;
using DeveloperModules.Datas;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DelegateCommand = Prism.Commands.DelegateCommand;
using BindableBase = Prism.Mvvm.BindableBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Datas.Events;
using Prism.Events;

namespace DeveloperModules.ViewModels
{
    public class UC7ViewModel : BindableBase, ISupportServices
    {

        //[DevExpress.Mvvm.DataAnnotations.ServiceProperty(Key = "ServiceWithDefaultNotifications")]

        protected INotificationService _CustomtNotificationService;
        public Student PersonsData { get; set; }
        IEventAggregator _ea;
        private Student _student;
        private List<Student> _personList;
        private readonly IStudentService _studentService;
        public DelegateCommand<Student> DeleteDelegateComand { get; set; }
        public DelegateCommand UpdateDelegateComand { get; set; }
        public DelegateCommand DeleteCommandPopup { get; set; }
        public DelegateCommand<Student> UpdateButtonDelegateComand { get; set; }
        //protected IDialogService DialogService { get { return this.GetService<IDialogService>(); } }
        //public void ShowRegistrationForm()
        //{
        //    RegistrationViewViewModel registrationViewModel = ViewModelSource.Create(() => new RegistrationViewViewModel());
        //    DialogService.ShowDialog(
        //        dialogCommands: null,
        //        title: "Registration Dialog",
        //        viewModel: registrationViewModel);
        //}
        protected IDialogService DialogService { get { return this.GetService<IDialogService>(); } }

        public void ShowRegistrationForm(Student obj)
        {

            //RegistrationViewViewModel RegistrationViewModel = new RegistrationViewViewModel(_ea);
            if (obj == null) return;
            var std = new Student()
            {
                Name = obj.Name,
                Age = obj.Age,
                ClassName = obj.ClassName,
                Description = obj.Description
            };
            DialogService.ShowDialog(null,
           "Registration Dialog",
           new RegistrationViewViewModel(std, _studentService, _CustomtNotificationService));

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
        public List<Student> PersonList
        {
            get { return _personList; }
            set
            {
                SetProperty(ref _personList, value);
                RaisePropertyChanged();
            }
        }

        private IServiceContainer serviceContainer;
        public IServiceContainer ServiceContainer
        {

            get
            {
                if (serviceContainer == null)
                    serviceContainer = new ServiceContainer(this);
                return serviceContainer;
            }
        }
        IServiceContainer ISupportServices.ServiceContainer { get { return ServiceContainer; } }

        public UC7ViewModel(IStudentService studentService, INotificationService notificationService, IEventAggregator ea)
        {
            //var a = PersonsData;
            _ea = ea;
            _CustomtNotificationService = notificationService;
            _studentService = studentService;
            DeleteDelegateComand = new DelegateCommand<Student>(DeleteStudent);
            UpdateDelegateComand = new DelegateCommand(UpdateStudent);
            UpdateButtonDelegateComand = new DelegateCommand<Student>(UpdateButton);
            DeleteCommandPopup = new DelegateCommand(DeleteCommandPopup1);
            PersonList = _studentService.FindAll().ToList();
        }

        private void DeleteCommandPopup1()
        {
            _studentService.Remove(PersonsData);


            //INotification notification = DefaultNotificationService.CreatePredefinedNotification("Remove thành Công",
            //    "aloso", String.Format("Second line. Time: {0}", DateTime.Now), null);

            //notification.ShowAsync();
            var vm = new NotifyShowViewModel()
            {
                Caption = "Xoá thành công!",
                Content = $"Đã xoá phẩn tử {PersonsData.Name} khỏi danh sách."
            };

            INotification notification = _CustomtNotificationService.CreateCustomNotification(vm);
            notification.ShowAsync();
            PersonList = _studentService.FindAll();
        }

        private void UpdateButton(Student obj)
        {
            ShowRegistrationForm(obj);
            PersonList = _studentService.FindAll();
        }

        private void UpdateStudent()
        {

            ShowRegistrationForm(PersonsData);
            PersonList = _studentService.FindAll();
        }

        private void DeleteStudent(Student student)
        {
            _studentService.Remove(student);
            PersonList = _studentService.FindAll();

            //INotification notification = DefaultNotificationService.CreatePredefinedNotification("Remove thành Công",
            //    "aloso", String.Format("Second line. Time: {0}", DateTime.Now), null);

            //notification.ShowAsync();
            var vm = new NotifyShowViewModel()
            {
                Caption = "Xoá thành công!",
                Content = $"Đã xoá phẩn tử {student.Name} khỏi danh sách."
            };

            INotification notification = _CustomtNotificationService.CreateCustomNotification(vm);
            notification.ShowAsync();
        }
    }
}
