using Microsoft.EntityFrameworkCore;
public class MyDbContext : DbContext
{
    static readonly string connectionString = "server=localhost;database=dev_rage_server;user=root;password=fcGWZeK92M*MBK";

    public DbSet<Users> Users { get; set; }
    public DbSet<UserCustomization> UserCustomizations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Однозначная связь User и UserCustomization
        modelBuilder.Entity<Users>()
            .HasOne(u => u.UserCustomization)
            .WithOne(uc => uc.Users)
            .HasForeignKey<UserCustomization>(uc => uc.UserId);
    }
}