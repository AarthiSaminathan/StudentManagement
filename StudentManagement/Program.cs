using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Tls;
using StudentManagement;
using StudentManagement.Data.Helper;
using StudentManagement.Data.Models;
using StudentManagement.Data.Services;
using StudentManagement.Menu;
using StudentManagement.MenuService;

var builder = WebApplication.CreateBuilder(args);
    var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


    builder.Logging.SetMinimumLevel(LogLevel.Warning);
    builder.Logging.ClearProviders();        
    builder.Logging.AddConsole();

 
    string connString = builder.Configuration.GetConnectionString("DefaultConnectionString");


// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7179/api/Students/get-all-student",
                              "https://localhost:7179/api/Students/add-student-with-term",
                              "https://localhost:7179/api/Students/update-student-by-rollno/${id}",
                              "https://localhost:7179/api/Students/delete-student-by-rollno/${id}",
                              "https://localhost:7179/api/Marks/add-mark",
                              "https://localhost:7179/api/AdminDashboard/get-all-menu",
                              "https://localhost:7179/api/Submenu/add-submenu",
                              "https://localhost:7179/api/MenuDashboard/get-all-menu",
                              "https://localhost:7179/api/Students/add-student-by-file",
                              "https://localhost:7179/api/FileValidation/add-file",
                                              "http://localhost:3000").AllowAnyHeader()
                                                  .AllowAnyMethod(); 

                      });
        

});

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
    builder.Services.AddTransient<AdminDashboardService>();
    builder.Services.AddTransient<SubmenuService>();
    builder.Services.AddTransient<FileValidationService>();
    builder.Services.AddTransient<MenuDashboardService>();

    builder.Services.AddLogging(loggingBuilder=>loggingBuilder.ClearProviders().AddProvider(new CorrelationIdLoggerProvider()));
    
    var app = builder.Build();
 
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

    app.UseAuthorization();
    app.MapHub<UploadHub>("/UploadHub");

    app.MapControllers();


app.Run();

