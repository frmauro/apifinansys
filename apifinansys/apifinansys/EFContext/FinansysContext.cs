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

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>().HasOne(c => c.Category).WithMany(c => c.Entries);
            modelBuilder.Entity<Category>().HasMany(c => c.Entries).WithOne(c => c.Category);
            modelBuilder.RemovePluralizingTableNameConvention();
        }

    }

    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
    }
}
