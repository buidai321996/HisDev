using DataDev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModules.Models
{
    public class Developer : BaseEntity
    {
        public int DeveloperID { get; set; }
        public string DeveloperName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DeliveryUnitId { get; set; }
        public DeliveryUnit DeliveryUnit { get; set; }
    }
}
