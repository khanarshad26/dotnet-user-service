using Microsoft.EntityFrameworkCore;
using mydotnet.Models;
using Microsoft.Extensions.DependencyInjection;
using mydotnet.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserDbContext>();
builder.Services.AddCors();
builder.Services.AddControllers();
// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// if(Environment.IsDe)

    // global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();

