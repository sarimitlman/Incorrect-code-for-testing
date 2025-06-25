using BL.Api;
using BL.Services;
using BL.Services.BL.Services;
using Dal.Api;
using Dal.Models;
using Dal.Repository;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// מוסיפים את השירות של המונגו
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient("mongodb://localhost:27017"));

// הגדרת CORS - שימי לב לכתובת של React (5173)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5174")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// מוסיפים את שאר השירותים
builder.Services.AddScoped<IUsers, UserRepository>();
builder.Services.AddScoped<IBLUser, BLUserService>();
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<IBLCategory, BLCategoryService>();
builder.Services.AddScoped<ISubCategory, SubCategoryRepository>();
builder.Services.AddScoped<IBLSubCategory, BLSubCategoryService>();
builder.Services.AddScoped<IPrompt, PromptRepository>();
builder.Services.AddScoped<IBLPrompt, BLPromptService>();
builder.Services.AddHttpClient<IBLAI, BLAIService>();
builder.Services.AddScoped<IBLAdmin, BLAdminService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// הפעלת CORS לפני המיפוי של הקונטרולרים
app.UseCors("AllowReactApp");

var apiKey = builder.Configuration["AI:ApiKey"];
app.MapControllers();
app.Run();