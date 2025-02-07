using Api.ClinicaMedica.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//SERVICES: 

//Evitar referencias ciclicas y serializaciones innecesarias
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//cambio
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                      ?? builder.Configuration.GetConnectionString("HackacodeConnection");


//Registrar ApplicationDbContext en el contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//Config de Automapper
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => // Desarrollo
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });

    options.AddPolicy("AllowVercel", builder => // Producción
    {
        builder.WithOrigins("https://turno-facil.vercel.app")
               .AllowAnyMethod() // Métodos específicos si es posible (POST, GET, etc.)
               .AllowAnyHeader(); // Cabeceras específicas si es posible
    });
});

var app = builder.Build();

// Aqu� es donde llamamos a DataSeeder para agregar los roles al inicio
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DataSeeder.SeedRoles(context);  // Llamamos a la funci�n para insertar los roles
}

//MIDDLEWARES:

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(app.Environment.IsDevelopment() ? "AllowAll" : "AllowVercel");

app.UseAuthorization();

app.MapControllers();

app.Run();
