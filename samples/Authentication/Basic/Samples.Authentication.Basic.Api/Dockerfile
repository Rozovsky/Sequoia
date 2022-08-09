#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["samples/Authentication/Basic/Samples.Authentication.Basic.Api/Samples.Authentication.Basic.Api.csproj", "samples/Authentication/Basic/Samples.Authentication.Basic.Api/"]
COPY ["samples/Authentication/Basic/Samples.Authentication.Basic.Core/Samples.Authentication.Basic.Core.csproj", "samples/Authentication/Basic/Samples.Authentication.Basic.Core/"]
COPY ["src/Authentication/Sequoia.Authentication/Sequoia.Authentication.csproj", "src/Authentication/Sequoia.Authentication/"]
COPY ["src/Sequoia/Sequoia/Sequoia.csproj", "src/Sequoia/Sequoia/"]
COPY ["src/Data/Sequoia.Data/Sequoia.Data.csproj", "src/Data/Sequoia.Data/"]
RUN dotnet restore "samples/Authentication/Basic/Samples.Authentication.Basic.Api/Samples.Authentication.Basic.Api.csproj"
COPY . .
WORKDIR "/src/samples/Authentication/Basic/Samples.Authentication.Basic.Api"
RUN dotnet build "Samples.Authentication.Basic.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Samples.Authentication.Basic.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Samples.Authentication.Basic.Api.dll"]