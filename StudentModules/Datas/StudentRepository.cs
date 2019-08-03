using DataDev;
using StudentModules.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModules.Datas
{
    public class StudentRepository:Repository<Developer>
    {
        public StudentRepository(StudentContext studentContext):base(studentContext)
        {

        }
    }
}
