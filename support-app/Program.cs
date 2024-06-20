using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using support_app.Data;
using support_app.Persons;
using support_app.Projects;
using support_app.Tasks.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
    conStrBuilder.Password = builder.Configuration["DbPassword"];
    var connection = conStrBuilder.ConnectionString;
    options.UseSqlServer(connection);
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IWorkersRepository, WorkersRepository>();
builder.Services.AddScoped<IDutyRepository, DutyRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    builder.Configuration.AddUserSecrets<Program>();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
