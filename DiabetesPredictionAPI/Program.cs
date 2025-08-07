using DiabetesPredictionAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Diabetes Prediction API",
        Version = "v1",
        Description = "API for predicting diabetes using machine learning",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Diabetes Prediction System",
            Email = "support@diabetesprediction.com"
        }
    });

    // Enable XML comments for better documentation
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Add HTTP Client for ML API communication
builder.Services.AddHttpClient<DiabetesPredictionService>();

// Register the prediction service
builder.Services.AddScoped<DiabetesPredictionService>();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Diabetes Prediction API v1");
        c.RoutePrefix = string.Empty; // Make Swagger UI the default page
    });
}

// Enable CORS
app.UseCors("AllowAll");

// Add security headers
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Add a simple root endpoint
app.MapGet("/", () => new
{
    message = "Diabetes Prediction API is running!",
    version = "1.0.0",
    endpoints = new
    {
        swagger = "/swagger",
        health = "/api/diabetes/health",
        predict = "/api/diabetes/predict",
        predictCsv = "/api/diabetes/predict-csv",
        modelInfo = "/api/diabetes/model-info",
        sampleData = "/api/diabetes/sample-data",
        docs = "/api/diabetes/docs"
    },
    mlApiUrl = builder.Configuration["MLApiSettings:BaseUrl"] ?? "http://localhost:5000"
});

// Configure the application to listen on all interfaces
var port = Environment.GetEnvironmentVariable("PORT") ?? "7000";
app.Urls.Add($"http://0.0.0.0:{port}");

Console.WriteLine($"Starting Diabetes Prediction API on port {port}");
Console.WriteLine($"ML API URL: {builder.Configuration["MLApiSettings:BaseUrl"] ?? "http://localhost:5000"}");
Console.WriteLine("Available endpoints:");
Console.WriteLine($"  - Swagger UI: http://localhost:{port}/swagger");
Console.WriteLine($"  - Health Check: http://localhost:{port}/api/diabetes/health");
Console.WriteLine($"  - API Documentation: http://localhost:{port}/api/diabetes/docs");

app.Run();