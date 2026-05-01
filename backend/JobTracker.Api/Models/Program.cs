using JobTracker.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🌐 Controllers (we will use this in Day 4+)
builder.Services.AddControllers();

var app = builder.Build();

// 🔐 Middleware
app.UseHttpsRedirection();

app.MapControllers();

app.Run();