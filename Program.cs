using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepoLayer.Interface;
using RepoLayer.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string filePath = "employees.csv"; // ✅ Define the file path

// ✅ Correct DI registration
builder.Services.AddSingleton<IReadRL>(provider => new ReadRL(filePath));
builder.Services.AddScoped<IReadBL, ReadBL>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
