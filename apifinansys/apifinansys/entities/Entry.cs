using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.entities
{
    public class Entry : EntityBase
    {
        public string Name { get; set; }
        public bool Paid { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
