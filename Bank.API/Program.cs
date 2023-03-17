using Bank.API.Data;
using Bank.Domain.Interfaces.IRepositories;
using Bank.Domain.Interfaces.IUseCases;
using Bank.API.Repositories;
using Bank.Domain.UseCases;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(dc => dc.UseSqlServer("name= DbConnection"));
builder.Services.AddScoped<IClienteUseCase, ClienteUseCase>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICuentaUseCase, CuentaUseCase>();
builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
builder.Services.AddScoped<IMovimientoUseCase, MovimientoUseCase>();
builder.Services.AddScoped<IMovimientoRepository, MovimientoRepository>();

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
