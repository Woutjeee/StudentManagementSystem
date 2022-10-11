using API.Data;
using API.Interfaces;
using API.Options;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var configutation = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("./appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ApplicationOptions>(configutation.GetSection("StudentManagementSystem"));
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var databaseService = builder.Services.BuildServiceProvider().GetService<IDatabaseService>();
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(databaseService.ReturnConnectionString()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Student Management System",
        Version = "V1",
        Description = "Api used for managing students."
    });
    var filePath = Path.Combine(AppContext.BaseDirectory, "API.xml");
    c.IncludeXmlComments(filePath);
});

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
