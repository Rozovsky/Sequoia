#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["samples/Data/Mongo/Samples.Data.Mongo.Api/Samples.Data.Mongo.Api.csproj", "samples/Data/Mongo/Samples.Data.Mongo.Api/"]
COPY ["samples/Data/Mongo/Samples.Data.Mongo.Core/Samples.Data.Mongo.Core.csproj", "samples/Data/Mongo/Samples.Data.Mongo.Core/"]
COPY ["src/Data/Sequoia.Data.Mongo/Sequoia.Data.Mongo.csproj", "src/Data/Sequoia.Data.Mongo/"]
COPY ["src/Data/Sequoia.Data/Sequoia.Data.csproj", "src/Data/Sequoia.Data/"]
COPY ["src/Sequoia/Sequoia/Sequoia.csproj", "src/Sequoia/Sequoia/"]
RUN dotnet restore "samples/Data/Mongo/Samples.Data.Mongo.Api/Samples.Data.Mongo.Api.csproj"
COPY . .
WORKDIR "/src/samples/Data/Mongo/Samples.Data.Mongo.Api"
RUN dotnet build "Samples.Data.Mongo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Samples.Data.Mongo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Samples.Data.Mongo.Api.dll"]