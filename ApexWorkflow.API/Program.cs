using Application;





var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplication();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
