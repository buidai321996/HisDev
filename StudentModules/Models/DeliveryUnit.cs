using DataDev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModules.Models
{
    public class DeliveryUnit : BaseEntity
    {
        public int DeliveryUnitID { get; set; }
        public string DeliveryUnitName { get; set; }
        public string Description { get; set; }
        public ICollection<Developer> Developers { get; set; }

       
    }
}
