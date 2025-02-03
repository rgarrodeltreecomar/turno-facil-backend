# Etapa 1: Construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar los archivos de solución y proyecto para restaurar dependencias
COPY *.sln ./
COPY Api.ClinicaMedica/*.csproj ./Api.ClinicaMedica/
RUN dotnet restore Api.ClinicaMedica/*.csproj

# Copiar el código fuente y compilar
COPY . .
WORKDIR /app/Api.ClinicaMedica
RUN dotnet publish -c Release -o /out

# Etapa 2: Ejecución (Imagen más liviana)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Exponer el puerto en el que corre la API
EXPOSE 10000

# Definir el comando de inicio
ENTRYPOINT ["dotnet", "Api.ClinicaMedica.dll"]