﻿using de_todo_chill.Models;
using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace de_todo_chill.Contexts;

public class MysqlDbContext: DbContext
{
    public MysqlDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
           
        // modelBuilder.Entity<User>().ToTable("users");
        // modelBuilder.Entity<Product>().ToTable("products");
        // modelBuilder.Entity<CartItems>().ToTable("cartItems");
        // modelBuilder.Entity<Suggestions>().ToTable("suggestions");
    }

    public virtual DbSet<User> Users { set; get; }
    public virtual DbSet<Product> Products { set; get; }
    public virtual DbSet<CartItems> CartItems { set; get; }
    public virtual DbSet<Suggestion> Suggestions { set; get; }
}