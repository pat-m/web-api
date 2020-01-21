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
                .HasMany(c => c.Comments).WithOne(x => x.Post).HasForeignKey(x => x.Id)
                ;
            modelBuilder.Entity<AuthorEntity>();
            modelBuilder.Entity<CommentEntity>()
                .HasOne(post => post.Author);
        }
        
        
        
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
    }
}