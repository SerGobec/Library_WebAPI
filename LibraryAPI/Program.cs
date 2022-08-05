using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.Services;
using LibraryAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>(opt =>
    opt.UseInMemoryDatabase("LibraryDB"));

builder.Services.AddScoped<ILibraryDbService, LibraryDbService>();
builder.Services.AddSingleton<IContextLogger, LoggerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    IContextLogger logger = app.Services.GetService<IContextLogger>();
    if (logger != null) await logger.WriteToLog(context);
    await next.Invoke();
});

app.MapControllers();

app.Run();