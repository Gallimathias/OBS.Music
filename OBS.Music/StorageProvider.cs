using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using NonSucking.Framework.Extension.IoC;
using OBS.Music.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Music;

public class StorageProvider
{
    private readonly ITypeContainer typeContainer;

    public StorageProvider(ITypeContainer typeContainer)
    {
        this.typeContainer = typeContainer;
    }

    public EntityState AddOrUpdate<T>(T entity) where T : Entity
    {
        using var database = GetDbContext();

        var dbSet = database.Set<T>();
        EntityEntry<T> entry;
        if (dbSet.Contains(entity))
            entry = dbSet.Update(entity);
        else
            entry = dbSet.Add(entity);

        database.SaveChanges();
        return entry.State;
    }

    public T? Find<T, K>(K key) where T : Entity
    {
        using var database = GetDbContext();

        var dbSet = database.Set<T>();
        return dbSet.Find(key);
    }

    public T First<T>(Func<T, bool> predicate) where T : Entity
    {
        using var database = GetDbContext();

        var dbSet = database.Set<T>();
        return dbSet.First(predicate);
    }

    public T? FirstOrDefault<T>(Func<T, bool> predicate) where T : Entity
    {
        using var database = GetDbContext();

        var dbSet = database.Set<T>();
        return dbSet.FirstOrDefault(predicate);
    }

    public EntityState Remove<T>(T entity) where T : Entity
    {
        using var database = GetDbContext();

        var dbSet = database.Set<T>();
        var entry = dbSet.Remove(entity);
        database.SaveChanges();
        return entry.State;
    }
    public EntityState Remove<T, K>(K id) where T : Entity
    {
        using var database = GetDbContext();

        var dbSet = database.Set<T>();
        var entity = database.Find<T>(id);

        if (entity is null)
            return EntityState.Detached;

        var entry = dbSet.Remove(entity);
        database.SaveChanges();
        return entry.State;
    }

    private DatabaseContext GetDbContext()
    {
        var dbContext = typeContainer.Get<DatabaseContext>();
        dbContext.Database.EnsureCreated();
        return dbContext;
    }
}
