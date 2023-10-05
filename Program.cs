using Microsoft.EntityFrameworkCore;
using GameSetWebApi.Models;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Include user secrets in development environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<GameSetContext>(opt =>
{
    string connectionString = Configuration.GetConnectionString("DefaultConnection");
    connectionString = connectionString
        .Replace("{Database:Host}", Configuration["Database:Host"])
        .Replace("{Database:DbName}", Configuration["Database:DbName"])
        .Replace("{Database:User}", Configuration["Database:User"])
        .Replace("{Database:Password}", Configuration["Database:Password"]);

    opt.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();