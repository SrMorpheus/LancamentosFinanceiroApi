using LancamentosFinanceiroApi.Configurations;
using LancamentosFinanceiroApi.Data.Context;
using LancamentosFinanceiroApi.Repository.Contract;
using LancamentosFinanceiroApi.Repository.Implementations;
using LancamentosFinanceiroApi.Services.Contract;
using LancamentosFinanceiroApi.Services.Implementations;
using LancamentosFinanceiroApi.ServicesAPI.DogAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



var tokenConfigurations = new TokenConfiguration();

new ConfigureFromConfigurationOptions<TokenConfiguration>(

    builder.Configuration.GetSection("TokenConfigurations")

    ).Configure(tokenConfigurations);


builder.Services.AddSingleton(tokenConfigurations);
builder.Services.AddAuthentication(Options =>
{

    Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(Options =>
    {

        Options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,

            ValidateAudience = true,

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,

            ValidIssuer = tokenConfigurations.Issuer,

            ValidAudience = tokenConfigurations.Audience,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))




        };



    });

builder.Services.AddAuthorization(auth =>

{

    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());

});

builder.Services.AddCors(options => options.AddDefaultPolicy(buider =>

{
    buider.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();


}));


builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<FinancaContextoAPI>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FinancaDB"),
builder =>
{
    builder.EnableRetryOnFailure(20, TimeSpan.FromSeconds(10), null);
}


    ));


//inje��o de dependecia
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryImplementations>();

builder.Services.AddScoped<IUsuarioServices, UsuarioServicesImplementations>();

builder.Services.AddScoped<ILoginService, LoginServiceImplementation>();

builder.Services.AddScoped<ILancamentoRepository, LancamentoRepositoryImplementations>();

builder.Services.AddScoped<ILancamentoServices, LancamentoServiceImplementation>();

builder.Services.AddTransient<ITokenService, TokenService>();

builder.Services.AddScoped<ILoginRepository, LoginRepositoryImplementations>();


//chamada htpp
builder.Services.AddHttpClient<GetDog>(client =>
{

    client.BaseAddress = new Uri("https://dog.ceo/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

});




// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c => {

        c.SwaggerEndpoint($"../swagger/v1/swagger.json", "APi de Finan�a  - v1".ToUpperInvariant());
        

    });
}


app.UseHttpsRedirection();

//deploy no IIS
app.UseRouting();

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI(c => {

    c.SwaggerEndpoint("../swagger/v1/swagger.json", "APi de Finan�a - v1");


});
var option = new RewriteOptions();

option.AddRedirect("^$", "swagger");
app.UseRewriter(option);
//aqui finaliza

app.UseAuthorization();

app.MapControllers();

app.Run();
