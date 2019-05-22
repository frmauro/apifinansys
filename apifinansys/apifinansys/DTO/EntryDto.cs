using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.DTO
{
    public class EntryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Paid { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
