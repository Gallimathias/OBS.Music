using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OBS.Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music;

internal class DatabaseContext : DbContext
{
    private readonly IConfiguration configuration;

    public DatabaseContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
        optionsBuilder.UseSqlite($"Data Source={configuration.GetConnectionString("default")}");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly
            .GetAssembly(typeof(Entity))
            ?.GetTypes()
            .Where(type => typeof(Entity).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
            .ForEach(type =>
            {
                if (modelBuilder.Model.FindEntityType(type) is null)
                    _ = modelBuilder.Model.AddEntityType(type);
            });
    }

    public static DatabaseContext GetEnsureDatabase(IConfiguration settings)
    {
        var db = new DatabaseContext(settings);
        db.Database.EnsureCreated();
        return db;
    }
}
