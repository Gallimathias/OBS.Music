
using Microsoft.AspNetCore.Mvc.Controllers;
using NonSucking.Framework.Extension.IoC;
using OBS.Music.Web.Controllers;
using System.Reflection;

namespace OBS.Music.Web;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var typeContainer = TypeContainer.Get<ITypeContainer>();

        CallStartUp<StartUp>(typeContainer);
        CallStartUp<ControllerBuilder>(typeContainer);

        typeContainer.Register<IControllerActivator, CustomControllerActivator>(InstanceBehaviour.Singleton);
        typeContainer.Register<IConfiguration>(builder.Configuration);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var controllerActivator = typeContainer.Get<IControllerActivator>();
        builder.Services.AddSingleton(controllerActivator);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.MapControllers();
        app.UseRouting();

        app.MapFallbackToFile("index.html");
        app.Run();
    }

    static void CallStartUp<T>(ITypeContainer typeContainer) where T : IStartUp
    {
        T.Register(typeContainer);
    }
}