using API.Application.Services;
using API.Infrastructure;
using API.Infrastructure.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var assembly = AppDomain.CurrentDomain.Load("API.Application");
builder.Services.AddMediatR(assembly);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add scopeds
builder.Services.AddScoped<IItemRepository, ItemRepository>();

//DB Context
builder.Services.AddDbContext<MicroserviceExample2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MivroserviceExample2")));

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
