#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["samples/Data/WebClient/Samples.Data.WebClient.Api/Samples.Data.WebClient.Api.csproj", "samples/Data/WebClient/Samples.Data.WebClient.Api/"]
COPY ["samples/Data/WebClient/Samples.Data.WebClient.Core/Samples.Data.WebClient.Core.csproj", "samples/Data/WebClient/Samples.Data.WebClient.Core/"]
COPY ["src/Data/Sequoia.Data.WebClient/Sequoia.Data.WebClient.csproj", "src/Data/Sequoia.Data.WebClient/"]
COPY ["src/Data/Sequoia.Data/Sequoia.Data.csproj", "src/Data/Sequoia.Data/"]
COPY ["src/Sequoia/Sequoia/Sequoia.csproj", "src/Sequoia/Sequoia/"]
RUN dotnet restore "samples/Data/WebClient/Samples.Data.WebClient.Api/Samples.Data.WebClient.Api.csproj"
COPY . .
WORKDIR "/src/samples/Data/WebClient/Samples.Data.WebClient.Api"
RUN dotnet build "Samples.Data.WebClient.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Samples.Data.WebClient.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Samples.Data.WebClient.Api.dll"]