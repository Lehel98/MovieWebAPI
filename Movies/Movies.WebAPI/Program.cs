using Microsoft.EntityFrameworkCore;
using Movies.WebAPI;
using Movies.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MovieDbContext>(options =>
{
	IConfigurationRoot configuration = builder.Configuration;
	options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
	options.UseLazyLoadingProxies();
});

builder.Services.AddTransient<IMoviesService, MoviesService>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

using (var serviceScope = app.Services.CreateScope())
using (var context = serviceScope.ServiceProvider.GetRequiredService<MovieDbContext>())
{
	DbInitializer.Initialize(context);
}

app.Run();
