using LancamentosFinanceiroApi.Data.Context;
using LancamentosFinanceiroApi.Repository.Contract;
using LancamentosFinanceiroApi.Repository.Implementations;
using LancamentosFinanceiroApi.Services.Contract;
using LancamentosFinanceiroApi.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<FinancaContextoAPI>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinancaDB")));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryImplementations>();

builder.Services.AddScoped<IUsuarioServices, UsuarioServicesImplementations>();

// Add services to the container.

builder.Services.AddControllers();
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
