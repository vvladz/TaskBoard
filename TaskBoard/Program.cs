using LiteDB;
using TaskBoard.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddSingleton<ILiteDatabase>(
    _ => new LiteDatabase(builder.Configuration.GetConnectionString("TaskDb")));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Error");

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
