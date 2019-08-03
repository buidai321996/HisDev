using DevExpress.Mvvm.DataAnnotations;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperModules.ViewModels
{
    [POCOViewModel]
    public class NotifyShowViewModel 
    {
            public virtual string Caption { get; set; }
            public virtual string Content { get; set; }    
    }
}
