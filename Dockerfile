
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY *.sln ./
COPY Api.ClinicaMedica/*.csproj ./Api.ClinicaMedica/
RUN dotnet restore Api.ClinicaMedica/*.csproj


COPY . .
WORKDIR /app/Api.ClinicaMedica
RUN dotnet publish -c Release -o /out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .


EXPOSE 10000


ENTRYPOINT ["dotnet", "Api.ClinicaMedica.dll"]
