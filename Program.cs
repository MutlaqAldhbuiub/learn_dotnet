using learn_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using learn_dotnet.Models;
using System.Text;
using Microsoft.AspNetCore.Identity;
using learn_dotnet.Extensions;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add database context
builder.Services.AddDbContext<NetworkContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("NetworkConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("NetworkConnection"))));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("NetworkConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("NetworkConnection")),
        mysqlOptions =>
        {
            mysqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore); // Ignore schema definitions
        }));

// // Bind JWT settings from configuration
// builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
// // Register JwtTokenService with DI
// builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// // Configure JWT Authentication
// var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = jwtSettings.Issuer,
//         ValidAudience = jwtSettings.Audience,
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
//     };
// });





builder.Services.AddAuthorization();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
})
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);


builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<INetworkRepo, MockNetworkRepo>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapIdentityApi<User>();


app.Run();
