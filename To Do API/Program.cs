using System.Reflection;
using FluentValidation;
using NLog.Web;
using ToDoAPI;
using ToDoAPI.Entities;
using ToDoAPI.Middleware;
using ToDoAPI.Models;
using ToDoAPI.Models.Validators;
using ToDoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoDbContext>();
builder.Services.AddScoped<ToDoSeeder>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Host.UseNLog();
builder.Services.AddScoped<IValidator<CreateToDoDto>, CreateToDoDtoValidator>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ToDoSeeder>();
seeder.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
