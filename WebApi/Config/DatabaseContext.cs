using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Config
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=web_api_bdd.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostEntity>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Post)
                .OnDelete(DeleteBehavior.SetNull);
                ;
            modelBuilder.Entity<CommentEntity>().HasOne<AuthorEntity>(post => post.Author);
        }
        
        
        
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
    }
}