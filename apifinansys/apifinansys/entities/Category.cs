﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.entities
{
    public class Category : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
