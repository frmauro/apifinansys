using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.entities
{
    public class Entry : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual bool Paid { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Category Category { get; set; }
    }
}
