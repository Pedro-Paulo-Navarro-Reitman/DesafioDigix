using AptidaoCasaPopularApplication.Services;
using Domain.Interfaces;
using Infra.DependencyInjection;
using Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICriterioDePontuacao, PontuacaoPorDependenteService>();
builder.Services.AddScoped<ICriterioDePontuacao, PontuacaoPorRendaService>();
builder.Services.AddScoped<PontuacaoFamiliaService>();
builder.Services.AddScoped<IPontuacaoFamiliaService, PontuacaoFamiliaService>();
builder.Services.AddScoped<IFamiliaRepository, FamiliaRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddLogging();

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
