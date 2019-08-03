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
    public class DeliveryUnitRepository : Repository<DeliveryUnit>
    {
        public DeliveryUnitRepository(StudentContext studentContext ):base(studentContext)
        {

        }
    }
}
