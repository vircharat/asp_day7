#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MovieAppCoreApii/MovieAppCoreApii.csproj", "MovieAppCoreApii/"]
COPY ["BookTheShowBLL/BookTheShowBLL.csproj", "BookTheShowBLL/"]
COPY ["BookTheShowDAL/BookTheShowDAL.csproj", "BookTheShowDAL/"]
COPY ["BookTheShowEntity/BookTheShowEntity.csproj", "BookTheShowEntity/"]
RUN dotnet restore "MovieAppCoreApii/MovieAppCoreApii.csproj"
COPY . .
WORKDIR "/src/MovieAppCoreApii"
RUN dotnet build "MovieAppCoreApii.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieAppCoreApii.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieAppCoreApii.dll"]