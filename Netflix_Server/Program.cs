using Microsoft.EntityFrameworkCore;
using Netflix_Server.IRepository;
using Netflix_Server.Models.Context;
using Netflix_Server.Models.UserGroup;
using Netflix_Server.Repository.UserGroup;
using Netflix_Server.Services.PasswordGroup;
using Netflix_Server.Services.UserGroup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IRepository<Feature>, FeatureRepository>();
builder.Services.AddScoped<IRepository<PricingPlan>, PricingPlanRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

builder.Services.AddScoped<IUserAuthentication, UserAuthentication>();
builder.Services.AddScoped<IPasswordHashing, PasswordHashing>();


// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader().AllowAnyMethod());


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
