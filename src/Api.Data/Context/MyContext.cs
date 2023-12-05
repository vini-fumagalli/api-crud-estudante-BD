using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context;

public class MyContext : DbContext
{
    public DbSet<StudentEntity> STUDENTS { get; set; } = default!;

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>()
        .HasKey(e => new { e.NameId });
    }
}