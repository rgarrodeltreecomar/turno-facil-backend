using Api.ClinicaMedica.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//SERVICES: 

//Evitar referencias cíclicas y serializaciones innecesarias
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtener la cadena de conexión
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
                      ?? builder.Configuration.GetConnectionString("HackacodeConnection");

// Registrar ApplicationDbContext en el contenedor de servicios
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Config de AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Configurar CORS
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
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configurar autenticación con JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:ClaveSecreta"]))


        };
    });
// Habilitar autorización
builder.Services.AddAuthorization();

var app = builder.Build();

// Aquí es donde llamamos a DataSeeder para agregar los roles al inicio
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DataSeeder.SeedRoles(context);  // Llamamos a la función para insertar los roles
}

// MIDDLEWARES:

// Configurar el pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(app.Environment.IsDevelopment() ? "AllowAll" : "AllowVercel");

// Middleware de autenticación y autorización
app.UseAuthentication();  // <---- AGREGADO
app.UseAuthorization();

app.MapControllers();

app.Run();
