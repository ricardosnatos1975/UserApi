using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core with SQLite
builder.Services.AddDbContext<UserApi.Data.ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=users.db"));

builder.Services.AddScoped<UserApi.Interfaces.IUserRepository, UserApi.Repositories.UserRepository>();
builder.Services.AddScoped<UserApi.Interfaces.IUserService, UserApi.Services.UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API V1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
