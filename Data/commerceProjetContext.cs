using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using commerceProjet.Models;

namespace commerceProjet.Data
{
    public class commerceProjetContext : DbContext
    {
        public commerceProjetContext (DbContextOptions<commerceProjetContext> options)
            : base(options)
        {
        }

        public DbSet<commerceProjet.Models.Product> Product { get; set; } = default!;
        public DbSet<commerceProjet.Models.Order> Order { get; set; } = default!;
        public DbSet<commerceProjet.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<commerceProjet.Models.Customer> Customer { get; set; } = default!;
        public DbSet<commerceProjet.Models.Category> Category { get; set; } = default!;
    }
}
