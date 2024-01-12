using API.Application.Querys;
using API.Application.Services;
using API.Infrastructure;
using API.Infrastructure.Contracts;
using API.Infrastructure.Repositories;
using API.Reports.QueriesControllers;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var assembly = AppDomain.CurrentDomain.Load("API.Application");
builder.Services.AddMediatR(assembly);

builder.Services.AddHttpClient();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
       .AddGraphQLServer()
       .AddQueryType(d => d.Name("Query"))
       .AddType<ItemsQueryController>()
       .AddType<PersonQueryController>()
       .AddType<PersonQuery>();

// Add scopeds
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IMicroservice1Connection, Microservice1Connection>();
builder.Services.AddScoped<IMicroservice2Connection, Microservice2Connection>();


//DB Context
builder.Services.AddDbContext<ReportContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReportConnection")));

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

app.MapGraphQL("/graphql");

app.Run();
