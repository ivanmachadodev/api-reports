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
       .AddType<CamposDBsQueryController>()
       .AddType<ItemsQueryController>()
       .AddType<PersonQueryController>();

// Add scopeds
builder.Services.AddScoped<ICamposDBsRepository, CamposDBsRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<IMicroservice1Connection, Microservice1Connection>();
builder.Services.AddScoped<IMicroservice2Connection, Microservice2Connection>();

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        policy => policy.WithOrigins("http://localhost:3000")
                       .AllowAnyHeader()
                       .AllowAnyMethod());
});


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

app.UseCors("MyCorsPolicy");

app.MapGraphQL("/graphql");

app.Run();
