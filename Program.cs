using de_todo_chill.Domain.us.Mappers;
using Domain.Contexts;
using Domain.Persistence.Repositories.CartItems;
using Domain.Persistence.Repositories.Product;
using Domain.Persistence.Repositories.User;
using Domain.Persistence.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add scoped persistence entities
// Mapper
builder.Services.AddScoped<EntityMapper, EntityMapper>();

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<ISuggestionRepository, SuggestionRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();

//DB injection
builder.Services.AddDbContext<MysqlDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("MYSQL_DB_Conn"));
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