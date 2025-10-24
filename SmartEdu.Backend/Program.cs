using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SmartEdu.Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<SmartEduContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=SmartEdu.db"));

builder.Services.AddScoped<ICourse, CourseData>();
builder.Services.AddScoped<ITrainer, TrainerData>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SmartEdu API",
        Version = "v1",
        Description = "Backend API for SmartEdu Hybrid Learning Platform"
    });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartEdu API v1"));

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7194", "http://localhost:5013")
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();


var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SmartEduContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();
