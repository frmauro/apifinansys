using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.entities
{
    public class EntityBase
    {
        public virtual int Id { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual bool Ativo { get; set; }
    }
}
