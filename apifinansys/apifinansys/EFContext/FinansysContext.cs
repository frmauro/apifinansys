using apifinansys.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apifinansys.EFContext
{
    public class FinansysContext : DbContext
    {
        public FinansysContext(DbContextOptions<FinansysContext> options) 
            :base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
