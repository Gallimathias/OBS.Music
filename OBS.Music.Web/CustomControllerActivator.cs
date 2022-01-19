using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using NonSucking.Framework.Extension.IoC;
using System.Collections.Concurrent;
using System;

namespace OBS.Music.Web;

public class CustomControllerActivator : IControllerActivator, IDisposable
{

    private readonly ITypeContainer typeContainer;
    private readonly ConcurrentDictionary<Type, ConcurrentQueue<PoolEntry>> controllers;

    private readonly ConcurrentQueue<PoolEntry> entryQueue;
    private readonly int maxCachedEntries;

    public CustomControllerActivator(ITypeContainer typeContainer, IConfiguration configuration)
    {
        controllers = new ConcurrentDictionary<Type, ConcurrentQueue<PoolEntry>>();
        entryQueue = new ConcurrentQueue<PoolEntry>();

        this.typeContainer = typeContainer;
        maxCachedEntries = configuration.GetSection("caching").GetValue("maxPoolEntries", 100);
    }

    public object Create(ControllerContext context)
    {
        var type = context.ActionDescriptor.ControllerTypeInfo.AsType();
        object? controller = null;

        if (controllers.TryGetValue(type, out var pool))
        {
            if (pool.TryDequeue(out var entry))
            {
                controller = entry.Controller;
                Release(entry);
            }
        }

        if (controller is null)
            controller = typeContainer.GetOrNull(type) ?? Activator.CreateInstance(type)!;

        if (controller is ControllerBase @base)
            @base.ControllerContext = context;

        return controller;
    }

    public void Dispose()
    {
        entryQueue.Clear();

        foreach (var lastEntries in controllers)
        {
            foreach (var entry in lastEntries.Value)
            {
                if (entry.Controller is IDisposable disposable)
                    disposable.Dispose();
            }

            lastEntries.Value.Clear();
        }

        controllers.Clear();
    }

    public void Release(ControllerContext context, object controller)
    {
        if (controller is IDisposable disposable)
        {
            disposable.Dispose();
            return;
        }

        var type = controller.GetType();

        if (controllers.TryGetValue(type, out var pool))
        {
            pool.Enqueue(Rent(controller));
        }
        else
        {
            var p = new ConcurrentQueue<PoolEntry>();
            if (controllers.TryAdd(type, p))
            {
                p.Enqueue(Rent(controller));
            }
        }
    }

    private PoolEntry Rent(object controller)
    {
        if (entryQueue.TryDequeue(out var entry))
        {
            entry.Controller = controller;
            entry.Reset();
            return entry;
        }

        return new PoolEntry(controller);
    }

    private void Release(PoolEntry entry)
    {
        if (entryQueue.Count > maxCachedEntries)
            return;

        entryQueue.Enqueue(entry);
    }

    private class PoolEntry
    {
        public object Controller { get; set; }
        public int Generation { get; private set; }

        public PoolEntry(object controller)
        {
            Controller = controller;
            Generation = 0;
        }

        public void NextGeneration()
        {
            Generation++;
        }

        public void Reset()
        {
            Generation = 0;
        }
    }
}
