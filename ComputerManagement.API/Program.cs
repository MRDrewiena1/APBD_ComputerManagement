using ComputerManagement.API.Middleware;
using ComputerManagement.Business.Interfaces;
using ComputerManagement.Business.Services;
using ComputerManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPcService, PcService>();

var app = builder.Build();

// --- Middleware pipeline ---
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
