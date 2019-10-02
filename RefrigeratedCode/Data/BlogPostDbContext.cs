using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RefrigeratedCode.Models;

namespace RefrigeratedCode.Data
{
    public class BlogPostDbContext : DbContext
    {
        private IConfigurationRoot _config;

        public BlogPostDbContext (IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<BlogPost> BlogPosts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:BlogPostConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BlogPost>().HasKey(post => post.PostId);
            modelBuilder.Entity<BlogPost>().Property(post => post.PostId).HasColumnName("PostID");

            modelBuilder.Entity<BlogPost>().ToTable("BlogPosts");

        }
    }
}
