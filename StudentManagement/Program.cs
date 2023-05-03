using Microsoft.EntityFrameworkCore;
using StudentManagement;
using StudentManagement.Data.Services;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("DefaultConnectionString");



// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<StudentsService>();
builder.Services.AddTransient<TermService>();
builder.Services.AddTransient<MarkService>();


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
