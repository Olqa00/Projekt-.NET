using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Models;

namespace Projekt_2.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt_2.Models.Product> Product { get; set; }
        public DbSet<Projekt_2.Models.Category> Category { get; set; }
        public DbSet<Projekt_2.Models.ProductCategory> ProductCategory { get; set; }
        public DbSet<Projekt_2.Models.ProductType> ProductType { get; set; }
        public DbSet<Projekt_2.Models.SiteUser> SiteUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<ProductType>().ToTable("ProductType");
            modelBuilder.Entity<SiteUser>().ToTable("SiteUser");
        }
        
    }
}
