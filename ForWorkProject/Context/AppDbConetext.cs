using ForWorkProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForWorkProject.Context;

public class AppDbContext:DbContext
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
