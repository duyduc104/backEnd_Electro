using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using electroMVC.Models;

namespace electroMVC.Data
{
    public class electroMVCContext : DbContext
    {
        public electroMVCContext (DbContextOptions<electroMVCContext> options)
            : base(options)
        {
        }

        public DbSet<electroMVC.Models.User> User { get; set; } = default!;
        public DbSet<electroMVC.Models.Brand> Brand { get; set; } = default!;
        public DbSet<electroMVC.Models.Category> Category { get; set; } = default!;
        public DbSet<electroMVC.Models.Product> Product { get; set; } = default!;
    }
}
