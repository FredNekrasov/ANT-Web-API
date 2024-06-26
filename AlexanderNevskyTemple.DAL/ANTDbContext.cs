﻿using AlexanderNevskyTemple.DAL.entities;
using Microsoft.EntityFrameworkCore;

namespace AlexanderNevskyTemple.DAL;

public class ANTDbContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ANT;Integrated Security=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Catalog>().HasMany(i => i.Articles).WithOne(i => i.Catalog).HasForeignKey(i => i.CatalogId);
        modelBuilder.Entity<Article>().HasMany(i => i.Contents).WithOne(i => i.Article).HasForeignKey(i => i.ArticleId);
    }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Content> Contents { get; set; }
}