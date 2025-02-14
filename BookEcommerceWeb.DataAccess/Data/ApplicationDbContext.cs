﻿using BookEcommerceWeb.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEcommerceWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Hành động", DisplayOrder = 1, CreatedDate=DateTime.UtcNow, UpdatedDate=DateTime.UtcNow },
                new Category { Id = 2, Name = "Khoa học viễn tưởng", DisplayOrder = 2, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                new Category { Id = 3, Name = "Lịch sử", DisplayOrder = 3, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                new Category { Id = 4, Name = "Ngôn tình", DisplayOrder = 4, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow },
                new Category { Id = 5, Name = "Trinh thám", DisplayOrder = 5, CreatedDate = DateTime.UtcNow, UpdatedDate = DateTime.UtcNow }
                );
        }
    }
}
