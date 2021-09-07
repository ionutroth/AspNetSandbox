FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DockerSandbox/DockerSandbox.csproj", "DockerSandbox/"]
RUN dotnet restore "DockerSandbox/DockerSandbox.csproj"
COPY . .
WORKDIR "/src/DockerSandbox"
RUN dotnet build "DockerSandbox.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerSandbox.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerSandbox.dll"]