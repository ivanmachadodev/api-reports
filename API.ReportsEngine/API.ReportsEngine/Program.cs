using API.Infrastructure;
using API.Infrastructure.Contracts;
using API.Infrastructure.Repositories;
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
       .AddType<AreaQueryController>()
       .AddType<CamposDBsQueryController>()
       .AddType<EntityQueryController>()
       .AddMutationType<DataSetMutationController>();

//Add Scopeds
builder.Services.AddScoped<IDBFieldsBModelRepository, CamposDBsRepository>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IEntityRepository, EntityRepository>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();

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
