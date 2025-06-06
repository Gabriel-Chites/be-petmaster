# Use the official .NET 8 SDK image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and restore as distinct layers
COPY *.sln ./
COPY PetMaster.Domain/*.csproj PetMaster.Domain/
COPY PetMaster.Infra/*.csproj PetMaster.Infra/
COPY PetMaster.Api/*.csproj PetMaster.Api/
RUN dotnet restore

# Copy the rest of the source code
COPY PetMaster.Domain/ PetMaster.Domain/
COPY PetMaster.Infra/ PetMaster.Infra/
COPY PetMaster.Api/ PetMaster.Api/

WORKDIR /src/PetMaster.Api
RUN dotnet publish -c Release -o /app/publish --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port (adjust if your app uses a different port)
EXPOSE 80

# Set the entrypoint
ENTRYPOINT ["dotnet", "PetMaster.Api.dll"]