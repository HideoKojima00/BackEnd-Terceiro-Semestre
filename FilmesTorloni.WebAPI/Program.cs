

using Filmes.WebAPI.Repository;
using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Controllers;
using FilmesTorloni.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiona o repositório ao container de injeção de dependência 
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddEndpointsApiExplorer();
//Adicione o serviço de autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", Options =>
{
    Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true, //Valida quem está solicitando o token
        ValidateAudience = true, //valida quem está recebendo o token
        ValidateLifetime = true,//define se o token tem um tempo de expiração

        //Chave de acesso ao token
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        //valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(7),

        //nome do issuer (de onde o token está vindo)
        ValidIssuer = "api_filmes",

        //nome da audience (para onde ele está indo)
        ValidAudience = "api_filmes"
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Filmes APi",
        Description = "Uma APi com catalgo de filmes",

        TermsOfService = new Uri("https://github.com/HideoKojima00"),
        Contact = new OpenApiContact
        {
            Name = "marcaumdev",
            Url = new Uri("https://github.com/HideoKojima00")
        },

        License = new OpenApiLicense
        {
            Name = "Example Lincense",
            Url = new Uri("https://github.com/HideoKojima00")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT desta forma: Bearer {seu_token_aqui}"
    });
});



// Adicione serviços para controllers
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
            "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthentication();

app.UseAuthorization();

//Adicione o mapemento de Controllers
app.MapControllers();
app.Run();



