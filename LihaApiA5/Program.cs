using LihaApiA5.@interface;
using LIhaApiA5.Data.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using System.Text;

var MyCors = "MyCors";
var VersionApi = "v1_0";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(p => p.AddPolicy(MyCors, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}
));
//Agregando seguridad
builder.Configuration.AddJsonFile("appsettings.json");//cargo todo el archivo de appsetings
var secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();//tomo solo la variagle secretkey
var keyBytes = Encoding.UTF8.GetBytes(secretkey);//codifico en bytes


builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(VersionApi, new OpenApiInfo
    {
        Title = "API FelizIA V 0.15",
        Version = VersionApi,
        Description = "API rest para la intercionexion entre Data Lake y APP IA de fuerza de ventas"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
});

});

var MySqlConfig = new MySqlConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(MySqlConfig);
builder.Services.AddScoped<IItem, ItemRepository>();
builder.Services.AddScoped<Iproductospvp, productospvpRepository>();
var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
    c.SwaggerEndpoint($"/swagger/{VersionApi}/swagger.json", $"API {VersionApi}");
    // custom CSS
    c.InjectStylesheet("/swagger-ui/custom.css");
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();