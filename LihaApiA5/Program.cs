using LIhaApiA5.Data.Repositorios;
using Microsoft.OpenApi.Models;

var MyCors = "MyCors";
var VersionApi = "v1_0";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(p => p.AddPolicy(MyCors, builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}
));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(VersionApi, new OpenApiInfo
    {
        Title = "ApiLiha V0.3",
        Version = VersionApi,
        Description = "API rest para la intercionexion entre Data Lake de Agrota y APP IA de fuerza de ventas"
    });
});



var MySqlConfig = new MySqlConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(MySqlConfig);
builder.Services.AddScoped<IGRUPOCATEGORIALINEA, CategoriasRepository>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();