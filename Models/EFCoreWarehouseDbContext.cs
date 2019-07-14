using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCoreReact.Models
{
    public class EFCoreWarehouseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=XXXX; Database=EFCoreWarehouseDb; Trusted_Connection=True;");
        }

        public DbSet<StoreModel> Store { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<CustomerModel> Customer { get; set; }
        public DbSet<SalesModel> Sales { get; set; }
    }
}
