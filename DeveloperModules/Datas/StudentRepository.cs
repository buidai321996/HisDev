using Datas;
using Datas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperModules.Datas
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(DeveloperContext developerContext):base(developerContext)
        {

        }
    }
}
