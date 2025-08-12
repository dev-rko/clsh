# CleanShop Docker Setup

This document provides instructions for running the CleanShop application using Docker.

## Prerequisites

- Docker Desktop installed and running
- Docker Compose installed
- At least 4GB of available RAM for SQL Server

## Quick Start

### 1. Build and Run with Docker Compose

```bash
# Build and start all services
docker-compose up --build

# Run in detached mode
docker-compose up -d --build
```

### 2. Access the Application

- **API**: http://localhost:5000
- **Swagger UI**: http://localhost:5000/swagger
- **SQL Server**: localhost:1433 (sa/YourStrong@Passw0rd)

### 3. Stop the Services

```bash
# Stop all services
docker-compose down

# Stop and remove volumes (this will delete the database)
docker-compose down -v
```

## Visual Studio / VS Code Integration

The project includes Docker launch profiles in `launchSettings.json`:

### Available Profiles

1. **Docker** - Runs the application in a single Docker container
2. **Docker Compose** - Runs the full stack (API + SQL Server) using Docker Compose
3. **Docker Compose (Debug)** - Runs with hot reload and debugging support

### Using Launch Profiles

1. In Visual Studio: Select the desired profile from the debug dropdown
2. In VS Code: Use the Run and Debug panel to select the profile
3. The browser will automatically open to the Swagger UI

### Debug Mode

For debugging with hot reload:

```bash
# Run with debug profile
docker-compose -f docker-compose.yml -f docker-compose.debug.yml up --build

# Or use the debug compose file directly
docker-compose -f docker-compose.debug.yml up --build
```

## Individual Docker Commands

### Build the API Image

```bash
docker build -f "CleanShop 71 RestApi/Dockerfile" -t cleanshop-api .
```

### Run the API Container

```bash
docker run -p 5000:80 -p 5001:443 --name cleanshop-api cleanshop-api
```

### Run SQL Server Container

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong@Passw0rd" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

## Database Setup

When running for the first time, you'll need to create and apply the database migrations:

```bash
# Apply migrations to create the database schema
docker-compose exec cleanshop-api dotnet ef database update
```

## Environment Variables

The following environment variables can be customized:

- `ASPNETCORE_ENVIRONMENT`: Set to Development, Staging, or Production
- `ConnectionStrings__DefaultConnection`: Database connection string
- `SA_PASSWORD`: SQL Server SA password
- `DOTNET_USE_POLLING_FILE_WATCHER`: Enable file watching for hot reload (debug mode)

## Troubleshooting

### Check Container Logs

```bash
# View API logs
docker-compose logs cleanshop-api

# View SQL Server logs
docker-compose logs sqlserver

# Follow logs in real-time
docker-compose logs -f cleanshop-api
```

### Access Container Shell

```bash
# Access API container
docker-compose exec cleanshop-api /bin/bash

# Access SQL Server container
docker-compose exec sqlserver /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd
```

### Reset Everything

```bash
# Stop and remove everything
docker-compose down -v --remove-orphans

# Remove all images
docker system prune -a

# Start fresh
docker-compose up --build
```

### Debug Issues

If you encounter issues with the debug profile:

1. Ensure Docker Desktop has enough resources allocated
2. Check that the debug ports (5002) are not in use
3. Verify that file watching is working correctly
4. Check container logs for any errors

## Production Considerations

For production deployment:

1. Change default passwords
2. Use secrets management
3. Configure proper SSL certificates
4. Set up monitoring and logging
5. Use a production-grade SQL Server instance
6. Configure proper backup strategies
7. Remove debug configurations and hot reload settings
