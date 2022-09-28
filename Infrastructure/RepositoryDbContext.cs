using System.Security.Principal;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class RepositoryDbContext : Microsoft.EntityFrameworkCore.DbContext
{

    public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options, ServiceLifetime serviceLifetime) :
        base(options)
    {
        
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //AUTO generate ID
        modelBuilder.Entity<Account>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        
        
        modelBuilder.Entity<Person>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

        //Foregin key to author ID
        modelBuilder.Entity<Account>()
            .HasOne(account => account.Person)
            .WithMany(l => l.Accounts)
            .HasForeignKey(review => review.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Account>().HasData(new Account{Id = 1, Balance = "2232",  OwnerId = 1});
        
        modelBuilder.Entity<Person>().HasData(new Person{ Id = 1, FName = "hans", LName ="petersen",
            Adr = "Easv"});
        
    }

    public DbSet<Account> AccountTable { get; set; }
    public DbSet<Person> PersonTable { get; set; }

    
}