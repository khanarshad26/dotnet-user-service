using Microsoft.EntityFrameworkCore;

namespace mydotnet.Models;
public class UserDbContext : DbContext
{
    // protected readonly IConfiguration Configuration;

    // public UserDbContext(IConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        options.UseInMemoryDatabase("TestDb");
    }

    public DbSet<User>? Users {get; set;}
    
}