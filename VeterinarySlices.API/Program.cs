using Microsoft.EntityFrameworkCore;
using VeterinarySlices.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddDbContext<VeterinaryDataContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("mysql_read_write")!;
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();