using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            this.DataCriacao = DateTime.Now;
            this.Ativo = true;
        }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public  ICollection<Entry> Entries { get; set; }
    }
}
