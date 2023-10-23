using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using CriminalsCloudApp.Models;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

  
    public DbSet<Criminal> Criminals { get; set; }
}
