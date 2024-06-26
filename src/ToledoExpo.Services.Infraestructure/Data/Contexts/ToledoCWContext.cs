using Microsoft.EntityFrameworkCore;
using ToledoExpo.Services.Core.Entities;

namespace ToledoExpo.Services.Infraestructure.Data.Contexts;

public class ToledoCWContext : DbContext
{
    public ToledoCWContext()
    {
        
    }

    public ToledoCWContext(DbContextOptions<ToledoCWContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToledoCWContext).Assembly);

        modelBuilder.Ignore<Entity>();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=toledocw;Uid=root;Pwd=root321;");
        }
    }

}