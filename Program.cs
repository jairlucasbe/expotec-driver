using expotec_driver.Data;
using expotec_driver.Modules.BusinessExecutives.Repositories;
using expotec_driver.Modules.BusinessExecutives.Services;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("MySQL connection string is not configured.");
}
var MySQLConfiguration = new MYSQLConfiguration(connectionString);
builder.Services.AddSingleton(MySQLConfiguration);
builder.Services.AddSingleton(new MySqlConnection(connectionString));

//Services
builder.Services.AddScoped<IBusinessExecutiveRepository, BusinessExecutiveRepository>();
builder.Services.AddScoped<BusinessExecutiveService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
