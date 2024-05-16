using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    //builder.Services.AddSingleton<Migrator>();
}

builder.Services.AddTransient<ITenantRepository, TenantRepository>();
builder.Services.AddTransient<IFieldRepository, FieldRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.Services.GetRequiredService<Migrator>()?.Migrate();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
