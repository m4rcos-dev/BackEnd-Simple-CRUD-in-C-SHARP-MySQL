using BackEnd_Simple_CRUD_in_C_SHARP_MySQL.Data;
using BackEnd_Simple_CRUD_in_C_SHARP_MySQL.Interfaces;
using BackEnd_Simple_CRUD_in_C_SHARP_MySQL.Repository;
using BackEnd_Simple_CRUD_in_C_SHARP_MySQL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexão com o banco MySql
builder.Services.AddDbContext<UserContext>(options =>
{
  string connectionString = builder.Configuration.GetConnectionString("Default");
  options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Injeção de depêndencia do Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/error-development");
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
