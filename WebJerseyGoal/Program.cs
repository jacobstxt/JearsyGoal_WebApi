using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebJerseyGoal.DataBase;
using WebJerseyGoal.Filters;
using WebJerseyGoal.Interfaces;
using WebJerseyGoal.Models.Category;
using WebJerseyGoal.Models.Validators.Category;
using WebJerseyGoal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbJerseyGoalContext>(opt =>
opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Вимикаємо автоматичну валідацію через Model State
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

//Додаємо валідацію через FluentValidation
//Шукаємо всі можливі валідатори
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidationFilter>();
});


builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddCors();

var app = builder.Build();



app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

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
