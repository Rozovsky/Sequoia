#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["samples/Sequoia/Complex/Samples.Sequoia.Complex.Api/Samples.Sequoia.Complex.Api.csproj", "samples/Sequoia/Complex/Samples.Sequoia.Complex.Api/"]
COPY ["samples/Sequoia/Complex/Samples.Sequoia.Complex.Core/Samples.Sequoia.Complex.Core.csproj", "samples/Sequoia/Complex/Samples.Sequoia.Complex.Core/"]
COPY ["src/Data/Sequoia.Data.Postgresql/Sequoia.Data.Postgresql.csproj", "src/Data/Sequoia.Data.Postgresql/"]
COPY ["src/Data/Sequoia.Data/Sequoia.Data.csproj", "src/Data/Sequoia.Data/"]
COPY ["src/Sequoia/Sequoia/Sequoia.csproj", "src/Sequoia/Sequoia/"]
RUN dotnet restore "samples/Sequoia/Complex/Samples.Sequoia.Complex.Api/Samples.Sequoia.Complex.Api.csproj"
COPY . .
WORKDIR "/src/samples/Sequoia/Complex/Samples.Sequoia.Complex.Api"
RUN dotnet build "Samples.Sequoia.Complex.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Samples.Sequoia.Complex.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Samples.Sequoia.Complex.Api.dll"]