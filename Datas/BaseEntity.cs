using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datas
{
    public abstract class BaseEntity<TId> : IEntity<TId>
    {
        public virtual TId Id { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<int>
    {

    }
}
