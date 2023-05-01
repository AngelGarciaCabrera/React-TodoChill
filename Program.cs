using System.Text;
using de_todo_chill.Domain.us.Mappers;
using Domain.Contexts;
using Domain.Persistence.Repositories.CartItems;
using Domain.Persistence.Repositories.Product;
using Domain.Persistence.Repositories.User;
using Domain.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using AppAuthSettings = Domain.Authentication.Auth.AppAuthSettings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services class Injections
#region Custom Services

// Add scoped persistence entities
// Mapper
builder.Services.AddScoped<EntityMapper>();

#endregion
//DB Configs
#region DB_Configurations
//DB injection
builder.Services.AddDbContext<MysqlDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("MYSQL_DB_Conn"));
});

// DB Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();

// DB Services
builder.Services.AddScoped<IUserService, UserService>();

#endregion

//CORS config 
#region CORS_Settings

builder.Services.AddCors(option =>
{
    //Changes this to handle authizations
    option.AddPolicy(name: "CorsDefault", builder =>
    {
        builder.WithHeaders("*")
            .WithMethods("*")
            .WithOrigins("*");
    });
});

#endregion

//jwt config
#region JWT_Token

var appSettingsValues = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppAuthSettings>(appSettingsValues);

var appAuthSettingsInstance = appSettingsValues.Get<AppAuthSettings>();
var keyBytes = Encoding.ASCII.GetBytes(appAuthSettingsInstance.Secret);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(optBearer =>
{
    optBearer.RequireHttpsMetadata = false;
    optBearer.SaveToken = true;
    optBearer.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();