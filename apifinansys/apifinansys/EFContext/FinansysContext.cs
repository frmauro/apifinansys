using apifinansys.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This will singularize all table names
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.DisplayName();
            }
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
