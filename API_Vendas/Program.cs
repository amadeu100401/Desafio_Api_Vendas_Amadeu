using API_Vendas.Models;
using API_Vendas.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<_DbContext>(x => x.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConncection"),
    ServerVersion.Parse("8.0")
    ));

builder.Services.AddScoped<IProdutosRepository,ProdutosRepository>();
builder.Services.AddScoped<IComprasRepository,ComprasRepository>();
builder.Services.AddScoped<IPagamentoRepository,PagamentoRepository>();

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
