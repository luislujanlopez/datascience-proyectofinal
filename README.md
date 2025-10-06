# Web Api para Proyecto Final de Git - BFF
Api para proyecto final de curso de git, listar productos y login

## Configuración
Configurar el appsettings

- Key 
- Issuer


## Environment Variables

Ninguna

## Architecture

**Cloud Resources**

- SQLLite Database

## Technical details

- The development approach is "Design first" through of the **`Open API 3.0`** standard.
- The service has been developed using **`ASP.NET Core 8.0 - C# 11.0`**.
- It uses the CQRS Pattern.

## Development

### Requirements

- Visual Studio 2022
- .NET 8.0 SDK
- StyleCop

### How to start

**Prepare environment**

Using Visual Studio add "User Secrets" with the following structure:

```json
{
  "APP_URL": ""
}
```

See _Environment Variables_ section to understand how to fill it.

**Compile and run**

```sh
# Install global dependencies
dotnet tool install --global coverlet.console

# Compile
dotnet restore
dotnet build

```


