using Api.Business.Interfaces;
using Api.Business.Services;
using Api.Data.Interfaces;
using Api.Data.Repositories;

/// <summary>
/// Punto de entrada principal de la aplicación API.
/// Configura los servicios de inyección de dependencias y el pipeline de la aplicación.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Registro de controladores y documentación de API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Registro de repositorios (capa de datos)
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISpendRepository, SpendRepository>();
builder.Services.AddScoped<IMonthReportRepository, MonthReportRepository>();

// Registro de servicios (capa de negocio)
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISpendService, SpendService>();
builder.Services.AddScoped<IReportService, ReportService>();

// Configuración de CORS para permitir peticiones desde el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();

// Aplicar política de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

// Mapear controladores de API
app.MapControllers();

// Configurar archivos estáticos para servir el frontend de React
app.UseDefaultFiles();
app.UseStaticFiles();

// Configurar fallback para enrutar todo al index.html (para SPA)
app.MapFallbackToFile("index.html");

app.Run();