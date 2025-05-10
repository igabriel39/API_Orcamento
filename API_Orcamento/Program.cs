using API_Orcamento.Middlewares;
using API_Orcamento.Models;
using API_Orcamento.Repository;
using API_Orcamento.Repository.Interfaces;
using API_Orcamento.Service;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Authorization.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

builder.Services.AddScoped<IProgramaRepository, ProgramaRepository>();
builder.Services.AddScoped<ProgramaService>();

builder.Services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
builder.Services.AddScoped<SolicitanteService>();

builder.Services.AddScoped<ITipoLancamentoRepository, TipoLancamentoRepository>();
builder.Services.AddScoped<TipoLancamentoService>();

builder.Services.AddScoped<ITipoTransacaoRepository, TipoTransacaoRepository>();
builder.Services.AddScoped<TipoTransacaoService>();

builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<UnidadeService>();

builder.Services.AddScoped<IUnidadeOrcamentariaRepository, UnidadeOrcamentariaRepository>();
builder.Services.AddScoped<UnidadeOrcamentariaService>();

builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<LancamentoService>();
#endregion

// Inicialização da autenticação e autorização do Keycloak
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = builder.Configuration["Keycloak:Authority"];
        options.Audience = builder.Configuration["Keycloak:resource"];
        options.RequireHttpsMetadata = false;
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
// Adiciona o middleware de autorização do Keycloak para validar todas as rotas e deixar centralizado
app.UseMiddleware<KeycloakAuthorizationMiddleware>();

app.MapControllers();

app.Run();
