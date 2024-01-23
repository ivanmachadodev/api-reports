using API.Domain.Entities;
using API.Infrastructure;
using API.Infrastructure.Contracts;
using API.Infrastructure.Repositories;
using API.ReportsEngine.Controllers;
using API.ReportsEngine.QueriesControllers;
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
builder.Services
       .AddGraphQLServer()
       .AddQueryType(d => d.Name("Query"))
       .AddType<FieldQueryController>()
       .AddType<EntityQueryController>()
       .AddType<AreaQueryController>()
       .AddType<CamposDBsQueryController>()
       .AddType<DataSetQueryController>()
       .AddType<DetFieldsOFDataSetQueryController>()
       .AddMutationType<DataSetMutationController>()
       .AddType<MonedaQueryController>();

//Add Scopeds
builder.Services.AddScoped<IDBFieldsBModelRepository, DBFieldsBModelRepository>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IEntityRepository, EntityRepository>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<IDataSetRepository, DataSetRepository>();
builder.Services.AddScoped<IDetFieldsOfDataSetRepository, DetFieldsOfDataSetRepository>();
builder.Services.AddScoped<IMonedaRepository, MonedaRepository>();

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        policy => policy.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod());
});

//DB Context
builder.Services.AddDbContext<IReportsEngineContext, ReportsEngineContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ReportsEngine")));

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

app.UseCors("MyCorsPolicy");

app.MapGraphQL("/graphql");

app.Run();
