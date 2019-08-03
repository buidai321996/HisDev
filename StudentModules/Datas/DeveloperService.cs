using DataDev;
using Prism.Events;
using StudentModules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModules.Datas
{
    public class DeveloperService: IDeveloperService
    {
        private readonly IRepository<Developer> _developers;
        private readonly IRepository<DeliveryUnit> _deliveryUnits;
        private readonly IEventAggregator _eventAggregator;
        public DeveloperService(IRepository<Developer> developers, IRepository<DeliveryUnit> deliveryUnits,IEventAggregator eventAggregator)
        {
            _developers = developers;
            _deliveryUnits = deliveryUnits;
            _eventAggregator = eventAggregator;
        }

        public List<Developer> GetDevelopers()
        {
            return _developers.FindAll();
        }
    }

    public interface IDeveloperService
    {
        List<Developer> GetDevelopers();
    }
}
