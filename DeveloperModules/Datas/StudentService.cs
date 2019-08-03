using Datas;
using Datas.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModules.Datas
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repositoryStudent;
        
        private EventAggregator _eventAggregator;
        public StudentService(EventAggregator eventAggregator, IRepository<Student> repositoryStudent)
        {
            _eventAggregator = eventAggregator;
            _repositoryStudent = repositoryStudent;
        }

        public void AddOrUpdate(Student student)
        {
            _repositoryStudent.AddOrUpdate(student);
            _repositoryStudent.SaveChanges();
        }

        //public List<Student> FindAll()
        //{
        //    return _repositoryStudent.FindAll();
        //}

        public int Remove(Student student)
        {
            _repositoryStudent.Remove(student);
            var a = _repositoryStudent.SaveChanges();
            return _repositoryStudent.SaveChanges();
        }

       
    }
}
