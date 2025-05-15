using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebJerseyGoal.DataBase;
using WebJerseyGoal.Interfaces;
using WebJerseyGoal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbJerseyGoalContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();


var dir = builder.Configuration["ImagesDir"];
string path = Path.Combine(Directory.GetCurrentDirectory(), dir);
Directory.CreateDirectory(path);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(path),
    RequestPath = $"/{dir}"
});


await app.SeedData();

app.Run();
