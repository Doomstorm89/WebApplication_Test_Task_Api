using Microsoft.EntityFrameworkCore;
using WebApplication_Test_Task_Api_Doctor_Patient.Interfaces;
using WebApplication_Test_Task_Api_Doctor_Patient.Models;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.DbContextModels;
using WebApplication_Test_Task_Api_Doctor_Patient.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// [!] Необходимо подменить строку подключения к SQL Server в appsettings.json на свою [!]
builder.Services.AddDbContext<DoctorsAndPatientsDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IRepository<Doctor>, DoctorRepository>();
builder.Services.AddTransient<IRepository<Patient>, PatientRepository>();

var app = builder.Build();

var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope();
var context = serviceScope.ServiceProvider.GetRequiredService<DoctorsAndPatientsDbContext>();
if(context.Database.EnsureCreated())
{
    context.Database.MigrateAsync();
}
else
{
    context.Database.EnsureCreatedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
