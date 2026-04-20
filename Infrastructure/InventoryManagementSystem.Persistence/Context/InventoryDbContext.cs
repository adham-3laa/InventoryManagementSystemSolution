using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSystem.Persistence.Context
{
    public class InventoryDbContext:DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDbContext).Assembly);
        }

    }
}
