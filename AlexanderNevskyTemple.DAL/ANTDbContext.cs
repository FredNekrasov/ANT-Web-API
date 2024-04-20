using AlexanderNevskyTemple.DAL.entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL;

public class ANTDbContext(DbContextOptions<ANTDbContext> dbContextOptions) : DbContext(dbContextOptions) {
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Catalog>().HasMany(i => i.Articles).WithOne(i => i.Catalog).HasForeignKey(i => i.CatalogId);
        modelBuilder.Entity<Article>().HasMany(i => i.Contents).WithOne(i => i.Article).HasForeignKey(i => i.ArticleId);
    }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Content> Contents { get; set; }
}