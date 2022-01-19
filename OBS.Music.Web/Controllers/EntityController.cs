using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBS.Music.Model;
using System.Net;

namespace OBS.Music.Web.Controllers;

public abstract class EntityController<TEntity, TKey, TApiKey> : ControllerBase where TEntity : Entity
{
    protected readonly StorageProvider storageProvider;

    public EntityController(StorageProvider storageProvider)
    {
        this.storageProvider = storageProvider;
    }

    [HttpPost]
    public virtual IActionResult AddOrUpdate(TEntity value)
    {
        var state = storageProvider.AddOrUpdate(value);

        return
            (state == EntityState.Added || state == EntityState.Modified)
            ? Ok()
            : StatusCode((int)HttpStatusCode.InternalServerError);
    }

    [HttpGet("{id}")]
    public virtual IActionResult Get(TApiKey id)
    {
        var value = storageProvider.Find<TEntity, TKey>(GenericCaster<TApiKey, TKey>.Cast(id));

        if (value is null)
            return StatusCode((int)HttpStatusCode.NotFound);

        return Ok(value);
    }


    [HttpDelete("{id}")]
    public virtual IActionResult Remove(TApiKey id)
    {
        var state = storageProvider.Remove<TEntity, TKey>(GenericCaster<TApiKey, TKey>.Cast(id));

        return
            state == EntityState.Deleted
            ? Ok()
            : StatusCode((int)HttpStatusCode.InternalServerError);
    }
}

public abstract class EntityController<TEntity, TKey> : EntityController<TEntity, TKey, TKey> where TEntity : Entity
{
    protected EntityController(StorageProvider storageProvider) : base(storageProvider)
    {
    }

    public override IActionResult Get(TKey id)
    {
        var value = storageProvider.Find<TEntity, TKey>(id);

        if (value is null)
            return StatusCode((int)HttpStatusCode.NotFound);

        return Ok(value);
    }

    public override IActionResult Remove(TKey id)
    {
        var state = storageProvider.Remove<TEntity, TKey>(id);

        return
            state == EntityState.Deleted
            ? Ok()
            : StatusCode((int)HttpStatusCode.InternalServerError);
    }
}