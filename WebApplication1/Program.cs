using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication1.Models; // Make sure this matches your project namespace

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// ✅ Add EF Core with connection string from appsettings.json
builder.Services.AddDbContext<APIDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Devconnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();


app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // This maps API controllers

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


    app.Run();
