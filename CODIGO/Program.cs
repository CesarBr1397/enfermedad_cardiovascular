using ConnectionTools.DBTools;
using ECE.Model.DAO;
using TsaakAPI.Model.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtener la cadena de conexión desde appsettings.json
string defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
string secondaryConnection = builder.Configuration.GetConnectionString("SecondaryConnection");


// Registrar la clase EnfermedadCardiovascularDao con el connectionString
builder.Services.AddScoped<EnfermedadCardiovascularDao>(provider =>
    new EnfermedadCardiovascularDao(defaultConnection));

builder.Services.AddScoped<enfermedadCronicaDao>(provider =>
    new enfermedadCronicaDao(secondaryConnection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
