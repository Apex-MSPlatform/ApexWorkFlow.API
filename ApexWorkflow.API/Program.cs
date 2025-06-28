using Application;
using Infrastructure.Extensions;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions;
using Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services
    .AddApplication()
    .AddInfrastructure(config)
    .AddPresentation();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Automatically migrate the database
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<WorkflowDbContext>();
context.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Serve static files from wwwroot
app.UseDefaultFiles(); // Enables default file mapping (like index.html)
app.UseStaticFiles();  // Serves the static files

app.UseExceptionHandlerMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
