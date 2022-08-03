#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["samples/Data/Postgresql/Samples.Data.Postgresql.Api/Samples.Data.Postgresql.Api.csproj", "samples/Data/Postgresql/Samples.Data.Postgresql.Api/"]
COPY ["samples/Data/Postgresql/Samples.Data.Postgresql.Core/Samples.Data.Postgresql.Core.csproj", "samples/Data/Postgresql/Samples.Data.Postgresql.Core/"]
COPY ["src/Data/Sequoia.Data.Postgresql/Sequoia.Data.Postgresql.csproj", "src/Data/Sequoia.Data.Postgresql/"]
COPY ["src/Data/Sequoia.Data/Sequoia.Data.csproj", "src/Data/Sequoia.Data/"]
COPY ["src/Sequoia/Sequoia/Sequoia.csproj", "src/Sequoia/Sequoia/"]
RUN dotnet restore "samples/Data/Postgresql/Samples.Data.Postgresql.Api/Samples.Data.Postgresql.Api.csproj"
COPY . .
WORKDIR "/src/samples/Data/Postgresql/Samples.Data.Postgresql.Api"
RUN dotnet build "Samples.Data.Postgresql.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Samples.Data.Postgresql.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Samples.Data.Postgresql.Api.dll"]