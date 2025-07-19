using MyPractice.Application;
using MyPractice.Application.Contract.Interfaces;
using MyPractice.Interface.RestApi.Middlewares;
using MyPractice.Localization.Helper;
using MyPractice.Persistant;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Add services to the container.
builder.Services.AddControllers(); // For API-style controllers

// Swagger و دیگر سرویس‌ها
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddScoped<ILocalizer, Localizer>();
var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseRouting(); // Enable routing

// Add additional middleware (e.g., authentication, authorization)
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers(); // Maps attribute-routed controllers

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();

app.Run();