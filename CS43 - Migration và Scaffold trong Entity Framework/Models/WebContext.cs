using Microsoft.EntityFrameworkCore;

namespace CS43___Migration_v__Scaffold_trong_Entity_Framework
{
    public class WebContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

        private const string connectionString = "Data Source=DESKTOP-9L14R4S\\SQLEXPRESS;Initial Catalog=Webdb;Persist Security Info=True;User ID=sa;Password=123456; TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasIndex(articleTag => new { articleTag.ArticleId, articleTag.TagId })
                      .IsUnique();
            });
        }
    }
}