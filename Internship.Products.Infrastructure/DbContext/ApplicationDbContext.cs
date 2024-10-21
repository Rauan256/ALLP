using Internship.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Internship.Products.Infrastructure.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}