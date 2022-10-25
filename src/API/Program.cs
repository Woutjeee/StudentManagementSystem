using API.Data;
using API.Filters;
using API.Interfaces;
using API.Options;
using API.Repository;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var configutation = new ConfigurationBuilder()
    .SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("./appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");
builder.Services.Configure<ApplicationOptions>(configutation.GetSection("StudentManagementSystem"));
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var databaseService = builder.Services.BuildServiceProvider().GetService<IDatabaseService>();
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseSqlServer(databaseService.ReturnConnectionString()));

// Down here is all repositories and interfaces
builder.Services.AddTransient<IClass, ClassRepository>();
builder.Services.AddTransient<IStudent, StudentRepository>();
builder.Services.AddTransient<ITeacher, TeacherRepository>();
builder.Services.AddTransient<IUserInfo, UserInfoRepository>();


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
    c.SchemaFilter<SwaggerIgnoreFilter>();
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
