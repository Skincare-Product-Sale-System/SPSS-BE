using API;
using API.Extensions;
using API.Middleware;
using API.Middlewares;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Microsoft.Azure.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File(
            path: Path.Combine("D:\\home\\LogFiles\\Application", "log-.txt"),
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true,
            fileSizeLimitBytes: 10485760,
            retainedFileCountLimit: 31);
});

// SECURITY FIX: Remove insecure AllowAll CORS policy
// Only configure CORS once via ConfigureCors extension method
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureCors();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureJwtAuthentication(builder.Configuration);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();  // Add your mappings profile here
}, typeof(Program).Assembly);
builder.Services.AddHttpClient();
builder.Services.AddScoped<VietQRService>();
builder.Services.AddSignalR().AddAzureSignalR(builder.Configuration["Azure:SignalR:ConnectionString"]!);

var app = builder.Build();

// Apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SPSSContext>();
    
    // Apply pending migrations
    Console.WriteLine("Applying pending migrations...");
    dbContext.Database.Migrate();
    Console.WriteLine("Migrations applied successfully!");
}

// Enable Swagger in all environments (for API testing)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = "swagger"; // Swagger tại /swagger
});

app.UseSerilogRequestLogging();

// SECURITY FIX: Add security headers to all responses
app.UseSecurityHeaders();

app.UseHttpsRedirection();
app.UseRouting();

// SECURITY FIX: Use only one CORS policy
app.UseCors("AllowFrontendApp");
app.UseMiddleware<API.Middlewares.RequestResponseMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<AuthMiddleware>();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    // Định nghĩa SignalR Hub
    endpoints.MapHub<ChatHub>("/chathub");
    endpoints.MapHub<TransactionHub>("/transactionhub");

    // Định nghĩa API endpoints
    endpoints.MapControllers();
});
app.MapControllers();
app.Run();
