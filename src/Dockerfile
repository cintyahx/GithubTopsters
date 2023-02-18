#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Miotto.GitHubTopsters.API/Miotto.GitHubTopsters.API.csproj", "Miotto.GitHubTopsters.API/"]
RUN dotnet restore "Miotto.GitHubTopsters.API/Miotto.GitHubTopsters.API.csproj"
COPY . .
WORKDIR "/src/Miotto.GitHubTopsters.API"
RUN dotnet build "Miotto.GitHubTopsters.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Miotto.GitHubTopsters.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Miotto.GitHubTopsters.API.dll"]