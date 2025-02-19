using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoListBlazor.API.Data;
using TodoListBlazor.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoListDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", configurePolicy: builder => builder
        .SetIsOriginAllowed((host) => true)
        .AllowAnyMethod().AllowAnyHeader()
        .AllowCredentials());
});

// Đăng ký Repository
builder.Services.AddTransient<ITaskRepository, TaskRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🚀 **Tự động migrate và seed database khi khởi động**
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TodoListDbContext>();
        var logger = services.GetRequiredService<ILogger<TodoListDbContextSeed>>();
        var seeder = new TodoListDbContextSeed();

        context.Database.Migrate(); // Chạy migration trước khi seed data
        await seeder.SeedAsync(context, logger); // Chạy Seed Data
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Lỗi khi migrate hoặc seed database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
