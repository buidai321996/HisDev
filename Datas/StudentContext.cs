using DataDev;
using StudentModules.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModules.Datas
{
    public class StudentContext :DbContext
    {
        public StudentContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection,
            contextOwnsConnection)
        {
        }
    }
}
