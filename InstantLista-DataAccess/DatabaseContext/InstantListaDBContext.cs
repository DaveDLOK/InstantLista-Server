using Microsoft.EntityFrameworkCore;
using InstantLista_ClassLibrary;

namespace InstantLista_DataAccess;

public class InstantListaDBContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public InstantListaDBContext(DbContextOptions<InstantListaDBContext> options):base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //using modelBuilder to map some relationships
        modelBuilder.Entity<User>().ToTable("System.Users");
        modelBuilder.Entity<Membership>().ToTable("System.Memberships");
        modelBuilder.Entity<News>().ToTable("News.News");
    }
}

