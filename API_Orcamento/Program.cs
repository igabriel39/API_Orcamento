using API_Orcamento.Models;
using API_Orcamento.Repository;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inicializa��o da conex�o com o banco de dados
// A connectionstring do banco de dados fica no "appsettings.json"
builder.Services.AddDbContext<_DbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Inicializa��o da depend�ncia do AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Inicializa��o das depend�ncias dos reposit�rios e servi�os para que sejam injetados nas respectivas camadas que ser�o usadas
// Adicionar na region abaixo quando for fazer o CRUD ou necessitar das opera��es de servi�o e reposit�rio
#region Inicializa��o das depend�ncias dos reposit�rios e servi�os para que sejam injetados nas respectivas camadas que ser�o usadas
builder.Services.AddScoped<IAcaoRepository, AcaoRepository>();
builder.Services.AddScoped<AcaoService>();
#endregion

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
