using Microsoft.EntityFrameworkCore;
using UserManagementApi.Data;
using UserManagementApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// EF Core InMemory DB
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("UserManagementDb"));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// (Optional) place for auth later:
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
