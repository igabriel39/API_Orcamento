using API_Orcamento.Models;
using API_Orcamento.Repository;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Service;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    }
);

// Inicialização da conexão com o banco de dados
// A connectionstring do banco de dados fica no "appsettings.json"
builder.Services.AddDbContext<_DbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Inicialização da dependência do AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Inicialização das dependências dos repositórios e serviços para que sejam injetados nas respectivas camadas que serão usadas
// Adicionar na region abaixo quando for fazer o CRUD ou necessitar das operações de serviço e repositório
#region Inicialização das dependências dos repositórios e serviços para que sejam injetados nas respectivas camadas que serão usadas
builder.Services.AddScoped<IAcaoRepository, AcaoRepository>();
builder.Services.AddScoped<AcaoService>();

builder.Services.AddScoped<IElementoDespesaRepository, ElementoDespesaRepository>();
builder.Services.AddScoped<ElementoDespesaService>();

builder.Services.AddScoped<IFonteRecursoRepository, FonteRecursoRepository>();
builder.Services.AddScoped<FonteRecursoService>();

builder.Services.AddScoped<IGrupoDespesaRepository, GrupoDespesaRepository>();
builder.Services.AddScoped<GrupoDespesaService>();

builder.Services.AddScoped<IModalidadeAplicacaoRepository, ModalidadeAplicacaoRepository>();
builder.Services.AddScoped<ModalidadeAplicacaoService>();

builder.Services.AddScoped<IObjetivoEstrategicoRepository, ObjetivoEstrategicoRepository>();
builder.Services.AddScoped<ObjetivoEstrategicoService>();
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
