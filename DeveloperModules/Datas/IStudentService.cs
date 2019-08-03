using Datas.Models;
using System.Collections.Generic;

namespace DeveloperModules.Datas
{
    public interface IStudentService
    {
        //List<Student> FindAll();
        int Remove(Student student);
        void AddOrUpdate(Student student);


    }
}