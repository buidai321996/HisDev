﻿using Datas.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas.Events
{
    public class EventAggrator : PubSubEvent<Student>
    {
    }
}
